Imports PAV1_Proyecto

Public Class ventaDAO
    Implements ObjetoDAO, ObjectFactory

    Public Sub insert(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.insert
        Dim venta = cast(value)

        ' -- Seteo
        Dim sql_insertar As String
        sql_insertar = "INSERT INTO ventas (nroCliente,idVendedor,fechaVenta, nroComprobante)"
        sql_insertar &= " VALUES ("
        sql_insertar &= venta._cliente._nro & ", "
        sql_insertar &= venta._vendedor._id & ", "
        sql_insertar &= "convert(date, '" & venta._fecha_venta & "', 103), "
        sql_insertar &= venta._nro_comprobante & ") "
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.

        ' -- Ejecucion
        If db Is Nothing Then
            db = New DataBase
            db.conectar()
            db.iniciar_transaccion()
        ElseIf db._estado = DataBase.Estado.listo Then
            db.iniciar_transaccion()
        End If

        Dim tabla = db.consulta_sql(sql_insertar) ' venta
        venta._id = tabla(0)(0)
        Dim detalleDAO As New DetalleVentaDAO
        Dim productoDAO As New ProductoDAO
        Dim productoVO As ProductoVO
        Dim detalles = venta.detalle.Cast(Of DetalleVentaVO)
        For Each detalle As DetalleVentaVO In detalles
            detalle.id_venta = venta._id
            detalleDAO.insert(detalle, db) ' Detalle
            productoVO = productoDAO.search_code(db, detalle.codigo_producto)
            If productoVO Is Nothing Then
                db.cancelar_transaccion()
                Throw New System.Exception("El Codigo de Producto no existe.")
            End If
            productoVO._stock += detalle.cantidad
            If productoVO._fechaLista < venta._fecha_venta Then
                productoVO._costo = detalle.costo
                productoVO._fechaLista = venta._fecha_venta
            End If
            productoDAO.update(productoVO, db) ' Stock Producto
        Next

        db.cerrar_transaccion()
        db.desconectar()
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        Dim venta = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE ventas"
        sql_update &= " SET "
        sql_update &= "fechaventa=convert(date, '" & venta._fecha_venta & "', 103)), "
        sql_update &= "idCliente=" & venta._cliente._nro
        sql_update &= "idVendedor=" & venta._vendedor._id
        sql_update &= " WHERE idVenta=" & venta._id

        If db Is Nothing Then
            db = New DataBase
            db.conectar()
            db.iniciar_transaccion()
        ElseIf db._estado = DataBase.Estado.listo Then
            db.iniciar_transaccion()
        End If

        Dim detalleDAO As New DetalleVentaDAO
        Dim detalles = venta.detalle.Cast(Of DetalleVentaVO)
        For Each detalle In detalles
            If detalle.id_venta <> venta._id Then
                db.cancelar_transaccion()
                Throw New System.Exception("El ID del detalle es distinto del de la venta.")
            End If
            detalleDAO.update(detalle, db)
        Next
        db.cerrar_transaccion()
        db.desconectar()
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        Dim venta = cast(value)

        Dim sql_delete = "DELETE FROM ventas" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idVenta=" & venta._id

        If db Is Nothing Then
            db = New DataBase
            db.conectar()
            db.iniciar_transaccion()
        ElseIf db._estado = DataBase.Estado.listo Then
            db.iniciar_transaccion()
        End If

        Dim detalleDAO As New DetalleVentaDAO
        Dim detalles = venta.detalle.Cast(Of DetalleVentaVO)
        For Each detalle In detalles
            If detalle.id_venta <> venta._id Then
                db.cancelar_transaccion()
                Throw New System.Exception("El ID del detalle es distinto del de la venta.")
            End If
            detalleDAO.delete(detalle, db)
        Next
        db.ejecuta_sql(sql_delete)
        db.cerrar_transaccion()
        db.desconectar()

        venta._id = 0
    End Sub

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim dataSet As New Grillaventas
        Dim dataTable As DataTable = dataSet.ventas

        Dim sql_select = "SELECT v.idVenta, convert(char(10), v.fechaVenta, 103) as fecha_venta, v.nroComprobante, "
        sql_select &= "c.nroCliente, c.nombre as nombreCliente, c.apellido as apellidoCliente,c.direccion as direccionCliente, "
        sql_select &= "c.telefono as telCliente, c.idTipoCliente, ven.idVendedor, ven.nombre as nombreVendedor, "
        sql_select &= "ven.apellido as apellidoVendedor, ven.direccion as direccionVendedor,ven.telefono as telVendedor, ven.comision "
        sql_select &= "FROM ventas v JOIN clientes c ON v.nroCliente= c.nroCliente "
        sql_select &= "JOIN vendedores ven ON v.idVendedor = ven.idVendedor"
        Dim ventas = db.consulta_sql(sql_select)

        ' Formatea el resultado para adaptarse al DataSet
        ' NOTA: Por alguna razon, si se produce una excepcion en el for, no avisa.
        For Each venta As DataRow In ventas.Rows
            Dim row = dataTable.Rows.Add()
            row("id") = venta("idventa")
            row("fecha_venta") = venta("fecha_venta")
            row("cliente") = New ClienteVO With {
                ._nro = venta("nroCliente"),
                ._nombre = venta("nombreCliente"),
                ._apellido = venta("apellidoCliente"),
                ._direccion = venta("direccionCliente"),
                ._telefono = venta("telCliente"),
                ._tipo_cliente = venta("idTipoCliente")
            }
            row("vendedor") = New VendedorVO With {
                ._id = venta("idvendedor"),
                ._nombre = venta("nombreVendedor"),
                ._apellido = venta("apellidoVendedor"),
                ._direccion = venta("direccionVendedor"),
                ._telefono = venta("telVendedor"),
                ._porcentaje_comision = venta("comision")
            }
            With New DetalleVentaDAO
                row("detalles") = .all_from_venta(venta("idventa"))
            End With
        Next

        Return dataTable_to_List(dataTable)
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"id", "fecha_venta", "vendedor", "detalles"}
        Dim diccionario As New Dictionary(Of String, Object)
        For Each param In params
            diccionario.Add(param, Nothing)
        Next

        For Each row In tabla.Rows
            For Each param In params
                diccionario(param) = row(param)
            Next
            lista.Add(new_instance(diccionario))
        Next
        Return lista
    End Function

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim venta = cast(value)
        ' DOC: determina si existe el vendedor en la BD, según PK

        If venta._id > 0 Then
            Dim sql = "SELECT TOP 1 idventa FROM ventas WHERE idventa=" & venta._id
            Dim response = db.consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Private Function cast(value As ObjetoVO) As VentaVO
        If TypeOf value Is VentaVO Then
            Return value
        Else
            Throw New System.Exception("Error: ventaDAO solo admite objetos ventaVO")
        End If
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "fecha_venta", ._name = "Fecha de venta", ._maskType = Campo.MaskType.fecha,
                                   ._required = True})
        campos.Add(New Campo With {._id = "nroComprobante", ._name = "Nro Comprobante", ._visible = True, ._numeric = True})
        campos.Add(New Campo With {._id = "cliente", ._name = "Cliente", ._maskType = Campo.MaskType.comboBox,
                                   ._objetoDAO = New ClienteDAO, ._required = True})
        campos.Add(New Campo With {._id = "vendedor", ._name = "Vendedor", ._maskType = Campo.MaskType.comboBox,
                                   ._objetoDAO = New VendedorDAO, ._required = True})
        campos.Add(New Campo With {._id = "detalles", ._name = "Detalle", ._maskType = Campo.MaskType.campo,
                                   ._campo = get_detalle_campo()
        })
        Return New ControlGenerico(campos, Me)
    End Function

    Private Function get_detalle_campo() As ObjetoCampo
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id_venta", ._visible = False})
        campos.Add(New Campo With {._id = "producto", ._name = "Producto", ._maskType = Campo.MaskType.comboBox,
                                   ._objetoDAO = New ProductoDAO, ._required = True})
        campos.Add(New Campo With {._id = "costo", ._name = "Costo", ._required = True, ._numeric = True})
        campos.Add(New Campo With {._id = "cantidad", ._name = "Cantidad", ._required = True, ._numeric = True})
        Dim detalle As New DetalleVentaDAO
        Return New ControlYGrilla(New ControlGenerico(campos, detalle), detalle.get_IU_grilla)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "ID", ._numeric = True})
        campos.Add(New Campo With {._id = "fecha_venta", ._name = "Fecha de venta"})
        campos.Add(New Campo With {._id = "cliente", ._name = "Cliente"})
        campos.Add(New Campo With {._id = "vendedor", ._name = "Vendedor"})
        campos.Add(New Campo With {._id = "detalles", ._name = "Detalle", ._visible = False})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Dim venta As New VentaVO With {
            ._id = valores("id"),
            ._fecha_venta = valores("fecha_venta"),
            ._nro_comprobante = valores("nroComprobante")
        }

        If valores.ContainsKey("cliente") Then
            venta._cliente = valores("cliente")
        Else
            With New ClienteDAO
                venta._cliente = .search_by_id(valores("nroCliente"))
            End With
        End If

        If valores.ContainsKey("vendedor") Then
            venta._vendedor = valores("vendedor")
        Else
            With New VendedorDAO
                venta._vendedor = .search_by_id(valores("id_vendedor"))
            End With
        End If

        If TypeOf valores("detalles") Is List(Of ObjetoVO) Then
            venta.detalle = valores("detalles")
        Else
            Throw New System.Exception("El valor no es del tipo esperado.")
        End If

        Return venta
    End Function
End Class
