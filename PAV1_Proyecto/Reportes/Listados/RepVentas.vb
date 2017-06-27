Public Class RepVentas
    Private Sub RepVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "cliente", ._name = "Cliente", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New ClienteDAO})
        ctrl_list.Add(New Campo With {._id = "fecha_desde", ._name = "Desde", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "vendedor", ._name = "Vendedor", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New VendedorDAO})
        ctrl_list.Add(New Campo With {._id = "fecha_hasta", ._name = "Hasta", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "nro_comprobante", ._name = "Nro Comprobante"})

        For Each campo In ctrl_list
            panel_control.Controls.Add(campo.get_UserControl)
        Next

    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click

        Dim db = DataBase.getInstance()
        Dim params = {"cliente", "fecha_desde", "fecha_hasta", "vendedor", "nro_comprobante"}
        Dim filtros As New Dictionary(Of String, Object)
        For Each param In params
            filtros.Add(param, Nothing)
        Next
        For Each campo As ObjetoCampo In panel_control.Controls
            filtros(campo._id) = campo._value
        Next

        Dim sql = "SELECT vta.idVenta, c.nombre as nombre_cliente, ven.nombre as nombre_vendedor, "
        sql &= " convert(char(10), vta.fechaVenta, 103) as fecha_venta, vta.nroComprobante as nro_comprobante "
        sql &= " FROM ventas vta "
        sql &= " JOIN clientes c ON vta.nroCliente = c.nroCliente"
        sql &= " JOIN vendedores ven ON vta.idVendedor = ven.idVendedor"
        sql &= " WHERE 1=0 OR " ' Para evitar que falle si no hay ningun filtro activo.
        If Not filtros("cliente") Is Nothing Then
            With DirectCast(filtros("cliente"), ClienteVO)
                sql &= " vta.nroCliente=" & ._nro & " AND "
            End With
        End If
        If Not filtros("vendedor") Is Nothing Then
            With DirectCast(filtros("vendedor"), VendedorVO)
                sql &= " vta.idVendedor=" & ._id & " AND "
            End With
        End If
        If Not filtros("fecha_desde") = "/  /" Then
            sql &= " vta.fechaVenta >= convert(date,'" & filtros("fecha_desde") & "', 103) AND "
        End If
        If Not filtros("fecha_hasta") = "/  /" Then
            sql &= " vta.fechaVenta <= convert(date,'" & filtros("fecha_hasta") & "', 103) AND "
        End If
        If Not filtros("nro_comprobante") Is Nothing Then
            sql &= " vta.nroComprobante LIKE '%" & filtros("nro_comprobante") & "%'"
        End If

        Dim response = db.consulta_sql(sql)

        grid_datos.Rows.Clear()
        Dim currentRow As Integer
        Dim keys = {"idVenta", "nombre_cliente", "nombre_vendedor", "fecha_venta", "nro_comprobante"}
        For Each row As DataRow In response.Rows
            currentRow = grid_datos.Rows.Add()
            For Each key In keys
                grid_datos.Rows(currentRow).Cells(key).Value = row(key)
            Next

        Next

        'MsgBox("Resultados: " & response.Rows.Count)

    End Sub
End Class