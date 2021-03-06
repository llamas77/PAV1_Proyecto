﻿Public Class RepVendedores

    Private Sub RepVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "nombre", ._name = "Nombre"})
        ctrl_list.Add(New Campo With {._id = "fecha_desde", ._name = "Ventas desde", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "apellido", ._name = "Apellido"})
        ctrl_list.Add(New Campo With {._id = "fecha_hasta", ._name = "Ventas hasta", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "monto_min", ._name = "Monto Ventas Min.", ._numeric = True})
        ctrl_list.Add(New Campo With {._id = "direccion", ._name = "Direccion"})
        ctrl_list.Add(New Campo With {._id = "monto_max", ._name = "Monto Ventas Max.", ._numeric = True})

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

        Dim sql = "SELECT v.idVendedor, v.nombre, v.apellido, v.direccion, v.telefono, v.comision * 100 as comision, "
        sql &= " ISNULL(SUM(dv.cantidad * dv.precio),0) as monto_ventas "
        sql &= " FROM vendedores v "
        sql &= " LEFT JOIN ventas vta ON v.idVendedor = vta.idVendedor"
        sql &= " LEFT JOIN detalleVentas dv ON vta.idVenta = dv.idVenta"

        Dim hay_where = False
        If Not filtros("nombre") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " v.nombre LIKE '%" & filtros("nombre") & "%' "
            hay_where = True
        End If
        If Not filtros("apellido") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " v.apellido LIKE '%" & filtros("apellido") & "%' "
            hay_where = True
        End If
        If Not filtros("direccion") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " v.direccion LIKE '%" & filtros("direccion") & "%' "
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
        sql &= " GROUP BY v.idVendedor, v.nombre, v.apellido, v.direccion, v.telefono, v.comision"
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
        Dim keys = {"idVendedor", "nombre", "apellido", "direccion", "telefono", "monto_ventas"}
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

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage


        Dim argumentosImpresion As New PaintEventArgs(e.Graphics, New Rectangle(New Point(0, 0), grid_datos.Size))
        Me.InvokePaint(grid_datos, argumentosImpresion)
    End Sub


    Private Sub btn_imprimir_Click_1(sender As Object, e As EventArgs) Handles btn_imprimir.Click
        PrintDocument1.Print()
    End Sub

    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click
        For Each campo As Control In panel_control.Controls
            campo.ResetText()
        Next
    End Sub
End Class