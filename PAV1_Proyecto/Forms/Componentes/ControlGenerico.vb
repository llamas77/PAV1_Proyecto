Imports PAV1_Proyecto

Public Class ControlGenerico
    Inherits UserControl
    Implements ObjetoCtrl

    Dim fabrica As ObjectFactory
    Dim next_point As New Point(0, 0)
    Dim campos_invisibles As New Dictionary(Of String, Object)

    Public Sub New(estructura As List(Of Campo), fabrica As ObjectFactory)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.fabrica = fabrica
        Me.set_structure(estructura)
    End Sub

    Public Property _objeto As ObjetoVO Implements ObjetoCtrl._objeto
        Get
            Return fabrica.new_instance(read_controls())
        End Get
        Set(value As ObjetoVO)
            ' TODO: Añadir function a ObjetoVO para que se muestre en forma de diccionario.
            Throw New NotImplementedException()
        End Set
    End Property

    Private Function read_controls() As Dictionary(Of String, Object)
        Dim diccionario As New Dictionary(Of String, Object)
        For Each control As Control In Me.Controls
            If TypeOf control Is LabeledTextBox Then
                diccionario.Add(control.Name, control.Text)
            ElseIf TypeOf control Is LabeledComboBox Then
                Dim lcombo As LabeledComboBox = control
                diccionario.Add(control.Name, lcombo._combo.SelectedValue)
            End If
        Next
        Return diccionario.Union(campos_invisibles)
    End Function

    Public Sub reset() Implements ObjetoCtrl.reset
        For Each control As Control In Me.Controls
            If TypeOf control Is LabeledTextBox Then
                control.Text = ""
            ElseIf TypeOf control Is LabeledComboBox Then
                Dim lcombo As LabeledComboBox = control
                lcombo._combo.SelectedIndex = -1
            End If
        Next
    End Sub

    Public Function is_valid() As Boolean Implements ObjetoCtrl.is_valid
        Throw New NotImplementedException()
    End Function

    Public Sub set_structure(estructura As List(Of Campo))
        For Each campo In estructura
            If campo._visible Then
                Dim control As Control
                Select Case campo._boxType
                    Case Campo.BoxType.maskedTextBox
                        Dim lctrl = New LabeledTextBox(campo._name, campo._maskType)
                        If campo._maxLenght > 0 Then
                            lctrl._max_length = campo._maxLenght
                        End If
                        control = lctrl
                    Case Campo.BoxType.comboBox
                        control = New LabeledComboBox(campo._name)
                    Case Else
                        Return
                End Select
                control.Name = campo._id
                add_control(control)
            Else
                campos_invisibles.Add(campo._id, Nothing)
            End If
        Next
    End Sub

    Private Sub add_control(control As Control)
        ' Situa un control en la ventana. Va situando uno debajo del otro.
        control.Location = next_point
        next_point.Y = next_point.Y + control.Height
        Me.Controls.Add(control)
    End Sub

    Private Sub reset_controls()
        Me.Controls.Clear()
        next_point = New Point(0, 0)
    End Sub

    Public Sub load_combo(idCombo As String, datos As DataTable, value As String, display As String)
        Dim combos = Me.Controls.Find(idCombo, False)
        ' TODO: Validar que haya un solo (ni mas ni menos) combo y sea de tipo LabeledComboBox.
        Dim labeledCombo As LabeledComboBox = combos(0)
        Dim combo As ComboBox = labeledCombo._combo
        combo.DataSource = datos
        combo.ValueMember = value
        combo.DisplayMember = display
        combo.SelectedIndex = -1 ' Para evitar que seleccione el primer elemento por defecto
    End Sub
End Class
