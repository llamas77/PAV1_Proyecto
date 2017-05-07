﻿Public Class frm_abm_generico
    Dim ctrl_objeto As ObjetoCtrl
    Dim grilla_objeto As ObjetoGrilla
    Dim objetoDAO As ObjetoDAO

    Public Sub New(ctrl_objeto As ObjetoCtrl, grilla_objeto As ObjetoGrilla, objetoDAO As ObjetoDAO)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' TODO: Refactor a esta funcion. Reacomodar.
        Me.ctrl_objeto = ctrl_objeto
        Me.grilla_objeto = grilla_objeto
        Me.objetoDAO = objetoDAO

        Dim control As Control = ctrl_objeto
        control.Location = New Point(15, 15)
        Me.Controls.Add(control)
        btn_actualizar.Location = New Point(control.Size.Width + 15, control.Size.Height - btn_actualizar.Size.Height / 2)

        Dim control2 As Control = grilla_objeto
        control2.Location = New Point(15, control.Size.Height + 15)
        Me.Controls.Add(control2)

        ' Posiciona los botones.
        Dim point = New Point(15, control2.Location.Y + control2.Size.Height + 15)
        btn_modificar.Location = point
        point.X += btn_modificar.Size.Width + 20
        btn_eliminar.Location = point
        point.X += btn_eliminar.Size.Width + 50
        btn_cancelar.Location = point
        point.X += btn_cancelar.Size.Width + 20
        btn_salir.Location = point
    End Sub

    Private Sub frm_abm_generico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grilla_objeto.recargar(objetoDAO.all())
    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        If ctrl_objeto.is_valid() Then
            Dim objeto = ctrl_objeto._objeto

            If objetoDAO.exists(objeto) Then
                objetoDAO.update(objeto)
            Else
                objetoDAO.insert(objeto)
            End If
            grilla_objeto.recargar(objetoDAO.all())
        End If
    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Dim objeto = grilla_objeto.get_selected()
        If IsNothing(objeto) Then
            ' Error: No hay nada seleccionado en la grilla.
            ' TODO: Informar al usuario.
        Else
            ctrl_objeto._objeto = objeto
        End If
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Dim objeto = grilla_objeto.get_selected()
        If IsNothing(objeto) Then
            ' Error: No hay nada seleccionado en la grilla.
            ' TODO: Informar al usuario.
        Else
            If MessageBox.Show("Esta seguro de borrar: " + objeto.toString(),
                               "Importante", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                objetoDAO.delete(objeto)
                grilla_objeto.recargar(objetoDAO.all())
            End If
        End If
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        ctrl_objeto.reset()
    End Sub
End Class