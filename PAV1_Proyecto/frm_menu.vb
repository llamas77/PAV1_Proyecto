Public Class frm_menu
    Private Sub btn_marcas_Click(sender As Object, e As EventArgs) Handles btn_marcas.Click
        Dim frm As New frm_abm_marcas
        frm.Show()
    End Sub

    Private Sub btn_familias_Click(sender As Object, e As EventArgs) Handles btn_familias.Click
        Dim frm As New frm_abm_familias
        frm.Show()
    End Sub

    Private Sub btn_generico_Click(sender As Object, e As EventArgs) Handles btn_tipos_cliente.Click
        ' Muestra de funcionamiento del ABM Generico.
        Dim frm As New frm_abm_generico(New TipoClienteControl, New TipoClienteGrilla, New TipoClienteDAO)
        frm.Text = "ABM Tipos de Clientes"
        frm.Show()
    End Sub

    Private Sub btn_vendedores_Click(sender As Object, e As EventArgs) Handles btn_vendedores.Click
        ' Muestra de funcionamiento de la grilla generica
        Dim grilla_vendedores As New GrillaGenerica(New VendedorDAO())

        ' Muestra de funcionamiento del ABM Generico.
        Dim frm As New frm_abm_generico(New VendedoresControl, grilla_vendedores, New VendedorDAO)
        frm.Text = "ABM Vendedores"
        frm.Show()
    End Sub

    Private Sub btn_grupos_Click(sender As Object, e As EventArgs) Handles btn_grupos.Click
        Dim frm As New frm_abm_grupos
        frm.Show()
    End Sub

    Private Sub btn_Clientes_Click(sender As Object, e As EventArgs) Handles btn_Clientes.Click
        ' Muestra de funcionamiento de la grilla generica
        Dim grilla_Clientes As New GrillaGenerica(New ClienteDAO())

        ' Muestra de funcionamiento del ABM Generico.

        Dim frm As New frm_abm_generico(New ClienteControl, grilla_Clientes, New ClienteDAO)
        frm.Text = "ABM Clientes"
        frm.Show()
    End Sub
End Class
