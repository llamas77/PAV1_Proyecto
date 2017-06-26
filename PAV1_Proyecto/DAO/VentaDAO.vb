Imports PAV1_Proyecto

Public Class ventaDAO
    Implements ObjetoDAO, ObjectFactory, ICanDAO

    Public Sub insert(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.insert
        Dim venta = cast(value)

        ' -- Seteo
        Dim sql_insertar As String
        sql_insertar = "INSERT INTO ventas (nroCliente, idVendedor, fechaVenta, nroComprobante)"
        sql_insertar &= " VALUES ("
        sql_insertar &= venta._cliente._nro & ", "
        sql_insertar &= venta._vendedor._id & ", "
        sql_insertar &= "convert(date, '" & venta._fecha_venta & "', 103), "
        sql_insertar &= "'" & venta._nro_comprobante & "') " ' Nro Comprobante es en realidad un String (admite guiones)
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.

        ' -- Ejecucion
        If db Is Nothing Then
            db = New DataBase
            db.conectar()
            db.iniciar_transaccion()
        ElseIf db._estado = DataBase.Estado.listo Then
            db.iniciar_transaccion()
        End If

        Dim tabla = db.consulta_sql(sql_insertar) ' Inserta venta
        venta._id = tabla(0)(0)


        Dim detalleDAO As New DetalleVentaDAO
        Dim productoDAO As New ProductoDAO
        Dim productoVO As ProductoVO

        Dim detalles = venta.detalle.Cast(Of DetalleVentaVO)
        For Each detalle As DetalleVentaVO In detalles
            detalle.id_venta = venta._id
            detalleDAO.insert(detalle, db) ' Inserta Detalle
            ' TODO: Mover responsabilidad de actualizar producto al detalle.
            productoVO = productoDAO.search_code(db, detalle.codigo_producto)
            If productoVO Is Nothing Then
                db.cancelar_transaccion()
                Throw New System.Exception("El Codigo de Producto no existe.")
            End If
            productoVO._stock += detalle.cantidad
            If productoVO._fechaLista < venta._fecha_venta Then
                productoVO._costo = detalle.precio
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
        sql_update &= " nroCliente=" & venta._cliente._nro & ", "
        sql_update &= " idVendedor=" & venta._vendedor._id & ", "
        sql_update &= " fechaventa=convert(date, '" & venta._fecha_venta & "', 103), "
        sql_update &= " nroComprobante='" & venta._nro_comprobante & "'"
        sql_update &= " WHERE idVenta=" & venta._id

        If db Is Nothing Then
            db = New DataBase
            db.conectar()
            db.iniciar_transaccion()
        ElseIf db._estado = DataBase.Estado.listo Then
            db.iniciar_transaccion()
        End If

        db.ejecuta_sql(sql_update) ' Actualiza Venta
        ' ----------
        Dim detalleDAO As New DetalleVentaDAO
        Dim detalles_guardados = detalleDAO.all_from_venta(venta._id)

        Dim detalles = venta.detalle.Cast(Of DetalleVentaVO)
        For Each detalle In detalles
            If detalle.id_venta <> venta._id Then ' Nuevo Detalle
                If detalle.id_venta = 0 Then
                    detalle.id_venta = venta._id
                    detalleDAO.insert(detalle, db)
                Else
                    db.cancelar_transaccion()
                    Throw New System.Exception("El ID del detalle pertenece a otra venta.")
                End If
            Else ' Actualiza Detalle
                detalleDAO.update(detalle, db)
            End If
            detalles_guardados.Remove(detalle)
        Next
        For Each detalleG In detalles_guardados ' Los detalles que quedaron guardados pero el usuario borro.
            detalleDAO.delete(detalleG, db)
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
        Dim dataSet As New GrillaVentas
        Dim dataTable As DataTable = dataSet._grillaVentas

        Dim sql_select = "SELECT v.idVenta, convert(char(10), v.fechaVenta, 103) as fechaventa, v.nroComprobante, "
        sql_select &= "c.nroCliente, c.nombre as nombreCliente, c.apellido as apellidoCliente,c.direccion as direccionCliente, "
        sql_select &= "c.telefono as telCliente, c.idTipoCliente, ven.idVendedor, ven.nombre as nombreVendedor, "
        sql_select &= "ven.apellido as apellidoVendedor, ven.direccion as direccionVendedor,ven.telefono as telVendedor, ven.comision "
        sql_select &= "FROM ventas v JOIN clientes c ON v.nroCliente= c.nroCliente "
        sql_select &= "JOIN vendedores ven ON v.idVendedor = ven.idVendedor"
        Dim ventas = db.consulta_sql(sql_select)

        ' Formatea el resultado para adaptarse al DataSet
        ' NOTA: Por alguna razon, si se produce una excepcion en el for, no avisa.
        Try
            Dim tipoCliente As TipoClienteVO = Nothing
            For Each venta As DataRow In ventas.Rows
                Dim row = dataTable.Rows.Add()
                row("id") = venta("idventa")
                row("fechaventa") = venta("fechaventa")
                With New TipoClienteDAO
                    tipoCliente = .search_by_id(venta("idTipoCliente"))
                End With
                row("cliente") = New ClienteVO With {
                    ._nro = venta("nroCliente"),
                    ._nombre = venta("nombreCliente"),
                    ._apellido = venta("apellidoCliente"),
                    ._direccion = venta("direccionCliente"),
                    ._telefono = venta("telCliente"),
                    ._tipo_cliente = tipoCliente
                }
                row("vendedor") = New VendedorVO With {
                    ._id = venta("idvendedor"),
                    ._nombre = venta("nombreVendedor"),
                    ._apellido = venta("apellidoVendedor"),
                    ._direccion = venta("direccionVendedor"),
                    ._telefono = venta("telVendedor"),
                    ._porcentaje_comision = venta("comision")
                }
                row("nroComprobante") = venta("nroComprobante")
                With New DetalleVentaDAO
                    row("detalles") = .all_from_venta(venta("idventa"))
                End With
            Next
        Catch ex As Exception
            MsgBox("Error al consultar ventas.")
        End Try

        Return dataTable_to_List(dataTable)
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"id", "fechaventa", "nroComprobante", "cliente", "vendedor", "detalles"}
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
        campos.Add(New Campo With {._id = "fechaventa", ._name = "Fecha de venta", ._maskType = Campo.MaskType.fecha,
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
        campos.Add(New Campo With {._id = "precio", ._name = "Precio", ._required = True, ._numeric = True})
        campos.Add(New Campo With {._id = "cantidad", ._name = "Cantidad", ._required = True, ._numeric = True})
        Dim detalle As New DetalleVentaDAO
        Return New ControlYGrilla(New ControlGenerico(campos, detalle), detalle.get_IU_grilla)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "ID", ._numeric = True})
        campos.Add(New Campo With {._id = "fechaventa", ._name = "Fecha de venta"})
        campos.Add(New Campo With {._id = "cliente", ._name = "Cliente"})
        campos.Add(New Campo With {._id = "vendedor", ._name = "Vendedor"})
        campos.Add(New Campo With {._id = "nroComprobante", ._name = "Nro Comprobante", ._visible = False})
        campos.Add(New Campo With {._id = "detalles", ._name = "Detalle", ._visible = False})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Dim venta As New VentaVO With {
            ._id = valores("id")
        }

        If valores.ContainsKey("nroComprobante") Then
            venta._nro_comprobante = valores("nroComprobante")
        End If

        If valores.ContainsKey("fechaventa") Then
            venta._fecha_venta = valores("fechaventa")
        End If

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

    Public Function can_insert(value As ObjetoVO) As String Implements ICanDAO.can_insert
        ' TODO: Invocar can_insert en los detalles.
        Dim venta = cast(value)
        If venta._id <> 0 Then
            Return "Para insertar una venta el ID debe ser 0. [id=" & venta._id & "]"
        End If

        If venta._fecha_venta Is Nothing Then
            Return "La venta no tiene fecha."
            ' TODO: Validar que la fecha de venta no sea superior al día actual.
        End If

        If Len(venta._nro_comprobante) > 20 Then
            Return "El numero de comprobante es demasiado largo."
        End If

        If venta._cliente Is Nothing Then
            Return "No hay ningun Cliente seleccionado."
        Else
            With New ClienteDAO
                If Not .exists(venta._cliente) Then
                    Return "El cliente seleccionado no existe."
                End If
            End With
        End If

        If venta._vendedor Is Nothing Then
            Return "No hay ningun Vendedor seleccionado."
        Else
            With New VendedorDAO
                If Not .exists(venta._vendedor) Then
                    Return "El vendedor seleccionado no existe."
                End If
            End With
        End If

        Return Nothing
    End Function

    Public Function can_update(value As ObjetoVO) As String Implements ICanDAO.can_update
        ' TODO: Invocar can_update en los detalles.
        Dim venta = cast(value)

        Dim sql As String
        Dim response As DataTable
        Dim db As New DataBase
        db.conectar()

        If venta._id <= 0 Then
            Return "El ID no es válido. [id=" & venta._id & "]"
        Else
            sql = "SELECT TOP 1 idVenta FROM ventas WHERE idventa=" & venta._id
            response = db.consulta_sql(sql)
            If response.Rows.Count < 1 Then
                Return "La venta que se quiere modificar no existe."
            End If
        End If

        If venta._fecha_venta Is Nothing Then
            Return "La venta no tiene fecha."
            ' TODO: Validar que la fecha de venta no sea superior al día actual.
        End If

        If Len(venta._nro_comprobante) > 20 Then
            Return "El numero de comprobante es demasiado largo."
        End If

        If venta._cliente Is Nothing Then
            Return "No hay ningun Cliente seleccionado."
        Else
            With New ClienteDAO
                If Not .exists(venta._cliente) Then
                    Return "El cliente seleccionado no existe."
                End If
            End With
        End If

        If venta._vendedor Is Nothing Then
            Return "No hay ningun Vendedor seleccionado."
        Else
            With New VendedorDAO
                If Not .exists(venta._vendedor) Then
                    Return "El vendedor seleccionado no existe."
                End If
            End With
        End If

        Return Nothing
    End Function

    Public Function can_delete(value As ObjetoVO) As String Implements ICanDAO.can_delete
        ' Solo los detalles de venta apuntan a venta y son borrados en cascada.
        ' Ningun otro objeto tiene FK a venta, siempre es posible borrarlo.
        Return Nothing
    End Function
End Class
