Public Class frmMenu
    Private Sub btn_marcas_Click(sender As Object, e As EventArgs) Handles btn_marcas.Click
        Dim frm As New frm_abm_marcas
        frm.Show()
        frm.Focus()
    End Sub

    Private Sub btn_familias_Click(sender As Object, e As EventArgs) Handles btn_familias.Click
        Dim frm As New frm_abm_familias
        frm.Show()
        frm.Focus()
    End Sub
End Class
