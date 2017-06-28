Public Class RepProveedores
    Private Sub RepVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "razon_social", ._name = "Razon Social"})
        ctrl_list.Add(New Campo With {._id = "domicilio", ._name = "Domicilio"})
        ctrl_list.Add(New Campo With {._id = "fecha_desde", ._name = "Compras desde", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "fecha_hasta", ._name = "Compras hasta", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "monto_min", ._name = "Monto Compras Min.", ._numeric = True})
        ctrl_list.Add(New Campo With {._id = "monto_max", ._name = "Monto Compras Max.", ._numeric = True})

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

        Dim sql = "SELECT p.razonSocial as razon_social, p.domicilio, p.telefono, p.email, "
        sql &= " SUM(dc.cantidad * dc.costo) as monto_compras "
        sql &= " FROM proveedores p "
        sql &= " JOIN compras c ON c.idProveedor = p.idProveedor"
        sql &= " JOIN detalle_compras dc ON c.idCompra = dc.idCompra"

        Dim hay_where = False
        If Not filtros("razon_social") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.razonSocial LIKE '%" & filtros("razon_social") & "%' "
            hay_where = True
        End If
        If Not filtros("domicilio") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.domicilio LIKE '%" & filtros("domicilio") & "%' "
            hay_where = True
        End If
        If Not filtros("fecha_desde") = "/  /" Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " c.fechaCompra >= convert(date,'" & filtros("fecha_desde") & "', 103) "
            hay_where = True
        End If
        If Not filtros("fecha_hasta") = "/  /" Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " c.fechaCompra <= convert(date,'" & filtros("fecha_hasta") & "', 103) "
            hay_where = True
        End If
        sql &= " GROUP BY p.razonSocial, p.domicilio, p.telefono, p.email"
        Dim hay_having = False
        If filtros("monto_min") <> 0 Then
            sql &= IIf(hay_having, " AND ", " HAVING ")
            sql &= " SUM(dc.cantidad * dc.costo) >= " & filtros("monto_min")
            hay_having = True
        End If
        If filtros("monto_max") <> 0 Then
            sql &= IIf(hay_having, " AND ", " HAVING ")
            sql &= " SUM(dc.cantidad * dc.costo) <= " & filtros("monto_max")
            hay_having = True
        End If
        Dim response = db.consulta_sql(sql)

        grid_datos.Rows.Clear()
        Dim currentRow As Integer
        Dim keys = {"razon_social", "domicilio", "telefono", "email", "monto_compras"}
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
End Class