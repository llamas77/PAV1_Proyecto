Public Class frm_abm_marcas
    Enum estado_grabacion
        insertar
        modificar
    End Enum
    Dim estado As estado_grabacion

    Private Sub ABM_Marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO OPTIONAL: Haria falta hacer una busqueda?
        Me.estado = estado_grabacion.insertar ' DUDA: Lo dejo aca o lo pongo como default del atributo?
        recargar_grilla_marcas()
    End Sub

    Private Sub set_estado(ByRef nuevo_estado As estado_grabacion)
        estado = nuevo_estado
        If nuevo_estado = estado_grabacion.insertar Then
            btn_actualizar.Text = "Nuevo"
        Else
            btn_actualizar.Text = "Actualizar"
        End If
    End Sub

    Private Sub recargar_grilla_marcas()
        Dim index = grid_marcas.CurrentRow().Index
        grid_marcas.Rows.Clear()

        Dim marcas = MarcaDAO.all()

        For i = 0 To marcas.Rows.Count() - 1
            grid_marcas.Rows.Add()
            grid_marcas.Rows(i).Cells(0).Value = marcas(i)(0)
            grid_marcas.Rows(i).Cells(1).Value = marcas(i)(1)
        Next

        ' Posiciona la seleccion donde estaba.
        If grid_marcas.Rows.Count <= index Then ' Si tenia la ultima celda y tengo menos valores selecciono el ultimo.
            index = grid_marcas.Rows.Count - 1
        End If
        grid_marcas.CurrentCell = grid_marcas.Rows(index).Cells(0)

    End Sub

    Private Sub btn_actualizar_click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        ' Validacion
        txt_nombre.Text = txt_nombre.Text.Trim
        If txt_nombre.Text = "" Then
            MsgBox("No puede ingresar un nombre vacio.", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If

        Dim marca = get_written_MarcaVO()
        ' TODO: Validar que no esta repetido en BD (el mismo nombre con otro ID)
        MarcaDAO.save(marca)
        clear_marca()
        recargar_grilla_marcas()
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        ' DOC: Valida y elimina la marca seleccionada.
        Dim marca = get_selected_MarcaVO()

        If True Then ' TODO: Validar que no haya ningun equipo relacionado a esta marca.
            ' Confirmacion
            If MessageBox.Show("Esta seguro de borrar la marca:" + marca.get_nombre(),
                           "Importante", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                MarcaDAO.delete(marca)
                recargar_grilla_marcas()
            End If
        End If
    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        load_marca(get_selected_MarcaVO())
    End Sub

    Private Sub load_marca(ByRef marca As MarcaVO)
        txt_id.Text = marca.get_id()
        txt_nombre.Text = marca.get_nombre()
        set_estado(estado_grabacion.modificar)
        txt_nombre.Focus()
    End Sub

    Private Sub clear_marca()
        txt_id.Text = ""
        txt_nombre.Text = ""
        set_estado(estado_grabacion.insertar)
        txt_nombre.Focus()
    End Sub

    Private Function get_selected_MarcaVO() As MarcaVO
        ' DOC: Retorna el MarcaVO seleccionado en la grilla.
        Dim marca = grid_marcas.CurrentRow()
        Return New MarcaVO(marca.Cells(0).Value(), marca.Cells(1).Value())
    End Function

    Private Function get_written_MarcaVO() As MarcaVO
        ' DOC: Retorna la marca que esta escrita en los txtbox.
        Return New MarcaVO(IIf(txt_id.Text = "", 0, txt_id.Text), txt_nombre.Text.Trim)
    End Function

    Private Sub txt_nombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nombre.KeyDown
        ' DOC: Al presionar enter en el txt_nombre se ejecuta el click del btn_actualizar.
        Select Case e.KeyCode
            Case Keys.Enter
                btn_actualizar.PerformClick()
        End Select
    End Sub

    Private Sub grid_marcas_KeyDown(sender As Object, e As KeyEventArgs) Handles grid_marcas.KeyDown
        ' DOC: Al presionar enter en el txt_nombre se ejecuta el click del btn_modificar.
        '      Y al presionar supr se ejecuta el click del btn_eliminar.
        Select Case e.KeyCode
            Case Keys.Enter
                btn_modificar.PerformClick()
            Case Keys.Delete
                btn_eliminar.PerformClick()
        End Select
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        clear_marca()
    End Sub
End Class