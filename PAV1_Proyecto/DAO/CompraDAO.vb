﻿Imports PAV1_Proyecto

Public Class CompraDAO
    Implements ObjetoDAO, ObjectFactory, ICanDAO

    Public Sub insert(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.insert
        Dim compra = cast(value)

        ' -- Seteo
        Dim sql_insertar As String
        sql_insertar = "INSERT INTO compras (fechaCompra, idProveedor)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "convert(date, '" & compra._fecha_compra & "', 103), "
        sql_insertar &= compra._proveedor._id & ") "
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.

        ' -- Ejecucion
        If db Is Nothing Then
            db = New DataBase
            db.conectar()
            db.iniciar_transaccion()
        ElseIf db._estado = DataBase.Estado.listo Then
            db.iniciar_transaccion()
        End If

        Dim tabla = db.consulta_sql(sql_insertar) ' Compra
        compra._id = tabla(0)(0)
        Dim detalleDAO As New DetalleCompraDAO
        Dim productoDAO As New ProductoDAO
        Dim productoVO As ProductoVO
        Dim detalles = compra.detalle.Cast(Of DetalleCompraVO)
        For Each detalle As DetalleCompraVO In detalles
            detalle.id_compra = compra._id
            detalleDAO.insert(detalle, db) ' Detalle
            productoVO = productoDAO.search_code(db, detalle.codigo_producto)
            If productoVO Is Nothing Then
                db.cancelar_transaccion()
                Throw New System.Exception("El Codigo de Producto no existe.")
            End If
            productoVO._stock += detalle.cantidad
            If productoVO._fechaLista < compra._fecha_compra Then
                productoVO._costo = detalle.costo
                productoVO._fechaLista = compra._fecha_compra
            End If
            productoDAO.update(productoVO, db) ' Stock Producto
        Next

        db.cerrar_transaccion()
        db.desconectar()
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        Dim compra = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE compras"
        sql_update &= " SET "
        sql_update &= "fechaCompra=convert(date, '" & compra._fecha_compra & "', 103), "
        sql_update &= "idProveedor=" & compra._proveedor._id
        sql_update &= " WHERE idCompra=" & compra._id

        If db Is Nothing Then
            db = New DataBase
            db.conectar()
            db.iniciar_transaccion()
        ElseIf db._estado = DataBase.Estado.listo Then
            db.iniciar_transaccion()
        End If

        db.ejecuta_sql(sql_update)
        Dim detalleDAO As New DetalleCompraDAO
        Dim detalles_guardados = detalleDAO.all_from_compra(compra._id)

        Dim detalles = compra.detalle.Cast(Of DetalleCompraVO)
        For Each detalle In detalles
            If detalle.id_compra <> compra._id Then ' Nuevo Detalle
                If detalle.id_compra = 0 Then
                    detalle.id_compra = compra._id
                    detalleDAO.insert(detalle, db)
                Else
                    db.cancelar_transaccion()
                    Throw New System.Exception("El ID del detalle pertenece a otra compra.")
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
        Dim compra = cast(value)

        Dim sql_delete = "DELETE FROM compras" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idCompra=" & compra._id

        If db Is Nothing Then
            db = New DataBase
            db.conectar()
            db.iniciar_transaccion()
        ElseIf db._estado = DataBase.Estado.listo Then
            db.iniciar_transaccion()
        End If

        Dim detalleDAO As New DetalleCompraDAO
        Dim detalles = compra.detalle.Cast(Of DetalleCompraVO)
        For Each detalle In detalles
            If detalle.id_compra <> compra._id Then
                db.cancelar_transaccion()
                Throw New System.Exception("El ID del detalle es distinto del de la compra.")
            End If
            detalleDAO.delete(detalle, db)
        Next
        db.ejecuta_sql(sql_delete)
        db.cerrar_transaccion()
        db.desconectar()

        compra._id = 0
    End Sub

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim dataSet As New GrillaCompras
        Dim dataTable As DataTable = dataSet.compras

        Dim sql_select = "SELECT c.idCompra, convert(char(10), c.fechaCompra, 103) as fecha_compra, "
        sql_select &= " p.idProveedor, p.razonSocial, p.cuit, p.domicilio, p.telefono, p.email"
        sql_select &= " FROM compras c JOIN proveedores p ON c.idProveedor=p.idProveedor"
        Dim compras = db.consulta_sql(sql_select)

        ' Formatea el resultado para adaptarse al DataSet
        ' NOTA: Por alguna razon, si se produce una excepcion en el for, no avisa.
        For Each compra As DataRow In compras.Rows
            Dim row = dataTable.Rows.Add()
            row("id") = compra("idCompra")
            row("fecha_compra") = compra("fecha_compra")
            row("proveedor") = New ProveedorVO With {
                ._id = compra("idProveedor"),
                ._cuit = compra("cuit"),
                ._domicilio = compra("domicilio"),
                ._email = compra("email"),
                ._razonSocial = compra("razonSocial"),
                ._telefono = compra("telefono")
            }
            With New DetalleCompraDAO
                row("detalles") = .all_from_compra(compra("idCompra"))
            End With
        Next

        Return dataTable_to_List(dataTable)
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"id", "fecha_compra", "proveedor", "detalles"}
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
        Dim compra = cast(value)
        ' DOC: determina si existe el vendedor en la BD, según PK

        If compra._id > 0 Then
            Dim sql = "SELECT TOP 1 idCompra FROM compras WHERE idCompra=" & compra._id
            Dim response = db.consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Private Function cast(value As ObjetoVO) As CompraVO
        If TypeOf value Is CompraVO Then
            Return value
        Else
            Throw New System.Exception("Error: CompraDAO solo admite objetos CompraVO")
        End If
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "fecha_compra", ._name = "Fecha de Compra", ._maskType = Campo.MaskType.fecha,
                                   ._required = True})
        campos.Add(New Campo With {._id = "proveedor", ._name = "Proveedor", ._maskType = Campo.MaskType.comboBox,
                                   ._objetoDAO = New ProveedorDAO, ._required = True})
        campos.Add(New Campo With {._id = "detalles", ._name = "Detalle", ._maskType = Campo.MaskType.campo,
                                   ._campo = get_detalle_campo()
        })
        Return New ControlGenerico(campos, Me)
    End Function

    Private Function get_detalle_campo() As ObjetoCampo
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id_compra", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "producto", ._name = "Producto", ._maskType = Campo.MaskType.comboBox,
                                   ._objetoDAO = New ProductoDAO, ._required = True})
        campos.Add(New Campo With {._id = "costo", ._name = "Costo", ._required = True, ._numeric = True})
        campos.Add(New Campo With {._id = "cantidad", ._name = "Cantidad", ._required = True, ._numeric = True})
        Dim detalle As New DetalleCompraDAO
        Return New ControlYGrilla(New ControlGenerico(campos, detalle), detalle.get_IU_grilla)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "ID", ._numeric = True})
        campos.Add(New Campo With {._id = "fecha_compra", ._name = "Fecha de Compra"})
        campos.Add(New Campo With {._id = "proveedor", ._name = "Proveedor"})
        campos.Add(New Campo With {._id = "detalles", ._name = "Detalle", ._visible = False})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Dim compra As New CompraVO With {
            ._id = valores("id"),
            ._fecha_compra = valores("fecha_compra")
        }

        If valores.ContainsKey("proveedor") Then
            compra._proveedor = valores("proveedor")
        Else
            With New ProveedorDAO
                compra._proveedor = .search_by_id(valores("id_proveedor"))
            End With
        End If

        If TypeOf valores("detalles") Is List(Of ObjetoVO) Then
            compra.detalle = valores("detalles")
        Else
            Throw New System.Exception("El valor no es del tipo esperado.")
        End If

        Return compra
    End Function

    Public Function can_insert(value As ObjetoVO) As String Implements ICanDAO.can_insert
        Dim compra = cast(value)

        If compra.detalle.Count = 0 Then
            Return "La compra debe incluir al menos un producto en su detalle."
        End If

        Dim errMsg As String
        Dim detalleDAO As New DetalleCompraDAO
        For Each detalle In compra.detalle
            errMsg = detalleDAO.can_insert(detalle)
            If Not errMsg Is Nothing Then
                Return errMsg
            End If
        Next
        Return Nothing
    End Function

    Public Function can_update(value As ObjetoVO) As String Implements ICanDAO.can_update
        Dim compra = cast(value)

        If compra.detalle.Count = 0 Then
            Return "La compra debe incluir al menos un producto en su detalle."
        End If

        Dim errMsg As String
        Dim detalleDAO As New DetalleCompraDAO
        Dim detalles_guardados = detalleDAO.all_from_compra(compra._id)

        Dim detalles = compra.detalle.Cast(Of DetalleVentaVO)
        For Each detalle In detalles
            If detalle.id_venta <> compra._id Then ' Nuevo Detalle
                If detalle.id_venta = 0 Then
                    errMsg = detalleDAO.can_insert(detalle)
                Else
                    Throw New System.Exception("El ID del detalle pertenece a otra compra.")
                End If
            Else ' Actualiza Detalle
                errMsg = detalleDAO.can_insert(detalle)
            End If
            detalles_guardados.Remove(detalle)
            If Not errMsg Is Nothing Then
                Return errMsg
            End If
        Next
        For Each detalleG In detalles_guardados ' Los detalles que quedaron guardados pero el usuario borro.
            errMsg = detalleDAO.can_delete(detalleG)
            If Not errMsg Is Nothing Then
                Return errMsg
            End If
        Next

        Return Nothing
    End Function

    Public Function can_delete(value As ObjetoVO) As String Implements ICanDAO.can_delete
        Dim compra = cast(value)
        Dim errMsg As String
        Dim detalleDAO As New DetalleCompraDAO
        For Each detalle In compra.detalle
            errMsg = detalleDAO.can_delete(detalle)
            If Not errMsg Is Nothing Then
                Return errMsg
            End If
        Next
        Return Nothing
    End Function
End Class
