Public Class frm_abm_generico_busqueda
    Dim ctrl_objeto As ObjetoCtrl
    Dim grilla_objeto As ObjetoGrilla
    Dim DAO_objeto As ObjetoDAO

    Public Sub New(ctrl_objeto As ObjetoCtrl, grilla_objeto As ObjetoGrilla, objetoDAO As ObjetoDAO)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' TODO: Refactor a esta funcion. Reacomodar.
        Me.ctrl_objeto = ctrl_objeto
        Me.grilla_objeto = grilla_objeto
        Me.DAO_objeto = objetoDAO

        ' Ubicar grilla del objeto.
        Dim control As Control = grilla_objeto
        control.MinimumSize = New Size(438, 150)
        control.Location = New Point(Me.Padding.Left, btn_nuevo.Location.Y + btn_nuevo.Size.Height + 15)
        control.TabIndex = 3
        Me.Controls.Add(control)
    End Sub

    Public Sub New(objetoDAO As ObjetoDAO)
        Me.New(objetoDAO.get_IU_control, objetoDAO.get_IU_grilla, objetoDAO)
    End Sub

    Private Sub frm_abm_generico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        grilla_objeto.recargar(DAO_objeto.all())
    End Sub

    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        Dim frm As New frm_control_generico(DAO_objeto)
        frm.ShowDialog()
        grilla_objeto.recargar(DAO_objeto.all())
    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        Dim objeto As ObjetoVO = grilla_objeto.get_selected()
        If IsNothing(objeto) Then
            MsgBox("No hay nada seleccionado en la tabla.", MsgBoxStyle.MsgBoxHelp, "Aviso")
        Else
            Dim frm As New frm_control_generico(DAO_objeto)

            frm.set_objeto(objeto)
            frm.ShowDialog()
            grilla_objeto.recargar(DAO_objeto.all())
        End If
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        Dim objeto = grilla_objeto.get_selected()
        If IsNothing(objeto) Then
            ' Error: No hay nada seleccionado en la grilla.
            MsgBox("No hay nada seleccionado en la tabla.", MsgBoxStyle.MsgBoxHelp, "Aviso")
        Else
            If MessageBox.Show("Esta seguro de borrar: " + objeto.toString(),
                               "Importante", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                DAO_objeto.delete(objeto)
                grilla_objeto.recargar(DAO_objeto.all())
            End If
        End If
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub
End Class