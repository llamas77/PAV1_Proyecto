﻿Imports PAV1_Proyecto

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
                Me.Controls(id).Text = value
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
                diccionario.Add(control.Name, control.Text)
            ElseIf TypeOf control Is LabeledComboBox Then
                Dim lcombo As LabeledComboBox = control
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
            If TypeOf control Is LabeledTextBox Then
                control.Text = ""
            ElseIf TypeOf control Is LabeledComboBox Then
                Dim lcombo As LabeledComboBox = control
                lcombo._combo.SelectedIndex = -1
            End If
        Next
    End Sub

    Public Function is_valid() As Boolean Implements ObjetoCtrl.is_valid
        Return True ' TODO: Implementar. Hay que validar que todos los campos requeridos tengan algun valor.
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
End Class