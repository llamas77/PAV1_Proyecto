Public Class repEstVentasFGF

    Private Sub RepGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "familia", ._name = "Familia", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New FamiliaDAO})
        ctrl_list.Add(New Campo With {._id = "grupo", ._name = "Grupo", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New GrupoDAO})
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

        Dim sql = "SELECT MONTH(v.fechaVenta) as mes, SUM(dv.cantidad * dv.precio) as monto_ventas "
        sql &= "FROM ventas v "
        sql &= "JOIN detalleVentas dv ON v.idVenta = dv.idVenta "
        sql &= "JOIN productos p ON dv.codigoProducto = p.codigoProducto "
        sql &= "JOIN grupos g ON p.idGrupo = g.idGrupo "

        Dim hay_where = False
        If Not filtros("familia") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("familia"), FamiliaVO)
                sql &= " g.idFamilia=" & ._id
            End With
            hay_where = True
        End If

        If Not filtros("grupo") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("grupo"), GrupoVO)
                sql &= " g.idGrupo=" & ._id
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


        sql &= "GROUP BY MONTH(v.fechaVenta)"


        'If Not filtros("nombre") Is Nothing Then
        ' sql &= IIf(hay_where, " AND ", " WHERE ")
        ' sql &= " g.nombre LIKE '%" & filtros("nombre") & "%' "
        ' hay_where = True
        ' End If


        Dim response As DataTable = db.consulta_sql(sql)


        ReinitializeViewer("PAV1_Proyecto.repEstVentasFGF.rdlc")
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