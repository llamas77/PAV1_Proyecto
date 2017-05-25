Imports System.ComponentModel

Public Class frm_control_generico
    Dim ctrl_objeto As ObjetoCtrl
    Dim DAO_objeto As ObjetoDAO

    Public Sub New(ctrl_objeto As ObjetoCtrl, objetoDAO As ObjetoDAO)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' TODO: Refactor a esta funcion. Reacomodar.
        Me.ctrl_objeto = ctrl_objeto
        Me.DAO_objeto = objetoDAO

        Dim control As Control
        ' Ubicar seteo de atributos. (control de objeto) y boton actualizar.
        control = ctrl_objeto
        control.Location = New Point(Me.Padding.Left, Me.Padding.Top) ' Esquina superior izquierda.
        control.TabIndex = 1
        Me.Controls.Add(control)
        control.Focus() ' Para que empiece con el foco en el control.

        ' Posiciona los botones.
        Dim point = New Point((Size.Width / 2) - 30, control.Location.Y + control.Size.Height + 15)
        btn_actualizar.Location = New Point(point.X - btn_actualizar.Size.Width, point.Y)
        btn_cancelar.Location = New Point(point.X + 10, point.Y)
    End Sub

    Public Sub New(objetoDAO As ObjetoDAO)
        Me.New(objetoDAO.get_IU_control, objetoDAO)
    End Sub

    Public Sub set_objeto(objeto As ObjetoVO)
        ctrl_objeto._objeto = objeto
    End Sub

    Private Sub actualizar_objeto()
        If ctrl_objeto.is_valid() Then
            Dim objeto = ctrl_objeto._objeto

            If DAO_objeto.exists(objeto) Then
                DAO_objeto.update(objeto)
                MsgBox("Modificado correctamente")
            Else
                DAO_objeto.insert(objeto)
                MsgBox("Agregado correctamente")
            End If
            Me.Close()
        Else
            MsgBox("Alguno/s de los valores ingresados no es/son válido/s.", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        actualizar_objeto()
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub frm_control_generico_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                actualizar_objeto()
        End Select
    End Sub

    Private Sub frm_control_generico_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class