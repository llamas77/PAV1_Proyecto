Public Class DataBase
    ' DOC: Clase encargada de ejecutar todas las consultas a la BD.
    '      Administra las conexiones.

    ' TODO: Crear un usuario en el SQL Server y poner el string de conexion.
    Private Shared instance As DataBase
    Dim cadena_conexion As String = ""

    Private Sub New()
    End Sub

    Public Shared Function getInstance() As DataBase
        Return IIf(IsNothing(instance), New DataBase(), instance)
    End Function

    Public Function consulta_sql(ByVal sql As String) As DataTable
        ' DOC: Ejecuta una consulta y retorna el resultado.
        Dim conexion As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim tabla As New DataTable

        ' TODO: Poner un Try Catch
        conexion.ConnectionString = cadena_conexion
        conexion.Open()
        cmd.Connection = conexion
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        tabla.Load(cmd.ExecuteReader())
        conexion.Close()
        Return tabla
    End Function

    Public Sub ejecuta_sql(ByVal sql As String)
        ' DOC: Ejecuta una consulta que no trae resultados o los ignora.
        Dim conexion As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand

        ' TODO: Poner un Try Catch
        conexion.ConnectionString = cadena_conexion
        conexion.Open()
        cmd.Connection = conexion
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        cmd.ExecuteNonQuery()
        conexion.Close()
    End Sub


End Class
