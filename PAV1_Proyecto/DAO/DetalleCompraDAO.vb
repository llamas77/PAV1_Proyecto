Imports PAV1_Proyecto

Public Class DetalleCompraDAO
    Implements ObjetoDAO, ObjectFactory

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Dim detalle = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO detalle_compras (codigoProducto, idCompra, costo, cantidad)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & detalle.codigo_producto & "', "
        sql_insertar &= detalle.id_compra & ", "
        sql_insertar &= "'" & detalle.costo.ToString.Replace(",", ".") & "', "
        sql_insertar &= detalle.cantidad & ") "
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Dim detalle = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE detalle_compras"
        sql_update &= " SET "
        sql_update &= "costo='" & detalle.costo.ToString.Replace(",", ".") & "', "
        sql_update &= "cantidad='" & detalle.cantidad & "'"
        sql_update &= " WHERE codigoProducto='" & detalle.codigo_producto & "'"
        sql_update &= " AND idCompra=" & detalle.id_compra
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Dim detalle = cast(value)
        Dim sql_delete = "DELETE FROM detalle_compras" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE codigoProducto='" & detalle.codigo_producto & "'"
        sql_delete &= " AND idCompra=" & detalle.id_compra
        DataBase.getInstance().ejecuta_sql(sql_delete)
        detalle.id_compra = 0
        detalle.codigo_producto = 0
    End Sub

    Public Function all() As DataTable Implements ObjetoDAO.all
        Throw New NotImplementedException()
    End Function

    Public Function all_from_compra(id_compra As Integer) As List(Of DetalleCompraVO)
        Dim detalles As New List(Of DetalleCompraVO)
        Dim sql_select = "SELECT codigoProducto, idCompra, costo, cantidad"
        sql_select &= " FROM detalle_compras"
        sql_select &= " WHERE idCompra=" & id_compra
        Dim datos = DataBase.getInstance().consulta_sql(sql_select)
        For Each dato In datos.Rows
            detalles.Add(New DetalleCompraVO With {
                         .codigo_producto = dato("codigoProducto"),
                         .id_compra = dato("idCompra"),
                         .costo = dato("costo"),
                         .cantidad = dato("cantidad")})
        Next
        Return detalles
    End Function

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Throw New NotImplementedException()
    End Function

    Private Function cast(value As ObjetoVO) As DetalleCompraVO
        If TypeOf value Is DetalleCompraVO Then
            Return value
        Else
            Throw New System.Exception("Error: DetalleCompraDAO solo admite objetos DetalleCompraVO")
        End If
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
