Public Class RepClientes
    Private Sub RepVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "nombre", ._name = "Nombre"})
        ctrl_list.Add(New Campo With {._id = "apellido", ._name = "Apellido"})
        ctrl_list.Add(New Campo With {._id = "direccion", ._name = "Direccion"})

        ctrl_list.Add(New Campo With {._id = "tipo", ._name = "Tipo de Cliente", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New TipoClienteDAO})
        ctrl_list.Add(New Campo With {._id = "fecha_desde", ._name = "Compras desde", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "monto_min", ._name = "Monto Ventas Min.", ._numeric = True})
        ctrl_list.Add(New Campo With {._id = "fecha_hasta", ._name = "Compras Hasta", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "monto_max", ._name = "Monto Ventas Max.", ._numeric = True})
        ctrl_list.Add(New Campo With {._id = "vendedor", ._name = "Vendedor", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New VendedorDAO})

        For Each campo In ctrl_list
            panel_control.Controls.Add(campo.get_UserControl)
        Next
        buscar()
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        buscar()
    End Sub
    Private Function validar_filtros() As Boolean
        Dim valido = True
        For Each campo As Validable In panel_control.Controls
            valido = IIf(campo.is_valid, valido, False)
        Next
        Return valido
    End Function
    Private Sub buscar()
        If Not validar_filtros() Then
            MsgBox("Algun/os campos de filtro son invalidos.")
            Exit Sub
        End If
        Dim db = DataBase.getInstance()
        Dim filtros As New Dictionary(Of String, Object)
        For Each campo As ObjetoCampo In panel_control.Controls
            filtros(campo._id) = campo._value
        Next

        Dim sql = "SELECT c.nroCliente, c.nombre, c.apellido, c.direccion, c.telefono, "
        'Si no hay ventas la suma es NULL y se reemplaza por 0
        sql &= " tc.nombre as nombre_tipo, ISNULL(SUM(dv.cantidad * dv.precio), 0) as monto_ventas "
        sql &= " FROM clientes c "
        sql &= " JOIN tipos_cliente tc ON c.idTipoCliente = tc.idTipo"
        sql &= " LEFT JOIN ventas v ON c.nroCliente = v.nroCliente"
        sql &= " LEFT JOIN detalleVentas dv ON v.idVenta = dv.idVenta"

        Dim hay_where = False
        If Not filtros("nombre") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " c.nombre LIKE '%" & filtros("nombre") & "%' "
            hay_where = True
        End If
        If Not filtros("apellido") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " c.apellido LIKE '%" & filtros("apellido") & "%' "
            hay_where = True
        End If
        If Not filtros("direccion") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " c.direccion LIKE '%" & filtros("direccion") & "%' "
            hay_where = True
        End If
        If Not filtros("tipo") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("tipo"), TipoClienteVO)
                sql &= " c.idTipoCliente=" & ._id
            End With
            hay_where = True
        End If
        If Not filtros("vendedor") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("vendedor"), VendedorVO)
                sql &= " EXISTS (SELECT TOP 1 0 FROM ventas v2"
                sql &= " WHERE v2.idVendedor=" & ._id & ")"
            End With
            hay_where = True
        End If
        If Not filtros("fecha_desde") = "/  /" Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " v.fechaVenta >= convert(date,'" & filtros("fecha_desde") & "', 103) "
            hay_where = True
        End If
        If Not filtros("fecha_hasta") = "/  /" Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " v.fechaVenta <= convert(date,'" & filtros("fecha_hasta") & "', 103) "
            hay_where = True
        End If
        sql &= " GROUP BY c.nroCliente, c.nombre, c.apellido, c.direccion, c.telefono, tc.nombre"
        Dim hay_having = False
        If filtros("monto_min") <> 0 Then
            sql &= IIf(hay_having, " AND ", " HAVING ")
            sql &= " SUM(dv.cantidad * dv.precio) >= " & filtros("monto_min")
            hay_having = True
        End If
        If filtros("monto_max") <> 0 Then
            sql &= IIf(hay_having, " AND ", " HAVING ")
            sql &= " SUM(dv.cantidad * dv.precio) <= " & filtros("monto_max")
            hay_having = True
        End If
        Dim response = db.consulta_sql(sql)

        grid_datos.Rows.Clear()
        Dim currentRow As Integer
        Dim keys = {"nroCliente", "nombre", "apellido", "direccion", "telefono", "nombre_tipo", "monto_ventas"}
        For Each row As DataRow In response.Rows
            currentRow = grid_datos.Rows.Add()
            For Each key In keys
                grid_datos.Rows(currentRow).Cells(key).Value = row(key)
            Next

        Next

        lbl_resultados.Text = response.Rows.Count & " resultados"

    End Sub

    Private Sub repCompras_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click
        For Each campo As Control In panel_control.Controls
            campo.ResetText()
        Next
    End Sub
End Class