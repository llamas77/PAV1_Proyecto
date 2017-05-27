Public Class frm_abm_familias

    Enum tipo_grabacion
        insertar
        modificar
    End Enum
    Dim tipo_g = tipo_grabacion.insertar

    Private Sub frm_abm_familias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO OPTIONAL: ¿Haria falta hacer una busqueda de marcas en la grilla?
        recargar_grilla_familias()
    End Sub

    Private Sub set_tipo_g(ByRef nuevo_estado As tipo_grabacion)
        tipo_g = nuevo_estado
        If nuevo_estado = tipo_grabacion.insertar Then
            btn_actualizar.Text = "Agregar"
        Else
            btn_actualizar.Text = "Actualizar"
        End If
    End Sub

    Private Sub recargar_grilla_familias()
        ' Guarda la posición de la celda seleccionada
        Dim index = 0
        If grid_familias.Rows.Count > 0 Then
            index = grid_familias.CurrentRow().Index
            grid_familias.Rows.Clear()
        End If

        ' Lee las marcas y carga la grilla
        Dim familias = FamiliaDAO.all()
        For i = 0 To familias.Rows.Count() - 1
            grid_familias.Rows.Add()
            grid_familias.Rows(i).Cells(0).Value = familias(i)(0)
            grid_familias.Rows(i).Cells(1).Value = familias(i)(1)
        Next

        ' Posiciona la seleccion donde estaba.
        If grid_familias.Rows.Count > 0 Then
            If grid_familias.Rows.Count() <= index Then ' Si tenia la ultima celda y tengo menos valores selecciono el ultimo.
                index = grid_familias.Rows.Count - 1
            End If
            grid_familias.CurrentCell = grid_familias.Rows(index).Cells(0)
        End If

    End Sub

    Private Sub btn_actualizar_click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        Dim familia = get_written_FamiliaVO()
        If validate_FamiliaVO(familia) Then

            Select Case tipo_g
                Case tipo_grabacion.insertar
                    FamiliaDAO.insert(familia)
                Case tipo_grabacion.modificar
                    If FamiliaDAO.exists(familia) Then
                        FamiliaDAO.update(familia)
                    Else
                        MsgBox("La familia " & familia._nombre & " no existe. Imposible modificar.", MsgBoxStyle.Exclamation, "Aviso")
                        ' Duda - Juani: Si la familia no existe y el usuario la quiere guardar, no deberiamos
                        '           redirijir internamente al insert sin informar al usuario? En este caso no hace falta el estadoGrabacion.
                    End If
            End Select

            clear_familia()
            recargar_grilla_familias()
        End If
    End Sub

    Private Function validate_FamiliaVO(ByRef familia As FamiliaVO) As Boolean
        ' DUDA - Juani: El metodo deberia obtener los datos de los txtBox o que le pasen un MarcaVO y lo valide?
        If familia._nombre = "" Then
            MsgBox("No puede ingresar un nombre de familia vacio.", MsgBoxStyle.Exclamation, "Aviso")
            Return False
        ElseIf FamiliaDAO.is_name_in_use(familia) Then
            MsgBox("Ya existe una familia de nombre: " & familia._nombre, MsgBoxStyle.Exclamation, "Aviso")
            Return False
        End If

        Return True
    End Function

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        ' DOC: Valida y elimina la marca seleccionada.
        Dim familia = get_selected_FamiliaVO()
        If True Then ' TODO: Validar que no haya ningun equipo relacionado a esta marca.
            ' Confirmacion
            If MessageBox.Show("Esta seguro de borrar la familia: " + familia._nombre,
                           "Importante", MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                FamiliaDAO.delete(familia)
                recargar_grilla_familias()
            End If
        End If
    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        load_familia(get_selected_FamiliaVO())
    End Sub

    Private Sub load_familia(ByRef familia As FamiliaVO)
        ' DOC: Completa el formulario con la marca seleccionada y se prepara para modificarla

        txt_id.Text = familia._id
        txt_nombre.Text = familia._nombre
        set_tipo_g(tipo_grabacion.modificar)
        txt_nombre.Focus()
    End Sub

    Private Sub clear_familia()
        ' DOC: Vacía el formulario y lo prepara para ingresar una marca

        txt_id.Text = ""
        txt_nombre.Text = ""
        set_tipo_g(tipo_grabacion.insertar)
        txt_nombre.Focus()
    End Sub

    Private Function get_selected_FamiliaVO() As FamiliaVO
        ' DOC: Retorna el MarcaVO seleccionado en la grilla.
        Dim familia = grid_familias.CurrentRow()
        Return New FamiliaVO(familia.Cells(0).Value(), familia.Cells(1).Value())
    End Function

    Private Function get_written_FamiliaVO() As FamiliaVO
        ' DOC: Retorna la marca que esta escrita en los txtbox.
        Return New FamiliaVO(IIf(txt_id.Text = "", 0, txt_id.Text), txt_nombre.Text)
    End Function

    Private Sub txt_nombre_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_nombre.KeyDown
        ' DOC: Al presionar enter en el txt_nombre se ejecuta el click del btn_actualizar.
        Select Case e.KeyCode
            Case Keys.Enter
                btn_actualizar.PerformClick() ' Duda - Juani: Capaz sea mejor crear una funcion actualizar
                '             que sea llamada desde este keyDown y desde el btn_actualizar.Click
        End Select
    End Sub

    Private Sub grid_marcas_KeyDown(sender As Object, e As KeyEventArgs) Handles grid_familias.KeyDown
        ' DOC: Al presionar enter en el txt_nombre se ejecuta el click del btn_modificar.
        '      Y al presionar supr se ejecuta el click del btn_eliminar.
        Select Case e.KeyCode
            Case Keys.Enter
                btn_modificar.PerformClick() ' Duda - Juani: Tal vez sea mejor crear una funcion y que ambos la llamen
            Case Keys.Delete
                btn_eliminar.PerformClick() ' Idem arriba.
        End Select
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        clear_familia()
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        clear_familia()
        Hide() ' Duda - juani: Cuando haces Show se ejecuta el load()? Porque sino no va a recargar la grilla al abrirlo de nuevo.
        ' De todas formas creo que si sale con el boton de arriba se va a cerrar... lo que habria que interceptar es el cierre
        ' del form.
    End Sub
End Class

