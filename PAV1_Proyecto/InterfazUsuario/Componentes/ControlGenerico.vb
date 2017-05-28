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

    Private fabrica As ObjectFactory
    Private next_point As New Point(0, 0)

    Public Property _objeto As ObjetoVO Implements ObjetoCtrl._objeto
        Get
            ' Lee lo que el usuario escribio o modifico en los TextBox, lo convierte
            ' a diccionario y se lo pasa a la fabrica para que cree un ObjetoVO.
            Return fabrica.new_instance(read_controls())
        End Get
        Set(value As ObjetoVO)
            ' Obtiene un diccionario a partir del objetoVO y lo recorre cambiando
            ' los valores de los TextBox por el indicado en el diccionario.
            Me.reset()
            Dim objeto = value.toDictionary()
            For Each key In objeto.Keys
                set_control(key, objeto(key))
            Next
        End Set
    End Property

    Public Sub New(estructura As List(Of Campo), fabrica As ObjectFactory)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.fabrica = fabrica
        Me.add_campos(estructura)
    End Sub

    Private Sub set_control(id As String, value As Object)
        ' Busca el control que representa la variable id y cambia su valor por value.
        For Each campo As ObjetoCampo In Me.Controls
            ' Si llegase a haber 2 campos con el mismo id modifica al mismo 2 veces.
            If campo._id = id Then
                campo._value = value
                Exit For
            End If
        Next
    End Sub

    Private Function read_controls() As Dictionary(Of String, Object)
        ' Lee todos los campos y guarda sus valores en un diccionario.
        Dim diccionario As New Dictionary(Of String, Object)
        For Each campo As ObjetoCampo In Me.Controls
            ' Si llegase a haber 2 campos con el mismo id guarda el valor del ultimo en recorrer.
            '   Pero se desconoce el orden de recorrido, es arbitrario cual se almacena.
            diccionario.Add(campo._id, campo._value)
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

    Public Sub add_campos(campos As List(Of Campo))
        For Each campo In campos
            Dim control As Control = campo.get_UserControl()

            ' Situa un control en la ventana. Va situando uno debajo del otro.
            control.Location = next_point
            next_point.Y = next_point.Y + control.Height
            Me.Controls.Add(control)
        Next
    End Sub

    Public Overloads Sub Focus() Implements ObjetoCtrl.Focus
        MyBase.Focus()
    End Sub
End Class
