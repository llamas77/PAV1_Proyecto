Public Class frm_reporte

    Enum tipo_reporte
        familias
        grupos
        stock
    End Enum
    Dim tipoRep As tipo_reporte

    Public Sub New(reporte As String)
        InitializeComponent()

        Select Case reporte
            Case "Familias"
                tipoRep = tipo_reporte.familias

            Case "Productos en Stock"
                tipoRep = tipo_reporte.stock
        End Select
        Text = reporte
    End Sub

    Private Sub frm_reporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim db As DataBase = DataBase.getInstance()
        Dim sql As String = ""
        Dim tabla As New DataTable

        Select Case tipoRep
            Case tipo_reporte.stock
                sql += "SELECT codigoProducto, idGrupo, nivelReposicion, stock "
                sql += "FROM productos "
                sql += "WHERE stock > 0"

                tabla = db.consulta_sql(sql)
                ReinitializeViewer("PAV1_Proyecto.repStock.rdlc")
                bindingSource.DataSource = tabla
        End Select

        reportViewer.RefreshReport()


    End Sub

    Private Sub ReinitializeViewer(ByVal tsReport As String)

        Dim ReportDataSourceX = New Microsoft.Reporting.WinForms.ReportDataSource()

        Me.reportViewer.Reset()
        Me.reportViewer.LocalReport.ReportEmbeddedResource = tsReport
        ReportDataSourceX.Name = "DataSet1"
        ReportDataSourceX.Value = Me.bindingSource

        Me.reportViewer.LocalReport.DataSources.Add(ReportDataSourceX)
        Me.reportViewer.Visible = True
    End Sub

End Class