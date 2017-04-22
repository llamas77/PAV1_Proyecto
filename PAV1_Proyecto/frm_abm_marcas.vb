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

    Private Sub recargar_grilla_marcas()
        ' TODO: Tiene que cargar la lista con las marcas de la BD
        grid_marcas.Rows.Clear()
        Dim marcas = New DataTable
        MarcaDAO.all(marcas)

        For i = 0 To marcas.Rows.Count() - 1
            grid_marcas.Rows.Add()
            grid_marcas.Rows(i).Cells(0).Value = marcas(i)(0)
            grid_marcas.Rows(i).Cells(1).Value = marcas(i)(1)
        Next
    End Sub

    Private Sub btn_actualizar_click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        ' TODO: Validar que el campo no esta vacio y no esta repetido en la BD.
        If estado = estado_grabacion.insertar Then
            Dim marca = New MarcaVO(txt_nombre.Text())
            MarcaDAO.insert(marca)
        Else
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
        ' TODO: Validar que haya UN (y solo uno) elemento en la lista. Validar que ningun equipo tenga esa marca.
        '       Pedir confirmación y borrar.
    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Dim marca = grid_marcas.CurrentRow()
        load_marca(marca.Cells(0).Value, marca.Cells(1).Value)
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
End Class