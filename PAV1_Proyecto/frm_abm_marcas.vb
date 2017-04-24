Public Class frm_abm_marcas

    Enum tipo_grabacion
        insertar
        modificar
    End Enum
    Dim tipo_g = tipo_grabacion.insertar

    Private Sub ABM_Marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' TODO OPTIONAL: ¿Haria falta hacer una busqueda de marcas en la grilla?
        recargar_grilla_marcas()
    End Sub

    Private Sub set_tipo_g(ByRef nuevo_estado As tipo_grabacion)
        tipo_g = nuevo_estado
        If nuevo_estado = tipo_grabacion.insertar Then
            btn_actualizar.Text = "Agregar"
        Else
            btn_actualizar.Text = "Actualizar"
        End If
    End Sub

    Private Sub recargar_grilla_marcas()
        ' Guarda la posición de la celda seleccionada
        Dim index = 0
        If grid_marcas.Rows.Count > 0 Then
            index = grid_marcas.CurrentRow().Index
            grid_marcas.Rows.Clear()
        End If

        ' Lee las marcas y carga la grilla
        Dim marcas = MarcaDAO.all()
        For i = 0 To marcas.Rows.Count() - 1
            grid_marcas.Rows.Add()
            grid_marcas.Rows(i).Cells(0).Value = marcas(i)(0)
            grid_marcas.Rows(i).Cells(1).Value = marcas(i)(1)
        Next

        ' Posiciona la seleccion donde estaba.
        If grid_marcas.Rows.Count > 0 Then
            If grid_marcas.Rows.Count() <= index Then ' Si tenia la ultima celda y tengo menos valores selecciono el ultimo.
                index = grid_marcas.Rows.Count - 1
            End If
            grid_marcas.CurrentCell = grid_marcas.Rows(index).Cells(0)
        End If

    End Sub

    Private Sub btn_actualizar_click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        Dim marca = get_written_MarcaVO()
        If validate_MarcaVO(marca) Then

            Select Case tipo_g
                Case tipo_grabacion.insertar
                    MarcaDAO.insert(marca)
                Case tipo_grabacion.modificar
                    If MarcaDAO.exists(marca) Then
                        MarcaDAO.update(marca)
                    Else
                        MsgBox("La marca " & marca.get_nombre & " no existe. Imposible modificar.", MsgBoxStyle.Exclamation, "Aviso")
                        ' Duda - Juani: Si la marca no existe y el usuario la quiere guardar, no deberiamos
                        '           redirijir internamente al insert sin informar al usuario? En este caso no hace falta el estadoGrabacion.
                    End If
            End Select

            clear_marca()
            recargar_grilla_marcas()
        End If
    End Sub

    Private Function validate_MarcaVO(ByRef marca As MarcaVO) As Boolean
        ' DUDA - Juani: El metodo deberia obtener los datos de los txtBox o que le pasen un MarcaVO y lo valide?
        If marca.get_nombre() = "" Then
            MsgBox("No puede ingresar un nombre de marca vacio.", MsgBoxStyle.Exclamation, "Aviso")
            Return False
        ElseIf MarcaDAO.is_name_in_use(marca) Then
            MsgBox("Ya existe una marca de nombre: " & marca.get_nombre, MsgBoxStyle.Exclamation, "Aviso")
            Return False
        End If

        Return True
    End Function

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        ' DOC: Valida y elimina la marca seleccionada.
        Dim marca = get_selected_MarcaVO()
        If True Then ' TODO: Validar que no haya ningun equipo relacionado a esta marca.
            ' Confirmacion
            If MessageBox.Show("Esta seguro de borrar la marca: " + marca.get_nombre(),
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
        ' DOC: Completa el formulario con la marca seleccionada y se prepara para modificarla

        txt_id.Text = marca.get_id()
        txt_nombre.Text = marca.get_nombre()
        set_tipo_g(tipo_grabacion.modificar)
        txt_nombre.Focus()
    End Sub

    Private Sub clear_marca()
        ' DOC: Vacía el formulario y lo prepara para ingresar una marca

        txt_id.Text = ""
        txt_nombre.Text = ""
        set_tipo_g(tipo_grabacion.insertar)
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
                btn_actualizar.PerformClick() ' Duda - Juani: Capaz sea mejor crear una funcion actualizar
                '             que sea llamada desde este keyDown y desde el btn_actualizar.Click
        End Select
    End Sub

    Private Sub grid_marcas_KeyDown(sender As Object, e As KeyEventArgs) Handles grid_marcas.KeyDown
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
        clear_marca()
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        clear_marca()
        Hide() ' Duda - juani: Cuando haces Show se ejecuta el load()? Porque sino no va a recargar la grilla al abrirlo de nuevo.
        ' De todas formas creo que si sale con el boton de arriba se va a cerrar... lo que habria que interceptar es el cierre
        ' del form.
    End Sub
End Class