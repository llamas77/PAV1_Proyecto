Imports PAV1_Proyecto

Public Class DetalleVentaDAO
    Implements ObjetoDAO, ObjectFactory

    Public Sub insert(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.insert
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        ' Pensado para ser ejecutado en un DataBase con transaccion en curso.
        Dim detalle = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO detalleVentas (codigoProducto, idVenta, precio, cantidad)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & detalle.codigo_producto & "', "
        sql_insertar &= detalle.id_venta & ", "
        sql_insertar &= "'" & detalle.precio.ToString.Replace(",", ".") & "', "
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
        sql_update = "UPDATE detalleVentas"
        sql_update &= " SET "
        sql_update &= "precio='" & detalle.precio.ToString.Replace(",", ".") & "', "
        sql_update &= "cantidad='" & detalle.cantidad & "'"
        sql_update &= " WHERE codigoProducto='" & detalle.codigo_producto & "'"
        sql_update &= " AND idVenta=" & detalle.id_Venta
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

        Dim sql_delete = "DELETE FROM detalleVentas" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE codigoProducto='" & detalle.codigo_producto & "'"
        sql_delete &= " AND idVenta=" & detalle.id_venta
        db.ejecuta_sql(sql_delete)

        detalle.id_venta = 0
        detalle.codigo_producto = 0
    End Sub

    <Obsolete("Obsoleta. Use Delete en su lugar.")> ' Borrar funcion si no tiene mas referencias.
    Public Sub delete_in(db As DataBase, value As ObjetoVO)
        delete(value, db)
    End Sub

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        Throw New NotImplementedException()
    End Function

    Public Function all_from_venta(id_venta As Integer) As List(Of ObjetoVO)
        Dim detalles As New List(Of ObjetoVO)
        Dim sql_select = "SELECT codigoProducto, idVenta, precio, cantidad"
        sql_select &= " FROM detalleVentas"
        sql_select &= " WHERE idVenta=" & id_venta
        Dim datos = DataBase.getInstance().consulta_sql(sql_select)
        For Each dato In datos.Rows
            detalles.Add(New DetalleVentaVO With {
                         .codigo_producto = dato("codigoProducto"),
                         .id_venta = dato("idVenta"),
                         .precio = dato("precio"),
                         .cantidad = dato("cantidad")})
        Next
        Return detalles
    End Function

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        Throw New NotImplementedException()
    End Function

    Private Function cast(value As ObjetoVO) As DetalleVentaVO
        If TypeOf value Is DetalleVentaVO Then
            Return value
        Else
            Throw New System.Exception("Error: DetalleVentaDAO solo admite objetos DetalleVentaVO")
        End If
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "codigo_producto", ._name = "Codigo"})
        campos.Add(New Campo With {._id = "id_venta", ._name = "", ._visible = False})
        campos.Add(New Campo With {._id = "precio", ._name = "precio", ._numeric = True, ._required = True})
        campos.Add(New Campo With {._id = "cantidad", ._name = "Cantidad", ._numeric = True, ._required = True})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "codigo_producto", ._name = "Codigo"})
        campos.Add(New Campo With {._id = "id_venta", ._name = "", ._visible = False})
        campos.Add(New Campo With {._id = "precio", ._name = "precio", ._numeric = True, ._required = True})
        campos.Add(New Campo With {._id = "cantidad", ._name = "Cantidad", ._numeric = True, ._required = True})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Dim detalle As New DetalleVentaVO With {
            .id_venta = valores("id_venta"),
            .precio = valores("precio"),
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
End Class
