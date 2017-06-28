Imports PAV1_Proyecto

Public Class DetalleCompraDAO
    Implements ObjetoDAO, ObjectFactory, ICanDAO

    Public Sub insert(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.insert
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        ' Pensado para ser ejecutado en un DataBase con transaccion en curso.
        Dim detalle = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO detalle_compras (codigoProducto, idCompra, costo, cantidad)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & detalle.codigo_producto & "', "
        sql_insertar &= detalle.id_compra & ", "
        sql_insertar &= "'" & detalle.costo.ToString.Replace(",", ".") & "', "
        sql_insertar &= detalle.cantidad & ") "
        Dim tabla = db.consulta_sql(sql_insertar)
    End Sub

    <Obsolete("Obsoleta. Use Insert en su lugar.")> ' Borrar funcion si no tiene mas referencias.
    Public Sub insert_in(db As DataBase, value As ObjetoVO)
        insert(value, db)
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim detalle = cast(value)

        Dim sql_update As String
        sql_update = "UPDATE detalle_compras"
        sql_update &= " SET "
        sql_update &= "costo='" & detalle.costo.ToString.Replace(",", ".") & "', "
        sql_update &= "cantidad='" & detalle.cantidad & "'"
        sql_update &= " WHERE codigoProducto='" & detalle.codigo_producto & "'"
        sql_update &= " AND idCompra=" & detalle.id_compra
        db.ejecuta_sql(sql_update)
    End Sub

    <Obsolete("Obsoleta. Use Update en su lugar.")> ' Borrar funcion si no tiene mas referencias.
    Public Sub update_in(db As DataBase, value As ObjetoVO)
        update(value, db)
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim detalle = cast(value)

        Dim sql_delete = "DELETE FROM detalle_compras" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE codigoProducto='" & detalle.codigo_producto & "'"
        sql_delete &= " AND idCompra=" & detalle.id_compra
        db.ejecuta_sql(sql_delete)

        detalle.id_compra = 0
        detalle.codigo_producto = 0
    End Sub

    <Obsolete("Obsoleta. Use Delete en su lugar.")> ' Borrar funcion si no tiene mas referencias.
    Public Sub delete_in(db As DataBase, value As ObjetoVO)
        delete(value, db)
    End Sub

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        Throw New NotImplementedException()
    End Function

    Public Function all_from_compra(id_compra As Integer) As List(Of ObjetoVO)
        Dim detalles As New List(Of ObjetoVO)
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

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
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
        campos.Add(New Campo With {._id = "codigo_producto", ._name = "Codigo", ._unique = True})
        campos.Add(New Campo With {._id = "id_compra", ._name = "", ._visible = False})
        campos.Add(New Campo With {._id = "costo", ._name = "Costo", ._numeric = True, ._required = True})
        campos.Add(New Campo With {._id = "cantidad", ._name = "Cantidad", ._numeric = True, ._required = True})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Dim detalle As New DetalleCompraVO With {
            .id_compra = valores("id_compra"),
            .costo = valores("costo"),
            .cantidad = valores("cantidad")
        }

        If valores.ContainsKey("producto") Then
            With DirectCast(valores("producto"), ProductoVO)
                detalle.codigo_producto = ._codigo
            End With
        Else
            detalle.codigo_producto = valores("codigo_producto")
        End If

        Return detalle
    End Function

    Public Function can_insert(value As ObjetoVO) As String Implements ICanDAO.can_insert
        ' Siempre es posible agregar un detalle porque aumenta el stock.
        Return Nothing
    End Function

    Public Function can_update(value As ObjetoVO) As String Implements ICanDAO.can_update
        Dim detalle = cast(value)

        ' Busco la cantidad actual de stock, mas la cantidad del detalle viejo (que esta guardado en db)
        ' para poder rehacer el calculo con el stock correcto.
        Dim sql = "SELECT p.stock + dc.cantidad FROM detalle_compras dc"
        sql &= " JOIN productos p ON dc.codigoProducto = p.codigoProducto"
        sql &= " WHERE p.codigoProducto='" & detalle.codigo_producto & "'"
        sql &= " AND dc.idCompra=" & detalle.id_compra

        Dim db = DataBase.getInstance()
        Dim response = db.consulta_sql(sql)
        If response.Rows.Count = 0 Then
            Return "El detalle del producto " & detalle.codigo_producto & " no existe." & Chr(13) _
                & "[IdVenta=" & detalle.id_compra & "]"
        Else
            If response(0)(0) - detalle.cantidad < 0 Then
                Return "No hay suficiente stock del producto " & detalle.codigo_producto & Chr(13) _
                    & "Ya se vendieron unidades del producto de esta compra." & Chr(13) _
                    & "[Stock=" & response(0)(0) & "]"
            End If
        End If
        Return Nothing
    End Function

    Public Function can_delete(value As ObjetoVO) As String Implements ICanDAO.can_delete
        Dim detalle = cast(value)

        ' Busco la cantidad actual de stock, mas la cantidad del detalle viejo (que esta guardado en db)
        ' para poder rehacer el calculo con el stock correcto.
        Dim sql = "SELECT p.stock FROM productos p"
        sql &= " WHERE p.codigoProducto='" & detalle.codigo_producto & "'"
        Dim db = DataBase.getInstance()
        Dim response = db.consulta_sql(sql)
        If response.Rows.Count = 0 Then
            Return "El detalle del producto " & detalle.codigo_producto & " no existe." & Chr(13) _
                & "[IdVenta=" & detalle.id_compra & "]"
        Else
            If response(0)(0) - detalle.cantidad < 0 Then
                Return "No hay suficiente stock del producto " & detalle.codigo_producto & Chr(13) _
                    & "Ya se vendieron unidades del producto de esta compra." & Chr(13) _
                    & "[Stock=" & response(0)(0) & "]"
            End If
        End If
        Return Nothing
    End Function
End Class
