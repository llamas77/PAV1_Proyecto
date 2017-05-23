Imports PAV1_Proyecto

Public Class ControlGenerico
    Inherits UserControl
    Implements ObjetoCtrl
    '
    ' El control generico establece su estructura a partir de una lista de campos
    ' y es capaz de validar la entrada del usuario.
    ' Por cada campo muestra una fila con un LabeledTextBox correspondiente.
    '
    ' Nota: En los comentarios se nombre LabeledTextBox o TextBox, pero el control
    '       es capaz de manejar ComboBox tambien.
    '

    Dim fabrica As ObjectFactory
    Dim fabrica_combo As New Dictionary(Of String, ComboDataSource)
    Dim next_point As New Point(0, 0)
    ' Todos los Campos que sean invisibles seran almacenados por el control, el usuario
    ' no los podra modificar.
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
            ' Lee lo que el usuario escribio o modifico en los TextBox, lo convierte
            ' a diccionario y se lo pasa a la fabrica para que cree un ObjetoVO.
            Return fabrica.new_instance(read_controls())
        End Get
        Set(value As ObjetoVO)
            ' Obtiene un diccionario a partir del objetoVO y lo recorre cambiando
            ' los valores de los TextBox por el indicado en el diccionario.
            Dim objeto = value.toDictionary()
            For Each key In objeto.Keys
                set_control(key, objeto(key))
            Next
        End Set
    End Property

    Private Sub set_control(id As String, value As Object)
        ' Busca el control que representa la variable id y cambia su valor por value.
        If campos_invisibles.ContainsKey(id) Then
            campos_invisibles(id) = value
        ElseIf Me.Controls.ContainsKey(id) Then
            If TypeOf Me.Controls(id) Is LabeledTextBox Then
                ' Si el control es LabeledTextBox cambia el texto.
                Dim ltext As LabeledTextBox = Controls(id)
                ltext._text = value
            ElseIf TypeOf Me.Controls(id) Is LabeledComboBox Then
                ' Si el control es ComboBox cambia el valor elegido.
                Dim lcmb As LabeledComboBox = Me.Controls(id)
                lcmb._value = value
            End If
        End If
    End Sub

    Private Function read_controls() As Dictionary(Of String, Object)
        ' Lee todos los textbox del control y guarda sus valores en un diccionario.
        Dim diccionario As New Dictionary(Of String, Object)
        For Each control As Control In Me.Controls
            If TypeOf control Is LabeledTextBox Then
                Dim ltext As LabeledTextBox = control
                diccionario.Add(control.Name, ltext._text)
            ElseIf TypeOf control Is LabeledComboBox Then
                Dim lcombo As LabeledComboBox = control
                diccionario.Add(control.Name, lcombo._value)
            End If
        Next
        For Each key In campos_invisibles.Keys
            ' Los campos invisibles estan guardados aparte.
            diccionario.Add(key, campos_invisibles(key))
        Next
        Return diccionario
    End Function

    Public Sub reset() Implements ObjetoCtrl.reset
        ' -- Nota: Tal vez haga falta recargar los ComboBox, si alguien lo necesita
        '          agregelo a la implementacion.
        ' Resetea todos los TextBox y ComboBox
        For Each control As Control In Me.Controls
            control.ResetText()
        Next
        ' Resetea todos los campos invisibles tambien.
        Dim nuevo_diccionario As New Dictionary(Of String, Object)
        For Each campo In campos_invisibles.Keys
            nuevo_diccionario.Add(campo, Nothing)
        Next
        campos_invisibles = nuevo_diccionario
    End Sub

    Public Function is_valid() As Boolean Implements ObjetoCtrl.is_valid
        ' Ejecuta la validacion de todos los TextBox y ComboBox y retorna su resultado.
        ' Nota: No valida los campos invisibles porque el usuario no los puede modificar.
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
        ' Lee la estructura del campo y altera la estructura del control para
        ' asimilarse.
        For Each campo In estructura
            If campo._visible Then
                Dim control As Control
                Select Case campo._maskType
                    Case Campo.MaskType.comboBox
                        control = New LabeledComboBox(campo._id, campo._name, campo._combo_data_source)
                        fabrica_combo.Add(campo._id, campo._combo_data_source)
                    Case Else
                        Dim lctrl = New LabeledTextBox(campo._name, campo._maskType)
                        lctrl._required = campo._required
                        lctrl._numeric = campo._numeric
                        If campo._max_lenght > 0 Then
                            lctrl._max_length = campo._max_lenght
                        End If
                        control = lctrl
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

    Public Overloads Sub Focus() Implements ObjetoCtrl.Focus
        MyBase.Focus()
    End Sub
End Class
