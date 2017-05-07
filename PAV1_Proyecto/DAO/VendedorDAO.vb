Imports PAV1_Proyecto

Public Class VendedorDAO
    Implements ObjetoDAO

    Public Function all() As DataTable Implements ObjetoDAO.all
        Dim sql_select = "SELECT idVendedor as id, nombre, apellido, direccion, telefono, comision FROM vendedores"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Dim vendedor = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO vendedores (nombre, apellido, direccion, telefono, comision)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & vendedor._nombre & "', "
        sql_insertar &= "'" & vendedor._apellido & "', "
        sql_insertar &= "'" & vendedor._direccion & "', "
        sql_insertar &= "'" & vendedor._telefono & "', "
        sql_insertar &= vendedor._comision.ToString.Replace(",", ".") & ")" ' Nota: Hay que sacar todas las "," que separan decimal.
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
        vendedor._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Dim vendedor = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE vendedores"
        sql_update &= " SET "
        sql_update &= "nombre='" & vendedor._nombre & "', "
        sql_update &= "apellido='" & vendedor._apellido & "', "
        sql_update &= "direccion='" & vendedor._direccion & "', "
        sql_update &= "telefono='" & vendedor._telefono & "', "
        sql_update &= "comision=" & vendedor._comision & ", "
        sql_update &= " WHERE idVendedor=" & vendedor._id
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Dim vendedor = cast(value)
        Dim sql_delete = "DELETE FROM vendedores" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idVendedor=" & vendedor._id
        DataBase.getInstance().ejecuta_sql(sql_delete)
        vendedor._id = 0
    End Sub

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Dim vendedor = cast(value)
        ' DOC: determina si existe la marca en la BD, según PK

        If vendedor._id > 0 Then
            Dim sql = "SELECT TOP 1 idVendedor FROM vendedores WHERE idVendedor=" & vendedor._id
            Dim response = DataBase.getInstance().consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Private Function cast(value As ObjetoVO) As VendedorVO
        If TypeOf value Is VendedorVO Then
            Return value
        Else
            Throw New System.Exception("Error: VendedorDAO solo admite objetos VendedorVO")
        End If
    End Function
End Class
