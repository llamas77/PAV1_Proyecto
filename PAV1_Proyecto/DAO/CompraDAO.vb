Imports PAV1_Proyecto

Public Class CompraDAO
    Implements ObjetoDAO, ObjectFactory

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Dim compra = cast(value)

        ' -- Seteo
        Dim sql_insertar As String
        sql_insertar = "INSERT INTO compras (fechaCompra, idProveedor)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "convert(date, '" & compra.fecha_compra & "', 103), "
        sql_insertar &= compra.id_proveedor & ") "
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.

        ' -- Ejecucion
        Dim db As New DataBase
        db.conectar()
        db.iniciar_transaccion()

        Dim tabla = db.consulta_sql(sql_insertar) ' Compra
        compra.id = tabla(0)(0)
        Dim detalleDAO As New DetalleCompraDAO
        Dim productoDAO As New ProductoDAO
        Dim productoVO As ProductoVO
        For Each detalle In compra.detalle
            detalle.id_compra = compra.id
            detalleDAO.insert_in(db, detalle) ' Detalle
            productoVO = productoDAO.search_code(db, detalle.codigo_producto)
            If productoVO Is Nothing Then
                db.cancelar_transaccion()
                Throw New System.Exception("El Codigo de Producto no existe.")
            End If
            productoVO._stock += detalle.cantidad
            If productoVO._fechaLista < compra.fecha_compra Then
                productoVO._costo = detalle.costo
                productoVO._fechaLista = compra.fecha_compra
            End If
            productoDAO.update_in(db, productoVO) ' Stock Producto
        Next

        db.cerrar_transaccion()
        db.desconectar()
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Dim compra = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE compras"
        sql_update &= " SET "
        sql_update &= "fechaCompra=convert(date, '" & compra.fecha_compra & "', 103)), "
        sql_update &= "idProveedor=" & compra.id_proveedor
        sql_update &= " WHERE idCompra=" & compra.id

        Dim db As New DataBase
        db.conectar()
        db.iniciar_transaccion()
        db.ejecuta_sql(sql_update)

        Dim detalleDAO As New DetalleCompraDAO
        For Each detalle In compra.detalle
            If detalle.id_compra <> compra.id Then
                db.cancelar_transaccion()
                Throw New System.Exception("El ID del detalle es distinto del de la compra.")
            End If

            detalleDAO.update_in(db, detalle)
        Next
        db.cerrar_transaccion()
        db.desconectar()
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Dim compra = cast(value)

        Dim sql_delete = "DELETE FROM compras" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idCompra=" & compra.id

        Dim db As New DataBase
        db.conectar()
        db.iniciar_transaccion()

        Dim detalleDAO As New DetalleCompraDAO
        For Each detalle In compra.detalle
            If detalle.id_compra <> compra.id Then
                db.cancelar_transaccion()
                Throw New System.Exception("El ID del detalle es distinto del de la compra.")
            End If
            detalleDAO.delete_in(db, detalle)
        Next
        db.ejecuta_sql(sql_delete)
        db.cerrar_transaccion()
        db.desconectar()

        compra.id = 0
    End Sub

    Public Function all() As DataTable Implements ObjetoDAO.all
        Dim dataSet As New GrillaCompras
        Dim dataTable As DataTable = dataSet.compras

        Dim sql_select = "SELECT idCompra as id, convert(char(10), fechaCompra, 103) as fecha_compra, "
        sql_select &= " idProveedor as id_proveedor"
        sql_select &= " FROM compras"
        Dim compras = DataBase.getInstance().consulta_sql(sql_select)
        Dim detalle As New DetalleCompraDAO

        Dim detalles As New DataTable
        detalles.Columns.Add()
        detalles.Columns(0).ColumnName = "detalle"

        For Each compra As DataRow In compras.Rows
            dataTable.Rows.Add()
            Dim last_row = dataTable.Rows(dataTable.Rows.Count - 1)
            last_row("id") = compra("id")
            last_row("fecha_compra") = compra("fecha_compra")
            last_row("id_proveedor") = compra("id_proveedor")
            last_row("detalle") = detalle.all_from_compra(compra("id"))
        Next

        Return dataTable
    End Function

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Dim compra = cast(value)
        ' DOC: determina si existe el vendedor en la BD, según PK

        If compra.id > 0 Then
            Dim sql = "SELECT TOP 1 idCompra FROM compras WHERE idCompra=" & compra.id
            Dim response = DataBase.getInstance().consulta_sql(sql)
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
        Dim compra As New CompraVO With {
            .id = valores("id"),
            .fecha_compra = valores("fecha_compra"),
            .id_proveedor = valores("id_proveedor")
        }

        If TypeOf valores("detalle") Is List(Of ObjetoVO) _
            Or TypeOf valores("detalle") Is List(Of DetalleCompraVO) Then

            Dim lista As New List(Of DetalleCompraVO)
            For Each objeto In valores("detalle")
                lista.Add(DirectCast(objeto, DetalleCompraVO))
            Next
            compra.detalle = lista
        Else
            Throw New System.Exception("El valor no es del tipo esperado.")
        End If

        Return compra
    End Function
End Class
