Public Class frm_abm_marcas
    Enum estado_grabacion
        insertar
        modificar
    End Enum
    Dim estado As estado_grabacion

    Private Sub ABM_Marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.estado = estado_grabacion.insertar
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

    Private Sub recargar_grilla_marcas(Optional ByVal index = 0)
        ' TODO: Tiene que cargar la lista con las marcas de la BD
        grid_marcas.Rows.Clear()
        Dim marcas = New DataTable
        MarcaDAO.all(marcas)

        For i = 0 To marcas.Rows.Count() - 1
            grid_marcas.Rows.Add()
            grid_marcas.Rows(i).Cells(0).Value = marcas(i)(0)
            grid_marcas.Rows(i).Cells(1).Value = marcas(i)(1)
        Next

        If grid_marcas.Rows.Count > index Then ' Posiciona el cursor en la celda indicada.
            grid_marcas.CurrentCell = grid_marcas.Rows(index).Cells(0)
        End If

    End Sub

    Private Sub btn_actualizar_click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        ' Validacion
        If txt_nombre.Text.Trim = "" Then
            MsgBox("No puede ingresar un nombre vacio.", MsgBoxStyle.Exclamation, "Aviso")
            Exit Sub
        End If

        ' Ejecucion
        If estado = estado_grabacion.insertar Then
            ' TODO: Validar que el campo no esta repetido en la BD.
            Dim marca = New MarcaVO(txt_nombre.Text())
            MarcaDAO.insert(marca)
        Else
            ' TODO: Validar que el campo no esta repetido en la BD.
            Dim marca = New MarcaVO(txt_id.Text(), txt_nombre.Text())
            MarcaDAO.update(marca)
            Me.set_estado(estado_grabacion.insertar)
        End If

        recargar_grilla_marcas()
        txt_id.Text = ""
        txt_nombre.Text = ""
        txt_nombre.Focus()
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        ' DOC: Valida y elimina la marca seleccionada.
        Dim marca = get_selected_MarcaVO()
        Dim index = grid_marcas.CurrentRow.Index

        If True Then ' TODO: Validar que no haya ningun equipo relacionado a esta marca.
            ' Confirmacion
            If MessageBox.Show("Esta seguro de borrar la marca:" + marca.get_nombre(),
                           "Importante", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                MarcaDAO.delete(marca)
                recargar_grilla_marcas(index)
            End If
        End If

    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        load_marca(get_selected_MarcaVO())
        set_estado(estado_grabacion.modificar)
    End Sub

    Private Sub load_marca(ByRef marca As MarcaVO)
        txt_id.Text = marca.get_id()
        txt_nombre.Text = marca.get_nombre()
    End Sub

    Private Sub load_marca(ByVal id As Integer, ByVal nombre As String)
        txt_id.Text = id
        txt_nombre.Text = nombre
    End Sub

    Private Function get_selected_MarcaVO() As MarcaVO
        ' DOC: Retorna el MarcaVO seleccionado en la grilla.
        Dim marca = grid_marcas.CurrentRow()
        Return New MarcaVO(marca.Cells(0).Value(), marca.Cells(1).Value())
    End Function

    Private Sub txt_nombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nombre.KeyDown
        ' DOC: Al presionar enter en el txt_nombre se ejecuta el click del btn_actualizar.
        Select Case e.KeyCode
            Case Keys.Enter
                btn_actualizar.PerformClick()
        End Select
    End Sub
End Class