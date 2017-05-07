﻿Public Class TipoClienteDAO
    Implements ObjetoDAO

    Public Function all() As DataTable Implements ObjetoDAO.all
        Dim sql_select = "SELECT idTipo as id, nombre, descripcion FROM tipos_cliente"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Dim tipo_cliente = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO tipos_cliente (nombre, descripcion)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & tipo_cliente._nombre & "', "
        sql_insertar &= "'" & tipo_cliente._descripcion & "')"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
        tipo_cliente._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Dim tipo_cliente = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE tipos_cliente"
        sql_update &= " SET "
        sql_update &= "nombre='" & tipo_cliente._nombre & "', "
        sql_update &= "descripcion='" & tipo_cliente._descripcion & "' "
        sql_update &= " WHERE idTipo=" & tipo_cliente._id
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Dim tipo_cliente = cast(value)
        Dim sql_delete = "DELETE FROM tipos_cliente" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idTipo=" & tipo_cliente._id
        DataBase.getInstance().ejecuta_sql(sql_delete)
        tipo_cliente._id = 0
    End Sub

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Dim tipo_cliente = cast(value)
        ' DOC: determina si existe la marca en la BD, según PK

        If tipo_cliente._id > 0 Then
            Dim sql = "SELECT TOP 1 idTipo FROM tipos_cliente WHERE idTipo=" & tipo_cliente._id
            Dim response = DataBase.getInstance().consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Private Function cast(value As ObjetoVO) As TipoClienteVO
        If TypeOf value Is TipoClienteVO Then
            Return value
        Else
            Throw New System.Exception("Error: TipoClienteDAO solo admite objetos TipoClienteVO")
        End If
    End Function

End Class
