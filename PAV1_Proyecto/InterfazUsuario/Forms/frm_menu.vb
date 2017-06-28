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

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GananciasPorTipoDeClienteToolStripMenuItem.Click, GananciasPorVendedorToolStripMenuItem.Click, GananciasPorClienteToolStripMenuItem.Click
        Dim itemMenu As ToolStripMenuItem
        itemMenu = sender

        Dim listaNombres As New List(Of String)
        listaNombres.Add(GananciasPorTipoDeClienteToolStripMenuItem.Text)
        listaNombres.Add(GananciasPorVendedorToolStripMenuItem.Text)
        listaNombres.Add(GananciasPorClienteToolStripMenuItem.Text)

        Dim i As Integer
        For i = 0 To listaNombres.Count - 1
            If listaNombres(i) = itemMenu.Text Then
                Dim frm As New frm_reporte(itemMenu.Text)
                frm.Show()
                Exit For
            End If
        Next
    End Sub

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
End Class
