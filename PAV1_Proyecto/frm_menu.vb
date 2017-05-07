Public Class frm_menu
    Private Sub btn_marcas_Click(sender As Object, e As EventArgs) Handles btn_marcas.Click
        Dim frm As New frm_abm_marcas
        frm.Show()
    End Sub

    Private Sub btn_familias_Click(sender As Object, e As EventArgs) Handles btn_familias.Click
        Dim frm As New frm_abm_familias
        frm.Show()
    End Sub

    Private Sub btn_generico_Click(sender As Object, e As EventArgs) Handles btn_generico.Click
        Dim frm As New frm_abm_generico(New TipoClienteControl, New TipoClienteGrilla, New TipoClienteDAO)
        frm.Show()
    End Sub
End Class
