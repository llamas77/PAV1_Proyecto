Imports PAV1_Proyecto

Public Class ControlYGrilla
    Inherits UserControl
    Implements ObjetoCampo

    Private ctrl_objeto As ObjetoCtrl
    Private grilla_objeto As ObjetoGrilla

    Public Property _id As String Implements ObjetoCampo._id

    ' TODO: Usar el label en algo.
    Public Property _label As String Implements ObjetoCampo._label
        Get
            Return lbl_label.Text
        End Get
        Set(value As String)
            lbl_label.Text = value
        End Set
    End Property

    Public Property _value As Object Implements ObjetoCampo._value
        Get
            Return grilla_objeto.get_all()
        End Get
        Set(value As Object)
            ' TODO: Corregir fallo al recibir un List(Of EquiposVO) causando un fallo.
            '       Hay que castearlo.
            If TypeOf value IsNot List(Of ObjetoVO) Then
                Throw New System.Exception("El objeto debe ser del tipo List(Of ObjetoVO) explicitamente")
            End If
            grilla_objeto.recargar(value)
        End Set
    End Property

    Public Sub New(ctrl As ObjetoCtrl, grilla As ObjetoGrilla)
        'Public Sub New(objetoDAO As ObjetoDAO, Optional mask As Campo.MaskType = Campo.MaskType.controlYGrilla)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.ctrl_objeto = ctrl
        Me.grilla_objeto = grilla

        Dim control As Control
        ' Ubicar seteo de atributos. (control de objeto)
        control = ctrl_objeto
        control.Location = New Point(10, 10) ' Esquina superior izquierda.
        control.TabIndex = 1
        panel.Controls.Add(control)
        control.Focus() ' Para que empiece con el foco en el control.

        ' Posiciona boton agregar.
        btn_agregar.Location = New Point(control.Location.X + control.Size.Width / 2 - btn_agregar.Size.Width - 5,
                                         control.Location.Y + control.Size.Height + 5)
        ' Posiciona boton eliminar.
        btn_eliminar.Location = New Point(control.Location.X + control.Size.Width / 2 + 5,
                                         control.Location.Y + control.Size.Height + 5)
        ' Grilla
        control = grilla_objeto
        control.MinimumSize = New Size(panel.Size.Width, 100)
        control.Margin = New Padding(0)
        control.Location = New Point(0, btn_agregar.Location.Y + btn_agregar.Size.Height + 15)
        control.TabIndex = 3
        panel.Controls.Add(control)
    End Sub

    Public Sub New(objetoDAO As ObjetoDAO)
        Me.New(objetoDAO.get_IU_control, objetoDAO.get_IU_grilla())
    End Sub

    Private Sub agregar()
        ' Agregar un elemento al detalle.
        If ctrl_objeto.is_valid() Then
            Dim objeto As ObjetoVO = ctrl_objeto._objeto
            grilla_objeto.add_objeto(objeto)
            ctrl_objeto.Focus()
        Else
            MsgBox("Alguno/s de los valores ingresados no es/son válido/s.", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub eliminar()
        ' Elimina un elemento del detalle.
        Dim objeto = grilla_objeto.get_selected()
        If IsNothing(objeto) Then
            MsgBox("No hay nada seleccionado en la tabla.", MsgBoxStyle.MsgBoxHelp, "Aviso")
        Else
            grilla_objeto.delete_selected()
        End If
    End Sub

    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        agregar()
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        eliminar()
    End Sub

    Public Overrides Sub ResetText()
        ctrl_objeto.reset()
        grilla_objeto.recargar(New List(Of ObjetoVO))
    End Sub
End Class
