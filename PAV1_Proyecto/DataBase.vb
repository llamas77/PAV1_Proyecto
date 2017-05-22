Public Class DataBase
    ' DOC: Clase encargada de ejecutar todas las consultas a la BD.
    '      Administra las conexiones.

    ' TODO: Crear un usuario en el SQL Server y poner el string de conexion.
    Private cadena_conexion As String = "Provider=SQLNCLI11;Data Source=JUANI-PC\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=sistema_stock"
    Private conexion As OleDb.OleDbConnection
    Private transaccion As OleDb.OleDbTransaction

    Public Shared Function getInstance() As DataBase ' TODO: Renombrar a new_connected()
        ' DOC: Se mantiene por compatibilidad con funcionamiento anterior.
        '      Devuelve una clase lista para recibir y ejecutar comandos.
        Dim db As New DataBase
        db.conectar()
        Return db
    End Function

    Public Sub conectar()
        ' Siempre que se llame a esta funcion es responsabilidad de quien llama cerrar la conexion.
        If Me.conexion IsNot Nothing Then
            Throw New System.Exception("Ya hay una conección abierta.")
        End If
        Dim conexion As New OleDb.OleDbConnection
        conexion.ConnectionString = cadena_conexion
        Try
            conexion.Open()
        Catch ex As Exception
            MsgBox("No se puede establecer una conexion con la base de datos", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
        Me.conexion = conexion
    End Sub

    Public Sub iniciar_transaccion()
        If Me.transaccion IsNot Nothing Then
            Throw New System.Exception("Ya hay una transaccion abierta.")
        End If
        Me.transaccion = conexion.BeginTransaction()
    End Sub

    Public Sub desconectar()
        ' Cierra la conexion con la base de datos.
        If transaccion Is Nothing Then ' Solo cierra si no hay transaccion pendiente.
            If conexion IsNot Nothing Then
                transaccion.Commit()
                conexion.Close()
                transaccion = Nothing
                conexion = Nothing
            Else
                Throw New System.Exception("No hay ninguna conexion abierta.")
            End If
        End If
    End Sub

    Public Sub cerrar_transaccion()
        transaccion.Commit()
        transaccion = Nothing
    End Sub

    Public Sub cancelar_transaccion()
        transaccion.Rollback()
        transaccion = Nothing
    End Sub

    Public Function consulta_sql(ByVal sql As String) As DataTable
        ' DOC: Ejecuta una consulta y retorna el resultado.
        Dim cmd As New OleDb.OleDbCommand
        Dim tabla As New DataTable

        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = conexion
        cmd.Transaction = transaccion
        Try
            tabla.Load(cmd.ExecuteReader())
        Catch ex As Exception
            If transaccion IsNot Nothing Then
                cancelar_transaccion()
            End If
            mostrar_error(ex)
        Finally
            desconectar()
        End Try

        Return tabla
    End Function


    Public Sub ejecuta_sql(ByVal sql As String)
        ' DOC: Ejecuta una consulta que no trae resultados o los ignora.
        If conexion Is Nothing Then
            Throw New System.Exception("No hay una conexion abierta con la base de datos.")
        End If

        Dim cmd As New OleDb.OleDbCommand

        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.Connection = conexion
        cmd.Transaction = transaccion
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            If transaccion IsNot Nothing Then
                cancelar_transaccion()
            End If
            mostrar_error(ex)
        Finally
            desconectar()
        End Try
    End Sub

    Private Sub mostrar_error(ex As Exception)
        MsgBox("Wops! Ocurrio un error al interactuar con la base de datos." &
                Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Error")
    End Sub
End Class
