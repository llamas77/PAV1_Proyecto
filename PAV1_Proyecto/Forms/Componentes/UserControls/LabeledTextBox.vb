Imports PAV1_Proyecto

Public Class LabeledTextBox
    Inherits UserControl
    Implements ObjetoCampo, Validable

    '
    '  -- Interfaz ObjetoCampo
    '
    Public Property _id As String Implements ObjetoCampo._id

    Public Property _label As String Implements ObjetoCampo._label
        Get
            Return lbl_texto.Text
        End Get
        Set(ByVal value As String)
            lbl_texto.Text = value
            ' Asegura que el texto siempre sea visible.
            If lbl_texto.PreferredSize.Width > lbl_texto.Width Then
                Dim add As Integer = lbl_texto.PreferredSize.Width - lbl_texto.Width
                lbl_texto.Width += add
                txt_caja.Location = New Point(txt_caja.Location.X + add, txt_caja.Location.Y)
            End If
        End Set
    End Property

    Public Property _value As Object Implements ObjetoCampo._value
        Get
            Return txt_caja.Text.Trim()
        End Get
        Set(value As Object)
            If TypeOf value Is String Then
                txt_caja.Text = value
            Else
                Throw New System.Exception("Un TextBox solo acepta valores del tipo String")
            End If
        End Set
    End Property

    '
    '  -- Interfaz Validable
    '
    Public Property _required As Boolean Implements Validable._required
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Boolean)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property _min_lenght As Integer Implements Validable._min_lenght
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property _max_lenght As Integer Implements Validable._max_lenght
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property _numeric As Boolean Implements Validable._numeric
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Boolean)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Function is_valid() As Boolean Implements Validable.is_valid
        Throw New NotImplementedException()
    End Function
End Class
