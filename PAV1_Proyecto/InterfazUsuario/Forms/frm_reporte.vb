Public Class frm_reporte

    Enum tipo_reporte
        stock
        stock_bajo_lim_rep
        productos_equipo
        clientes_fecha_compra
        compras_por_mes
        ganancias_por_tipo_de_cliente
        ganancias_por_vendedor
        ganancias_por_cliente

    End Enum
    Dim tipoRep As tipo_reporte

    Public Sub New(reporte As String)
        InitializeComponent()

        Select Case reporte.ToLower
            Case "ganancias por tipo de cliente"
                tipoRep = tipo_reporte.ganancias_por_tipo_de_cliente

            Case "ventas por vendedor"
                tipoRep = tipo_reporte.ganancias_por_vendedor

            Case "ventas por cliente"
                tipoRep = tipo_reporte.ganancias_por_cliente
        End Select
        Text = reporte
    End Sub

    Private Sub frm_reporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim db As DataBase = DataBase.getInstance()
        Dim sql As String = ""
        Dim tabla As New DataTable

        Select Case tipoRep
            Case tipo_reporte.ganancias_por_tipo_de_cliente
                lblGanInf.Visible = True
                lblGanSup.Visible = True
                txt_gan_sup.Visible = True
                txt_gan_inf.Visible = True
                sql += "select tc.nombre , SUM(ganancia) as ganancia "
                sql += "from tipos_cliente tc join ganancias g on tc.idTipo = g.idTipo "
                sql += "group by tc.nombre "
                If txt_gan_inf.Text <> "" And txt_gan_sup.Text <> "" Then
                    sql += " having SUM(ganancia) between '" & txt_gan_inf.Text & "' and '" & txt_gan_sup.Text & "' "

                End If

                tabla = db.consulta_sql(sql)
                ReinitializeViewer(bindingSource, "PAV1_Proyecto.repEstGananciasXTipoC.rdlc")

            Case tipo_reporte.ganancias_por_vendedor
                lblFechaInf.Visible = True
                lblFechaSup.Visible = True
                fecha_inf.Visible = True
                fecha_sup.Visible = True

                sql += "select ven.nombre, SUM(([cantidad]*[precio])) as ganancia "
                sql += "from vendedores ven join ventas v on ven.idVendedor = v.idVendedor "
                sql += "join detalleVentas dv on v.idVenta= dv.idVenta "
                If fecha_inf.Text <> "  /  /" And fecha_sup.Text <> "  /  /" Then
                    sql += "where v.fechaVenta between '" & fecha_inf.Text & "' and '" & fecha_sup.Text & "' "

                End If
                sql += "group by nombre"



                tabla = db.consulta_sql(sql)
                ReinitializeViewer(bindingSource, "PAV1_Proyecto.repEstGananciasXVendedor.rdlc")

            Case tipo_reporte.ganancias_por_cliente
                lblFechaInf.Visible = True
                lblFechaSup.Visible = True
                fecha_inf.Visible = True
                fecha_sup.Visible = True
                sql += "select c.nombre, SUM(([cantidad]*[precio])) as ganancia "
                sql += "from clientes c join ventas v on c.nroCliente = v.nroCliente "
                sql += "join detalleVentas dv on v.idVenta= dv.idVenta "
                If fecha_inf.Text <> "  /  /" And fecha_sup.Text <> "  /  /" Then
                    sql += "where v.fechaVenta between '" & fecha_inf.Text & "' and '" & fecha_sup.Text & "' "

                End If
                sql += "group by nombre"

                tabla = db.consulta_sql(sql)
                ReinitializeViewer(bindingSource, "PAV1_Proyecto.repEstGananciasXCliente.rdlc")
        End Select

        bindingSource.DataSource = tabla
        reportViewer.RefreshReport()


    End Sub

    Private Sub ReinitializeViewer(ByRef bindingSource As BindingSource, ByVal tsReport As String)

        Dim ReportDataSourceX = New Microsoft.Reporting.WinForms.ReportDataSource()

        Me.reportViewer.Reset()
        Me.reportViewer.LocalReport.ReportEmbeddedResource = tsReport
        ReportDataSourceX.Name = "DataSet1"
        ReportDataSourceX.Value = Me.bindingSource

        Me.reportViewer.LocalReport.DataSources.Add(ReportDataSourceX)
        Me.reportViewer.Visible = True
    End Sub


    Private Function leerTabla(ByVal nombreTabla As String) As DataTable
        Dim consulta = "SELECT * FROM " & nombreTabla
        Return DataBase.getInstance().consulta_sql(consulta)
    End Function


    Public Sub cargarCombo(ByRef combo As ComboBox, ByRef tabla As DataTable, ByVal pk As String, ByVal nombre As String)
        combo.DataSource = tabla
        combo.DisplayMember = nombre
        combo.ValueMember = pk
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        frm_reporte_Load(sender, e)
    End Sub


End Class