Imports PAV1_Proyecto

Public Class Detalle
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
            ' No esta probado e idealmente no deberia usarse...
            grilla_objeto.recargar(value)
        End Set
    End Property

    Private Sub New(ctrl_objeto As ObjetoCtrl, grilla As ObjetoGrilla)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        Me.ctrl_objeto = ctrl_objeto
        Me.grilla_objeto = grilla

        Dim control As Control
        ' Ubicar seteo de atributos. (control de objeto)
        control = ctrl_objeto
        control.Location = New Point(lbl_label.Location.X, lbl_label.Location.Y + lbl_label.Height) ' Esquina superior izquierda.
        control.TabIndex = 1
        Me.Controls.Add(control)
        control.Focus() ' Para que empiece con el foco en el control.

        ' Posiciona boton agregar.
        btn_agregar.Location = New Point(control.Location.X + control.Size.Width - btn_agregar.Size.Width - 3,
                                         control.Location.Y + control.Size.Height)

        ' Grilla
        control = grilla_objeto
        control.MinimumSize = New Size(btn_agregar.Location.X + btn_agregar.Size.Width, 100)
        control.Location = New Point(Me.Padding.Left, btn_agregar.Location.Y + btn_agregar.Size.Height + 15)
        control.TabIndex = 3
        Me.Controls.Add(control)

        btn_eliminar.Location = New Point(control.Location.X + control.Size.Width - btn_eliminar.Size.Width,
                                          control.Location.Y + control.Size.Height + 3)
    End Sub

    Public Sub New(objetoDAO As ObjetoDAO)
        Me.New(objetoDAO.get_IU_control, objetoDAO.get_IU_grilla)
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
End Class
