Public Class frm_abm_tipos_clientes

    Private Sub frm_abm_tipos_clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grilla_tipo_cliente.recargar()
    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        If ctrl_tipo_cliente.is_valid() Then
            Dim tipo_cliente = ctrl_tipo_cliente._TipoClienteVO

            If tipo_cliente._id = 0 Then
                ' TODO: Validar
                TipoClienteDAO.insert(tipo_cliente)
            Else
                ' TODO: Validar
                TipoClienteDAO.update(tipo_cliente)
            End If
            grilla_tipo_cliente.recargar()
        End If
    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Dim tipo_cliente = grilla_tipo_cliente.get_selected()
        If IsNothing(tipo_cliente) Then
            ' Error: No hay nada seleccionado en la grilla.
            ' TODO: Informar al usuario.
        Else
            ctrl_tipo_cliente._TipoClienteVO = tipo_cliente
        End If
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Dim tipo_cliente = grilla_tipo_cliente.get_selected()
        If IsNothing(tipo_cliente) Then
            ' Error: No hay nada seleccionado en la grilla.
            ' TODO: Informar al usuario.
        Else
            If MessageBox.Show("Esta seguro de borrar" + tipo_cliente._nombre,
                               "Importante", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                TipoClienteDAO.delete(tipo_cliente)
                grilla_tipo_cliente.recargar()
            End If
        End If
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        ctrl_tipo_cliente._TipoClienteVO = New TipoClienteVO()
    End Sub
End Class