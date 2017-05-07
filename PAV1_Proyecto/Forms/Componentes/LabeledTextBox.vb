Public Class LabeledTextBox
    Public Property _label_text As String
        Get
            Return lbl_texto.Text
        End Get
        Set(ByVal value As String)
            lbl_texto.Text = value
        End Set
    End Property


    Public Overrides Property Text As String
        Get
            Return txt_caja.Text
        End Get
        Set(ByVal value As String)
            txt_caja.Text = value
        End Set
    End Property
End Class
