Public Class repEstGananciasXTipoC
    Private Sub RepGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "gan_min", ._name = "Ganancia Min.", ._numeric = True})
        ctrl_list.Add(New Campo With {._id = "gan_max", ._name = "Ganancia Max.", ._numeric = True})
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

        Dim sql = ""
        sql += "select tc.nombre , AVG(ganancia) as ganancia "
        sql += "from tipos_cliente tc join ganancias g on tc.idTipo = g.idTipo "
        sql += "group by tc.nombre "

        Dim hay_having = False
        If filtros("gan_min") <> 0 Then
            sql &= IIf(hay_having, " AND ", " HAVING ")
            sql &= " AVG(ganancia) >= " & filtros("gan_min")
            hay_having = True
        End If
        If filtros("gan_max") <> 0 Then
            sql &= IIf(hay_having, " AND ", " HAVING ")
            sql &= " AVG(ganancia) <= " & filtros("gan_max")
            hay_having = True
        End If

        Dim response As DataTable = db.consulta_sql(sql)


        ReinitializeViewer("PAV1_Proyecto.repEstGananciasXTipoC.rdlc")
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