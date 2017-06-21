Public Class frm_reporte

    Enum tipo_reporte
        stock
        stock_bajo_lim_rep
        productos_equipo
        clientes_fecha_compra
        compras_por_mes
    End Enum
    Dim tipoRep As tipo_reporte

    Public Sub New(reporte As String)
        InitializeComponent()

        Select Case reporte.ToLower
            Case "productos en stock"
                tipoRep = tipo_reporte.stock

            Case "productos bajo limite de rep"
                tipoRep = tipo_reporte.stock_bajo_lim_rep

            Case "clientes por fecha de ultima compra"
                tipoRep = tipo_reporte.clientes_fecha_compra

            Case "productos asociados a un equipo"
                tipoRep = tipo_reporte.productos_equipo

            Case "compras por mes"
                tipoRep = tipo_reporte.compras_por_mes
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

            Case tipo_reporte.stock_bajo_lim_rep


                sql += "SELECT codigoProducto, idGrupo, nivelReposicion, stock "
                sql += "FROM productos "
                sql += "WHERE nivelReposicion > stock"

                tabla = db.consulta_sql(sql)
                ReinitializeViewer("PAV1_Proyecto.repStock.rdlc")

            Case tipo_reporte.clientes_fecha_compra


                'Dim fecha As Integer = InputBox("Indique el límite de reposición:")

                sql += "SELECT nroCliente, nombre, apellido, direccion, telefono "
                sql += "FROM clientes"

                tabla = db.consulta_sql(sql)
                ReinitializeViewer("PAV1_Proyecto.repClientes.rdlc")

            Case tipo_reporte.productos_equipo
                cmbCombo.Visible = True
                lblCombo.Visible = True

                lblCombo.Text = "Equipo:"
                cargarCombo(cmbCombo, leerTabla("equipos"), "id", "modelo")

                sql += "SELECT codigoProducto, idGrupo, nivelReposicion, stock "
                sql += "FROM productos p"

                'Incompleto, no anda bien el ABM Productos

            Case tipo_reporte.compras_por_mes
                sql += "SELECT MONTH(c.fechaCompra) as mes, YEAR(c.fechaCompra) as año, count(c.idCompra) as cantidad, sum(dc.cantidad * dc.costo) as monto from compras c "
                sql += "JOIN detalle_compras dc ON dc.idCompra = c.idCompra "
                sql += "GROUP BY MONTH(c.fechaCompra), YEAR(c.fechaCompra) "
                sql += "ORDER BY YEAR(c.fechaCompra) DESC, MONTH(c.fechaCompra)"

                tabla = db.consulta_sql(sql)
                ReinitializeViewer("PAV1_Proyecto.repComprasXMes.rdlc")



        End Select

        bindingSource.DataSource = tabla
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


    Private Function leerTabla(ByVal nombreTabla As String) As DataTable
        Dim consulta = "SELECT * FROM " & nombreTabla
        Return DataBase.getInstance().consulta_sql(consulta)
    End Function


    Public Sub cargarCombo(ByRef combo As ComboBox, ByRef tabla As DataTable, ByVal pk As String, ByVal nombre As String)
        combo.DataSource = tabla
        combo.DisplayMember = nombre
        combo.ValueMember = pk
    End Sub

End Class