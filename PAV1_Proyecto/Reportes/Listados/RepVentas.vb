Public Class RepVentas
    Private Sub RepVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "cliente", ._name = "Cliente", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New ClienteDAO})
        ctrl_list.Add(New Campo With {._id = "fecha_desde", ._name = "Desde", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "vendedor", ._name = "Vendedor", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New VendedorDAO})
        ctrl_list.Add(New Campo With {._id = "fecha_hasta", ._name = "Hasta", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "monto_min", ._name = "Monto Min.", ._numeric = True})
        ctrl_list.Add(New Campo With {._id = "nro_comprobante", ._name = "Nro Comprobante"})
        ctrl_list.Add(New Campo With {._id = "monto_max", ._name = "Monto Max.", ._numeric = True})

        For Each campo In ctrl_list
            panel_control.Controls.Add(campo.get_UserControl)
        Next

        buscar()
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        buscar()
    End Sub

    Private Sub buscar()
        Dim db = DataBase.getInstance()
        Dim filtros As New Dictionary(Of String, Object)
        For Each campo As ObjetoCampo In panel_control.Controls
            filtros(campo._id) = campo._value
        Next

        Dim sql = "SELECT vta.idVenta, c.nombre as nombre_cliente, ven.nombre as nombre_vendedor, "
        sql &= " convert(char(10), vta.fechaVenta, 103) as fecha_venta, vta.nroComprobante as nro_comprobante, "
        sql &= " SUM(dv.cantidad * dv.precio) as monto"
        sql &= " FROM ventas vta "
        sql &= " JOIN clientes c ON vta.nroCliente = c.nroCliente"
        sql &= " JOIN vendedores ven ON vta.idVendedor = ven.idVendedor"
        sql &= " JOIN detalleVentas dv ON vta.idVenta = dv.idVenta"
        Dim hay_where = False
        If Not filtros("cliente") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("cliente"), ClienteVO)
                sql &= " vta.nroCliente=" & ._nro
            End With
            hay_where = True
        End If
        If Not filtros("vendedor") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("vendedor"), VendedorVO)
                sql &= " vta.idVendedor=" & ._id
            End With
            hay_where = True
        End If
        If Not filtros("fecha_desde") = "/  /" Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " vta.fechaVenta >= convert(date,'" & filtros("fecha_desde") & "', 103) "
            hay_where = True
        End If
        If Not filtros("fecha_hasta") = "/  /" Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " vta.fechaVenta <= convert(date,'" & filtros("fecha_hasta") & "', 103) "
            hay_where = True
        End If
        If Not filtros("nro_comprobante") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " vta.nroComprobante LIKE '%" & filtros("nro_comprobante") & "%' "
            hay_where = True
        End If
        sql &= " GROUP BY vta.idVenta, c.nombre, ven.nombre, vta.fechaVenta, vta.nroComprobante "
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
        Dim keys = {"idVenta", "nombre_cliente", "nombre_vendedor", "fecha_venta", "monto", "nro_comprobante"}
        For Each row As DataRow In response.Rows
            currentRow = grid_datos.Rows.Add()
            For Each key In keys
                grid_datos.Rows(currentRow).Cells(key).Value = row(key)
            Next

        Next

        lbl_resultados.Text = response.Rows.Count & " resultados"

    End Sub

    Private Sub repVentas_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

End Class