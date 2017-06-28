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
            Dim val = txt_caja.Text.Trim()
            If _numeric And val = "" Then
                Return 0
            Else
                Return val
            End If
        End Get
        Set(value As Object)
            txt_caja.Text = value.ToString
        End Set
    End Property

    '
    '  -- Interfaz Validable
    '
    Public Property _required As Boolean Implements Validable._required
    Public Property _min_lenght As Integer Implements Validable._min_lenght
    Public Property _max_lenght As Integer Implements Validable._max_lenght
        Get
            Return txt_caja.MaxLength
        End Get
        Set(value As Integer)
            txt_caja.MaxLength = value
        End Set
    End Property
    Public Property _numeric As Boolean Implements Validable._numeric

    Public Function is_valid() As Boolean Implements Validable.is_valid
        Dim valido = True
        If _required Then
            If txt_caja.Text.Trim = "" Then
                ' La longitud máxima y minima se cargan en la máscara, si esta está completa es valido.
                valido = False
            End If
        End If
        If _numeric And Not IsNumeric(_value) Then
            valido = False
        End If
        If _min_lenght > 0 And _value.ToString.Length < _min_lenght Then
            valido = False
        End If
        ' El maxLength lo valida automaticamente el TextBox

        ' Marcar en Rojo
        If Not valido Then
            lbl_texto.ForeColor = System.Drawing.Color.Red
        End If
        Return valido
    End Function

    Public Overrides Sub ResetText()
        MyBase.ResetText()
        txt_caja.ResetText()
        lbl_texto.ForeColor = System.Drawing.SystemColors.ControlText
    End Sub

    Private Sub txt_caja_TextChanged(sender As Object, e As EventArgs) Handles txt_caja.TextChanged
        ' Reestablece el color de fondo por si estaba en error
        lbl_texto.ForeColor = System.Drawing.SystemColors.ControlText
    End Sub
End Class
