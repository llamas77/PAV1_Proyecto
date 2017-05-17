Imports PAV1_Proyecto

Public Class ProveedorDAO
    Implements ObjetoDAO, ObjectFactory


    Public Function all() As DataTable Implements ObjetoDAO.all
        Dim sql_select = "SELECT idProveedor as id, razonSocial, cuit, domicilio, telefono, email"
        sql_select &= " FROM proveedores"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Dim proveedor = cast(value)

        Dim sql_insertar = "INSERT INTO proveedores (razonSocial, cuit, domicilio, telefono, email)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & proveedor._razonSocial & "', "
        sql_insertar &= proveedor._cuit & ", "
        sql_insertar &= "'" & proveedor._domicilio & "', "
        sql_insertar &= proveedor._telefono & ", "
        sql_insertar &= "'" & proveedor._email & "')"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
        proveedor._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Dim proveedor = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE proveedores"
        sql_update &= " SET "
        sql_update &= "razonSocial='" & proveedor._razonSocial & "', "
        sql_update &= "domicilio='" & proveedor._domicilio & "', "
        sql_update &= "telefono='" & proveedor._telefono & "', "
        sql_update &= "email='" & proveedor._email & "'"
        sql_update &= " WHERE idProveedor=" & proveedor._id
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub


    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Dim proveedor = cast(value)
        Dim sql_delete = "DELETE FROM proveedores"
        sql_delete &= " WHERE idProveedor=" & proveedor._id
        DataBase.getInstance().ejecuta_sql(sql_delete)
        proveedor._id = 0
    End Sub




    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Throw New NotImplementedException()
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Throw New NotImplementedException()
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Throw New NotImplementedException()
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Throw New NotImplementedException()
    End Function
End Class
