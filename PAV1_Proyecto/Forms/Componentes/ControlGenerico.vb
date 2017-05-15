Imports PAV1_Proyecto

Public Class ControlGenerico
    Inherits UserControl
    Implements ObjetoCtrl

    Dim fabrica As ObjectFactory
    Dim fabrica_combo As New Dictionary(Of String, ComboDataSource)
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
            Dim objeto = value.toDictionary()
            For Each key In objeto.Keys
                set_control(key, objeto(key))
            Next
        End Set
    End Property

    Private Sub set_control(id As String, value As Object)
        If campos_invisibles.ContainsKey(id) Then
            campos_invisibles(id) = value
        ElseIf Me.Controls.ContainsKey(id) Then
            If TypeOf Me.Controls(id) Is LabeledTextBox Then
                Dim ltext As LabeledTextBox = Controls(id)
                ltext._text = value
            ElseIf TypeOf Me.Controls(id) Is LabeledComboBox Then
                Dim lcmb As LabeledComboBox = Me.Controls(id)
                lcmb._combo.SelectedValue = value
            End If
        End If
    End Sub

    Private Function read_controls() As Dictionary(Of String, Object)
        Dim diccionario As New Dictionary(Of String, Object)
        For Each control As Control In Me.Controls
            If TypeOf control Is LabeledTextBox Then
                Dim ltext As LabeledTextBox = control
                diccionario.Add(control.Name, ltext._text)
            ElseIf TypeOf control Is LabeledComboBox Then
                Dim lcombo As LabeledComboBox = control
                ' Trae el objeto que tiene seleccionado el combo.
                'Dim objeto = (fabrica_combo(lcombo.Name)).get_object_from_combo(, lcombo._combo.Text)
                diccionario.Add(control.Name, lcombo._combo.SelectedValue)
            End If
        Next
        For Each key In campos_invisibles.Keys
            diccionario.Add(key, campos_invisibles(key))
        Next
        Return diccionario
    End Function

    Public Sub reset() Implements ObjetoCtrl.reset
        For Each control As Control In Me.Controls
            control.ResetText()
        Next
    End Sub

    Public Function is_valid() As Boolean Implements ObjetoCtrl.is_valid
        Dim valido = True
        For Each control In Me.Controls
            If TypeOf control Is Validable Then
                Dim validable As Validable = control
                valido = IIf(validable.is_valid(), valido, False) ' Si es valido dejo el flag como esta, sino lo bajo.
            End If
        Next
        Return valido
    End Function

    Public Sub set_structure(estructura As List(Of Campo))
        For Each campo In estructura
            If campo._visible Then
                Dim control As Control
                Select Case campo._boxType
                    Case Campo.BoxType.maskedTextBox
                        Dim lctrl = New LabeledTextBox(campo._name, campo._maskType)
                        lctrl._required = campo._required
                        lctrl._numeric = campo._numeric
                        If campo._max_lenght > 0 Then
                            lctrl._max_length = campo._max_lenght
                        End If
                        control = lctrl
                    Case Campo.BoxType.comboBox
                        control = New LabeledComboBox(campo._name)
                        fabrica_combo.Add(campo._id, campo._combo_data_source)
                        load_combo(control, campo._combo_data_source)
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

    Private Sub load_combo(labeledCombo As LabeledComboBox, dataSource As ComboDataSource)
        Dim combo As ComboBox = labeledCombo._combo
        Dim tabla = dataSource.comboSource()
        combo.DataSource = tabla
        combo.ValueMember = tabla.Columns(0).ColumnName
        combo.DisplayMember = tabla.Columns(1).ColumnName
        combo.SelectedIndex = -1 ' Para evitar que seleccione el primer elemento por defecto
    End Sub

    Public Overloads Sub Focus() Implements ObjetoCtrl.Focus
        MyBase.Focus()
    End Sub
End Class
