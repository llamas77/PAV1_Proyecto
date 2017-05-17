Public Class frm_menu
    Private Sub btn_marcas_Click(sender As Object, e As EventArgs) Handles btn_marcas.Click
        Dim frm As New frm_abm_marcas
        frm.Show()
    End Sub

    Private Sub btn_familias_Click(sender As Object, e As EventArgs) Handles btn_familias.Click
        Dim frm As New frm_abm_familias
        frm.Show()
    End Sub

    Private Sub btn_tipos_cliente_Click(sender As Object, e As EventArgs) Handles btn_tipos_cliente.Click
        ' Muestra de funcionamiento del ABM Generico.
        Dim frm As New frm_abm_generico(New TipoClienteDAO)
        frm.Text = "ABM Tipos de Clientes"
        frm.Show()
    End Sub

    Private Sub btn_vendedores_Click(sender As Object, e As EventArgs) Handles btn_vendedores.Click
        ' Muestra de funcionamiento del ABM Generico.
        Dim frm As New frm_abm_generico(New VendedorDAO)
        frm.Text = "ABM Vendedores"
        frm.Show()
    End Sub

    Private Sub btn_grupos_Click(sender As Object, e As EventArgs) Handles btn_grupos.Click
        Dim frm As New frm_abm_grupos
        frm.Show()
    End Sub

    Private Sub btn_Clientes_Click(sender As Object, e As EventArgs) Handles btn_Clientes.Click
        ' Muestra de funcionamiento del ABM Generico.
        Dim frm As New frm_abm_generico(New ClienteDAO)
        frm.Text = "ABM Clientes"
        frm.Show()
    End Sub

    Private Sub btn_ganancias_Click(sender As Object, e As EventArgs) Handles btn_ganancias.Click
        Dim frm As New frm_abm_generico(New GananciaDAO)
        frm.Text = "ABM Ganancias"
        frm.Show()
    End Sub

    Private Sub btn_ganancias2_Click(sender As Object, e As EventArgs) Handles btn_ganancias2.Click
        Dim frm As New frm_abm_generico_busqueda(New GananciaDAO)
        frm.Text = "ABM Ganancias"
        frm.Show()
    End Sub

    Private Sub btn_productos_Click(sender As Object, e As EventArgs) Handles btn_productos.Click
        Dim frm As New frm_abm_generico(New ProductoDAO)
        frm.Text = "ABM Productos"
        frm.Show()
    End Sub
End Class
