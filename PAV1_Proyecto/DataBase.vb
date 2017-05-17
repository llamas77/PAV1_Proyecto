Public Class DataBase
    ' DOC: Clase encargada de ejecutar todas las consultas a la BD.
    '      Administra las conexiones.

    ' TODO: Crear un usuario en el SQL Server y poner el string de conexion.
    ' TODO: Adaptar clase para trabajar con transacciones.
    Private Shared instance As DataBase
    Private cadena_conexion As String = "Provider=SQLNCLI11;Data Source=ESC\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=sistema_stock"

    Private Sub New() ' Constructor Privado. Patron Singleton.
    End Sub

    Public Shared Function getInstance() As DataBase
        ' DOC: Patron Singleton: Esta clase solo tendra una unica instancia como máximo.
        '      No se le hace new a esta clase, se pide la instancia con getInstance().
        Return IIf(IsNothing(instance), New DataBase(), instance)
    End Function

    Private Function conectar() As OleDb.OleDbConnection
        ' Siempre que se llame a esta funcion es responsabilidad de quien llama cerrar la conexion.
        Dim conexion As New OleDb.OleDbConnection
        conexion.ConnectionString = cadena_conexion
        Try
            conexion.Open()
        Catch ex As Exception
            MsgBox("No se puede establecer una conexion con la base de datos", MsgBoxStyle.Critical, "Error")
        End Try
        Return conexion
    End Function

    Public Function consulta_sql(ByVal sql As String) As DataTable
        ' DOC: Ejecuta una consulta y retorna el resultado.
        Dim cmd As New OleDb.OleDbCommand
        Dim tabla As New DataTable

        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        Dim conexion = conectar()
        cmd.Connection = conexion
        Try
            tabla.Load(cmd.ExecuteReader())
        Catch ex As Exception
            MsgBox("Wops! Ocurrio un error al interactuar con la base de datos." &
                    Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            conexion.Close()
        End Try

        Return tabla
    End Function

    Public Sub ejecuta_sql(ByVal sql As String)
        ' DOC: Ejecuta una consulta que no trae resultados o los ignora.
        Dim cmd As New OleDb.OleDbCommand
        Dim tabla As New DataTable

        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        Dim conexion = conectar()
        cmd.Connection = conexion
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Wops! Ocurrio un error al interactuar con la base de datos." &
                    Chr(13) & Chr(13) & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            conexion.Close()
        End Try
    End Sub

End Class
