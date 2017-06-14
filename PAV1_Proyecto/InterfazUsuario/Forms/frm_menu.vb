Public Class frm_menu

    Private Sub btn_vendedores_Click(sender As Object, e As EventArgs)

    End Sub


    ' Version antigua de Ganancias:

    'Private Sub btn_ganancias_Click(sender As Object, e As EventArgs) Handles btn_ganancias.Click
    '   Dim frm As New frm_abm_generico(New GananciaDAO)
    '    frm.Text = "ABM Ganancias"
    '    frm.Show()
    'End Sub



    Private Sub FamiliasDeProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FamiliasDeProductosToolStripMenuItem.Click
        Dim frm As New frm_abm_generico(New FamiliaDAO)
        frm.Text = "ABM Familias"
        frm.Show()
    End Sub

    Private Sub GananciasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GananciasToolStripMenuItem.Click
        Dim frm As New frm_abm_generico_busqueda(New GananciaDAO)
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
        Dim frm As New frm_abm_generico_busqueda(New EquiposDAO)
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
        Dim frm As New frm_abm_generico_busqueda(New CompraDAO)
        frm.Text = "ABM Compras"
        frm.Show()
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem1.Click
        Dim frm As New frm_abm_generico_busqueda(New ventaDAO)
        frm.Text = "ABM Ventas"
        frm.Show()
    End Sub
End Class
