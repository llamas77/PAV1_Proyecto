Public Class LabeledTextBox
    Dim not_null As Boolean = True
    Dim mask_type As Mascara = Mascara.texto
    Enum Mascara
        texto
        telefono
        celular
        porcentaje
    End Enum

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
            If mask_type = Mascara.porcentaje Then
                Return txt_caja.Text.Trim.Replace("_", "")
            Else
                Return txt_caja.Text.Trim
            End If
        End Get
        Set(ByVal value As String)
            txt_caja.Text = value
        End Set
    End Property

    Public Function valido() As Boolean
        If not_null Then
            Return Not txt_caja.MaskCompleted
        Else
            Return True
        End If
    End Function

    Public Property _Mask As Mascara
        Get
            Return mask_type
        End Get
        Set(value As Mascara)
            mask_type = value
            Select Case mask_type
                Case Mascara.texto
                    txt_caja.Mask = ""
                Case Mascara.telefono
                    txt_caja.Mask = "9000-40000009"
                Case Mascara.celular
                    txt_caja.Mask = "9000-150-0000009"
                Case Mascara.porcentaje
                    txt_caja.Mask = "099%"
            End Select
        End Set
    End Property

    Public Property _Not_Null As Boolean
        Get
            Return not_null
        End Get
        Set(value As Boolean)
            not_null = value
        End Set
    End Property
End Class
