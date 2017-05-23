Imports PAV1_Proyecto

Public Class InvisibleControl
    Inherits UserControl
    Implements ObjetoCampo, Validable

    '
    '   DOC: Es una abstraccion de control. No se muestra al usuario.
    '

    Public Sub New(id As String, valor As Object)
        ' Oculta el control. Es invisible.
        Me.Visible = False
        Me.Size = New Size(0, 0)

        Me._id = id
        Me._value = valor
    End Sub

    '
    ' -- Interfaz Objeto Campo
    '
    Public Property _id As String Implements ObjetoCampo._id
    Public Property _label As String Implements ObjetoCampo._label
    Private Property _value As Object Implements ObjetoCampo._value

    '
    ' -- Interfaz Validable
    '
    Public Property _required As Boolean Implements Validable._required
    Public Property _min_lenght As Integer Implements Validable._min_lenght
    Public Property _max_lenght As Integer Implements Validable._max_lenght
    Public Property _numeric As Boolean Implements Validable._numeric

    Public Function is_valid() As Boolean Implements Validable.is_valid
        Dim valido = True
        If _required Then
            If _value Is Nothing Then
                valido = False
            ElseIf _numeric And Not IsNumeric(_value) Then
                valido = False
            End If
        Else
            If _numeric And _value IsNot Nothing And Not IsNumeric(_value) Then
                valido = False
            End If
        End If

        Return valido
    End Function
End Class
