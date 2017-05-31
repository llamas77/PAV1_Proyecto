Public Class DataBase
    ' DOC: Clase encargada de ejecutar todas las consultas a la BD.
    '      Administra las conexiones.

    ' TODO: Crear un usuario en el SQL Server y poner el string de conexion.
    Private cadena_conexion As String = "Provider=SQLNCLI11;Data Source=EsC\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=sistema_stock"
    Private conexion As New OleDb.OleDbConnection
    ' Nota: Trabajar con un solo comando puede mejorar la gestion de memoria evitando basura.
    '       Pero en un ambiente MultiThread puede causar que se ejecute una consulta inesperada.
    Private command As New OleDb.OleDbCommand
    Private _transaccion As OleDb.OleDbTransaction

    Enum Estado
        desconectado
        listo
        transaccion_listo
        transaccion_error
    End Enum
    Private estado_actual As Estado

    Public ReadOnly Property _estado As Estado
        Get
            Return estado_actual
        End Get
    End Property

    Private Property transaccion As OleDb.OleDbTransaction
        Get
            Return _transaccion
        End Get
        Set(value As OleDb.OleDbTransaction)
            _transaccion = value
            command.Transaction = value
            estado_actual = Estado.transaccion_listo
        End Set
    End Property

    Public Sub New()
        command.Connection = conexion
        estado_actual = Estado.desconectado
    End Sub

    Public Shared Function getInstance() As DataBase ' TODO: Renombrar a new_connected()
        ' DOC: Se mantiene por compatibilidad con funcionamiento anterior.
        '      Devuelve una clase lista para recibir y ejecutar comandos.
        Dim db As New DataBase
        db.conectar()
        Return db
    End Function

    Public Sub conectar()
        If _estado <> Estado.desconectado Then
            Throw New System.Exception("Ya hay una conexión abierta.")
        End If
        conexion.ConnectionString = cadena_conexion
        Try
            conexion.Open()
        Catch ex As Exception
            MsgBox("No se puede establecer una conexion con la base de datos", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try

        estado_actual = Estado.listo
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
                conexion.Close()
                estado_actual = Estado.desconectado
            Else
                Throw New System.Exception("No hay ninguna conexion abierta.")
            End If
        End If
    End Sub

    Public Sub cerrar_transaccion()
        transaccion.Commit()
        transaccion = Nothing
        estado_actual = Estado.listo
    End Sub

    Public Sub cancelar_transaccion()
        transaccion.Rollback()
        estado_actual = Estado.transaccion_error
    End Sub

    Public Function consulta_sql(ByVal sql As String) As DataTable
        ' DOC: Ejecuta una consulta y retorna el resultado.
        If conexion Is Nothing Then
            Throw New System.Exception("No hay una conexion abierta con la base de datos.")
        End If
        If _estado = Estado.transaccion_error Then
            Return Nothing
        End If

        Dim tabla As New DataTable

        command.CommandText = sql
        Try
            tabla.Load(command.ExecuteReader())
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
        If _estado = Estado.transaccion_error Then
            Exit Sub
        End If

        command.CommandText = sql
        Try
            command.ExecuteNonQuery()
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
