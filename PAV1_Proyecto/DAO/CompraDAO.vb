Imports PAV1_Proyecto

Public Class CompraDAO
    Implements ObjetoDAO, ObjectFactory

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Throw New NotImplementedException()
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Throw New NotImplementedException()
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Throw New NotImplementedException()
    End Sub

    Public Function all() As DataTable Implements ObjetoDAO.all
        Dim sql_select = "SELECT idCompra as id, fechaCompra as fecha_compra, "
        sql_select &= " idProveedor as id_proveedor, 'NotImplemented' as detalle"
        sql_select &= " FROM compras"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Throw New NotImplementedException()
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "fecha_compra", ._name = "Fecha de Compra", ._maskType = Campo.MaskType.fecha,
                                   ._required = True})
        campos.Add(New Campo With {._id = "id_proveedor", ._name = "Proveedor", ._maskType = Campo.MaskType.comboBox,
                                   ._combo_data_source = New ProveedorDAO, ._required = True})
        campos.Add(New Campo With {._id = "detalle", ._name = "Detalle", ._maskType = Campo.MaskType.control,
                                   ._control = New Detalle(New DetalleCompraDAO)})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "fecha_compra", ._name = "Fecha de Compra"})
        campos.Add(New Campo With {._id = "id_proveedor", ._name = "Proveedor"})
        campos.Add(New Campo With {._id = "detalle", ._name = "Detalle", ._visible = False})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Return New CompraVO With {
            .id = valores("id"),
            .fecha_compra = valores("fecha_compra"),
            .id_proveedor = valores("id_proveedor"),
            .detalle = valores("detalle")
        }
    End Function
End Class
