Imports PAV1_Proyecto

Public Class DetalleCompraDAO
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
        Throw New NotImplementedException()
    End Function

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Throw New NotImplementedException()
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "codigo_producto", ._name = "Codigo"})
        campos.Add(New Campo With {._id = "id_compra", ._name = "", ._visible = False})
        campos.Add(New Campo With {._id = "costo", ._name = "Costo", ._numeric = True, ._required = True})
        campos.Add(New Campo With {._id = "cantidad", ._name = "Cantidad", ._numeric = True, ._required = True})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "codigo_producto", ._name = "Codigo"})
        campos.Add(New Campo With {._id = "id_compra", ._name = "", ._visible = False})
        campos.Add(New Campo With {._id = "costo", ._name = "Costo", ._numeric = True, ._required = True})
        campos.Add(New Campo With {._id = "cantidad", ._name = "Cantidad", ._numeric = True, ._required = True})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Return New DetalleCompraVO With {
            .codigo_producto = valores("codigo_producto"),
            .id_compra = valores("id_compra"),
            .costo = valores("costo"),
            .cantidad = valores("cantidad")
        }
    End Function
End Class
