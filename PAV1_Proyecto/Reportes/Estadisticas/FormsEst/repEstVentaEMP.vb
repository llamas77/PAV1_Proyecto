Public Class repEstVentaEMP
    Private Sub RepGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "marca", ._name = "Marca", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New MarcaDAO})
        ctrl_list.Add(New Campo With {._id = "modelo", ._name = "Modelo"})
        ctrl_list.Add(New Campo With {._id = "fecha_desde", ._name = "Desde", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "fecha_hasta", ._name = "Hasta", ._maskType = Campo.MaskType.fecha})
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


        Dim sql = "SELECT m.nombre as nombre_marca, e.modelo, ISNULL(SUM(dv.cantidad),0) as cantidad_ventas, ISNULL(SUM(dv.cantidad * dv.precio),0) as monto_ventas "
        sql &= "FROM equipos e "
        sql &= "JOIN marcas m ON e.idMarca = m.idMarca "
        sql &= "LEFT JOIN productosxequipos pxe ON e.id = pxe.idEquipo "
        sql &= "LEFT JOIN productos p ON p.codigoProducto = pxe.codigoProducto "
        sql &= "LEFT JOIN detalleVentas dv ON p.codigoProducto = dv.codigoProducto "
        sql &= "LEFT JOIN ventas v ON dv.idVenta = v.idVenta "


        Dim hay_where = False
        If Not filtros("marca") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("marca"), MarcaVO)
                sql &= " e.idMarca=" & ._id
            End With
            hay_where = True
        End If

        If Not filtros("modelo") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " e.modelo LIKE '%" & filtros("modelo") & "%'"
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

        sql &= "GROUP BY m.nombre, e.modelo"



        'If Not filtros("nombre") Is Nothing Then
        ' sql &= IIf(hay_where, " AND ", " WHERE ")
        ' sql &= " g.nombre LIKE '%" & filtros("nombre") & "%' "
        ' hay_where = True
        ' End If


        Dim response As DataTable = db.consulta_sql(sql)


        ReinitializeViewer("PAV1_Proyecto.repEstVentaEMP.rdlc")
        BindingSource1.DataSource = response
        Me.ReportViewer1.RefreshReport()


    End Sub

    Private Sub repCompras_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub ReinitializeViewer(ByVal tsReport As String)

        Dim ReportDataSourceX = New Microsoft.Reporting.WinForms.ReportDataSource()

        Me.ReportViewer1.Reset()
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = tsReport
        ReportDataSourceX.Name = "DataSet1"
        ReportDataSourceX.Value = Me.BindingSource1

        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSourceX)
        Me.ReportViewer1.Visible = True
    End Sub
End Class