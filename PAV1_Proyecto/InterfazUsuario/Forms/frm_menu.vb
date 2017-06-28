Public Class frm_menu

    Dim frm_hijo As Form

    Private Sub FamiliasDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FamiliasDeProductosToolStripMenuItem.Click
        Dim frm As New frm_abm_generico(New FamiliaDAO)
        frm.Text = "ABM Familias"
        frm.Show()
    End Sub

    Private Sub GananciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GananciasToolStripMenuItem.Click
        Dim frm As New frm_abm_generico(New GananciaDAO)
        frm.Text = "ABM Ganancias"
        frm.Show()
    End Sub

    Private Sub GruposToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GruposToolStripMenuItem1.Click
        Dim frm As New frm_abm_generico(New GrupoDAO)
        frm.Text = "ABM Grupos"
        frm.Show()
    End Sub

    Private Sub ProductosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem1.Click
        Dim frm As New frm_abm_generico(New ProductoDAO)
        frm.Text = "ABM Productos"
        frm.Show()
    End Sub

    Private Sub MarcasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcasToolStripMenuItem.Click
        Dim frm As New frm_abm_generico(New MarcaDAO)
        frm.Text = "ABM Marcas"
        frm.Show()
    End Sub

    Private Sub EquiposToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EquiposToolStripMenuItem1.Click
        Dim frm As New frm_abm_generico(New EquiposDAO)
        frm.Text = "ABM Equipos"
        frm.Show()
    End Sub

    Private Sub TiposDeClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TiposDeClientesToolStripMenuItem.Click
        ' Muestra de funcionamiento del ABM Generico.
        Dim frm As New frm_abm_generico(New TipoClienteDAO)
        frm.Text = "ABM Tipos de Clientes"
        frm.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem1.Click
        ' Muestra de funcionamiento del ABM Generico.
        Dim frm As New frm_abm_generico(New ClienteDAO)
        frm.Text = "ABM Clientes"
        frm.Show()
    End Sub

    Private Sub VendedoresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VendedoresToolStripMenuItem1.Click
        ' Muestra de funcionamiento del ABM Generico.
        Dim frm As New frm_abm_generico(New VendedorDAO)
        frm.Text = "ABM Vendedores"
        frm.Show()
    End Sub

    Private Sub ProveedoresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem1.Click
        Dim frm As New frm_abm_generico(New ProveedorDAO)
        frm.Text = "ABM Proveedores"
        frm.Show()
    End Sub

    Private Sub ComprasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem1.Click
        Dim frm As New frm_abm_generico(New CompraDAO)
        frm.Text = "ABM Compras"
        frm.Show()
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem1.Click
        Dim frm As New frm_abm_generico(New ventaDAO)
        frm.Text = "ABM Ventas"
        frm.Show()
    End Sub

    '   Private Sub VentasPorVendedorMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasPorVendedorToolStripMenuItem.Click
    '   Dim frm As New frm_reporte("ventas por vendedor")
    '       frm.Text = "Grafico de Ventas por Vendedor"
    '       frm.Show()
    '   End Sub

    '  Private Sub VentasPorClienteMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasPorClienteToolStripMenuItem.Click
    '  Dim frm As New frm_reporte("ventas por cliente")
    '      frm.Text = "Grafico de Ventas por Cliente"
    '      frm.Show()
    '  End Sub
    '  Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GananciasPorTipoDeClienteToolStripMenuItem.Click
    '  Dim frm As New frm_reporte("ganancias por tipo de cliente")
    '      frm.Text = "Grafico de Ganancias por tipo de cliente"
    '      frm.Show()
    '  End Sub

    Private Sub ComprasToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles ComprasToolStripMenuItem2.Click
        Dim frm As New RepCompras()
        frm.Text = "Listado de Compras"
        frm.Show()
    End Sub

    Private Sub VentasToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem2.Click
        Dim frm As New RepVentas()
        frm.Text = "Listado de Ventas"
        frm.Show()
    End Sub

    Private Sub ListadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoToolStripMenuItem.Click
        Dim frm As New RepProductos()
        frm.Text = "Listado de Productos"
        frm.Show()
    End Sub

    Private Sub ListadoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ListadoToolStripMenuItem1.Click
        Dim frm As New RepEquipos()
        frm.Text = "Listado de Equipos"
        frm.Show()
    End Sub

    Private Sub ListadoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ListadoToolStripMenuItem2.Click
        Dim frm As New RepClientes()
        frm.Text = "Listado de Clientes"
        frm.Show()
    End Sub

    Private Sub ListadoToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ListadoToolStripMenuItem3.Click
        Dim frm As New RepVendedores()
        frm.Text = "Listado de Vendedores"
        frm.Show()
    End Sub

    Private Sub ListadoToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ListadoToolStripMenuItem4.Click
        Dim frm As New RepProveedores()
        frm.Text = "Listado de Proveedores"
        mostrar(frm)
    End Sub

    Private Sub ListadoDeGruposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListadoDeGruposToolStripMenuItem.Click
        Dim frm As New RepGrupos()
        frm.Text = "Listado de Grupos"
        frm.Show()
    End Sub

    Private Sub frm_menu_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        If Not frm_hijo Is Nothing Then
            If Application.OpenForms.Count = 1 Then ' Solo esta abierto el Menu.
                frm_hijo = Nothing
                Me.MenuStrip1.Enabled = True
            Else
                frm_hijo.BringToFront()
                Me.MenuStrip1.Enabled = False
            End If
        End If
        Me.MenuStrip1.Enabled = True
    End Sub

    Private Sub frm_menu_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Not frm_hijo Is Nothing Then
            If Me.WindowState = FormWindowState.Minimized Then
                frm_hijo.Visible = False
            Else
                frm_hijo.Visible = True
                frm_hijo.BringToFront()
            End If
        End If
    End Sub

    Private Sub mostrar(frm As Form)
        frm_hijo = frm
        frm.Show()
    End Sub

    Private Sub MovimientosPorFamiliaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosPorFamiliaToolStripMenuItem.Click
        Dim frm As New repEstMovXFlia()
        frm.Text = "Movimientos por Familia"
        frm.Show()
    End Sub

    Private Sub MovimientosPorGrupoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MovimientosPorGrupoToolStripMenuItem.Click
        Dim frm As New repEstMovXGrupo()
        frm.Text = "Movimientos por Grupo"
        frm.Show()
    End Sub

    Private Sub VentasPorPeríodoGrupoYFamiliaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasPorPeríodoGrupoYFamiliaToolStripMenuItem.Click
        Dim frm As New repEstVentasFGF()
        frm.Text = "Ventas por período, grupo y familia"
        frm.Show()
    End Sub

    Private Sub ComprasPorPeríodoGrupoYFamiliaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasPorPeríodoGrupoYFamiliaToolStripMenuItem.Click
        Dim frm As New repEstComprasFGF()
        frm.Text = "Compras por período, grupo y familia"
        frm.Show()
    End Sub

    Private Sub GananciasPorTipoDeClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GananciasPorTipoDeClienteToolStripMenuItem.Click
        Dim frm As New repEstGananciasXTipoC()
        frm.Text = "Ganancias por tipo de cliente"
        frm.Show()
    End Sub

    Private Sub frm_menu_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Show()
        With New DataBase
            If Not .probar_conexion Then
                MsgBox("No se puede conectar con la base de datos.")
                Me.Close()
            End If
        End With
    End Sub
End Class
