Public Class frm_abm_marcas
    Private Sub ABM_Marcas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        recargar_lista_marcas()
    End Sub

    Private Sub recargar_lista_marcas()
        ' TODO: Tiene que cargar la lista con las marcas de la BD
    End Sub

    Private Sub btn_actualizar_click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        ' TODO: Debe diferenciar si se trata de un nuevo elemento o de una modificacion y actuar.
        '       Validar que el campo no esta vacio y no esta repetido en la BD.
        '       Luego insertar/modificar en bd.

        ' Caso Insertar
        Dim marca = New MarcaDAO(txt_nombre.Text())
        MarcaDAO.insert(marca)
        ' Fin caso Insertar

        recargar_lista_marcas()
        txt_nombre.Text = ""
        txt_nombre.Focus()
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        ' TODO: Validar que haya UN (y solo uno) elemento en la lista. Validar que ningun equipo tenga esa marca.
        '       Pedir confirmación y borrar.
    End Sub
End Class