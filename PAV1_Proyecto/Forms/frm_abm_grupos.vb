Public Class frm_abm_grupos

    Enum tipo_grabacion
        insertar
        modificar
    End Enum
    Dim tipo_g = tipo_grabacion.insertar

    Private Sub frm_abm_grupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_combo(cmb_familia, FamiliaDAO.all(), "idFamilia", "nombre")
        recargar_grilla_grupos()
    End Sub

    Private Sub recargar_grilla_grupos()
        ' Guarda la posición de la celda seleccionada
        Dim index = 0
        If grid_grupos.Rows.Count > 0 Then
            index = grid_grupos.CurrentRow().Index
            grid_grupos.Rows.Clear()
        End If

        ' Lee las marcas y carga la grilla
        Dim grupos = GrupoDAO.all()
        For i = 0 To grupos.Rows.Count() - 1
            grid_grupos.Rows.Add()
            grid_grupos.Rows(i).Cells(0).Value = grupos(i)(0)
            grid_grupos.Rows(i).Cells(1).Value = grupos(i)(1)
            grid_grupos.Rows(i).Cells(2).Value = grupos(i)(2)
            grid_grupos.Rows(i).Cells(3).Value = grupos(i)(3)
        Next

        ' Posiciona la seleccion donde estaba.
        If grid_grupos.Rows.Count > 0 Then
            If grid_grupos.Rows.Count() <= index Then ' Si tenia la ultima celda y tengo menos valores selecciono el ultimo.
                index = grid_grupos.Rows.Count - 1
            End If
            grid_grupos.CurrentCell = grid_grupos.Rows(index).Cells(0)
        End If
    End Sub

    Private Sub cargar_combo(ByRef combo As ComboBox, ByRef tabla As DataTable, ByVal pk As String, ByVal nombre As String)
        combo.DataSource = tabla
        combo.DisplayMember = nombre
        combo.ValueMember = pk
        combo.SelectedIndex = -1 ' Para evitar q seleccione el primer elemento por defecto
    End Sub

    Private Sub set_tipo_g(ByRef nuevo_estado As tipo_grabacion)
        tipo_g = nuevo_estado
        If nuevo_estado = tipo_grabacion.insertar Then
            btn_actualizar.Text = "Agregar"
        Else
            btn_actualizar.Text = "Actualizar"
        End If
    End Sub

    Private Function validate_GrupoVO(ByRef grupo As GrupoVO) As Boolean
        If grupo._nombre = "" Then
            MsgBox("No puede ingresar un nombre de grupo vacio.", MsgBoxStyle.Exclamation, "Aviso")
            Return False
        End If

        Return True
    End Function

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        Dim grupo = get_written_GrupoVO()
        If validate_GrupoVO(grupo) Then

            Select Case tipo_g
                Case tipo_grabacion.insertar
                    If GrupoDAO.is_name_in_use(grupo) Then
                        MsgBox("Ya existe un grupo de nombre: " & grupo._nombre, MsgBoxStyle.Exclamation, "Aviso")
                    Else
                        GrupoDAO.insert(grupo)
                    End If
                Case tipo_grabacion.modificar
                    If GrupoDAO.exists(grupo) Then
                        GrupoDAO.update(grupo)
                    Else
                        MsgBox("El grupo " & grupo._nombre & " no existe. Imposible modificar.", MsgBoxStyle.Exclamation, "Aviso")
                    End If
            End Select

            clear_grupo()
            recargar_grilla_grupos()
        End If
    End Sub

    Private Sub load_grupo(ByRef grupo As GrupoVO)
        ' DOC: Completa el formulario con el grupo seleccionado y se prepara para modificarlo

        txt_id.Text = grupo._id
        txt_nombre.Text = grupo._nombre
        cmb_familia.SelectedValue = grupo._familia._id
        set_tipo_g(tipo_grabacion.modificar)
        txt_nombre.Focus()
    End Sub

    Private Sub clear_grupo()
        ' DOC: Vacía el formulario y lo prepara para ingresar un grupo

        txt_id.Text = ""
        txt_nombre.Text = ""
        cmb_familia.SelectedIndex = -1
        set_tipo_g(tipo_grabacion.insertar)
        txt_nombre.Focus()
    End Sub

    Private Function get_selected_GrupoVO() As GrupoVO
        ' DOC: Retorna el GrupoVO seleccionado en la grilla.
        Dim grupo = grid_grupos.CurrentRow()
        Return New GrupoVO(grupo.Cells(0).Value(), grupo.Cells(1).Value(), New FamiliaVO(grupo.Cells(3).Value(), grupo.Cells(2).Value()))
    End Function

    Private Function get_written_GrupoVO() As GrupoVO
        ' DOC: Retorna el grupo que esta escrito en los txtbox.
        Return New GrupoVO(IIf(txt_id.Text = "", 0, txt_id.Text), txt_nombre.Text, New FamiliaVO(cmb_familia.SelectedValue, cmb_familia.Text))
    End Function

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        load_grupo(get_selected_GrupoVO())
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        ' DOC: Valida y elimina el grupo seleccionado.
        Dim grupo = get_selected_GrupoVO()
        If True Then ' TODO: Validar que no haya ningun equipo relacionado a esta marca.
            ' Confirmacion
            If MessageBox.Show("Esta seguro de borrar el grupo: " + grupo._nombre,
                           "Importante", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                GrupoDAO.delete(grupo)
                recargar_grilla_grupos()
            End If
        End If
    End Sub

    Private Sub txt_nombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nombre.KeyDown
        ' DOC: Al presionar enter en el txt_nombre se ejecuta el click del btn_actualizar.
        Select Case e.KeyCode
            Case Keys.Enter
                btn_actualizar.PerformClick()
        End Select
    End Sub

    Private Sub grid_marcas_KeyDown(sender As Object, e As KeyEventArgs) Handles grid_grupos.KeyDown

        Select Case e.KeyCode
            Case Keys.Enter
                btn_modificar.PerformClick() ' Duda - Juani: Tal vez sea mejor crear una funcion y que ambos la llamen
                                               'FRANCO: lo mismo pensé.. sino hay una dependencia... si borramos el boton esto no anda
            Case Keys.Delete
                btn_eliminar.PerformClick() ' Idem arriba.
        End Select
    End Sub


    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Close()
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        clear_grupo()
    End Sub
End Class
