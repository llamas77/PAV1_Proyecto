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

            Case "ganancias por tipo de cliente"
                tipoRep = tipo_reporte.ganancias_por_tipo_de_cliente

            Case "ganancias por vendedor"
                tipoRep = tipo_reporte.ganancias_por_vendedor

            Case "ganancias por cliente"
                tipoRep = tipo_reporte.ganancias_por_cliente
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

            Case tipo_reporte.ganancias_por_tipo_de_cliente
                sql += "select tc.nombre , ganancia "
                sql += "from tipos_cliente tc join ganancias g on tc.idTipo = g.idTipo "

                tabla = db.consulta_sql(sql)
                ReinitializeViewer("PAV1_Proyecto.repEstGananciasXTipoC.rdlc")

            Case tipo_reporte.ganancias_por_vendedor
                txt_fecha_inf.Visible = True
                txt_fecha_sup.Visible = True

                sql += "select ven.nombre, SUM(([cantidad]*[precio])) as ganancia "
                sql += "from vendedores ven join ventas v on ven.idVendedor = v.idVendedor "
                sql += "join detalleVentas dv on v.idVenta= dv.idVenta "
                If txt_fecha_inf.Text <> "" And txt_fecha_sup.Text <> "" Then
                    sql += "where v.fechaVenta between '" & txt_fecha_inf.Text & "' and '" & txt_fecha_sup.Text & "' "

                End If
                sql += "group by nombre"



                tabla = db.consulta_sql(sql)
                ReinitializeViewer("PAV1_Proyecto.repEstGananciasXVendedor.rdlc")

            Case tipo_reporte.ganancias_por_cliente
                txt_fecha_inf.Visible = True
                txt_fecha_sup.Visible = True
                sql += "select c.nombre, SUM(([cantidad]*[precio])) as ganancia "
                sql += "from clientes c join ventas v on c.nroCliente = v.nroCliente "
                sql += "join detalleVentas dv on v.idVenta= dv.idVenta "
                If txt_fecha_inf.Text <> "" And txt_fecha_sup.Text <> "" Then
                    sql += "where v.fechaVenta between '" & txt_fecha_inf.Text & "' and '" & txt_fecha_sup.Text & "' "

                End If
                sql += "group by nombre"

                tabla = db.consulta_sql(sql)
                ReinitializeViewer("PAV1_Proyecto.repEstGananciasXCliente.rdlc")
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

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        frm_reporte_Load(sender, e)

    End Sub
End Class