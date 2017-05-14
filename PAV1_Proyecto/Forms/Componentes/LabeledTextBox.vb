Public Class LabeledTextBox
    Inherits UserControl

    Enum MaskType
        texto
        telefono
        celular
        porcentaje
    End Enum

    Dim not_null As Boolean = True
    Dim mask_type As MaskType

    Public Sub New()
        Me.New("", MaskType.texto)
    End Sub

    Public Sub New(label As String, mascara As MaskType)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ' TODO: validar que mascara sea MaskType
        Me._label_text = label
        Me._Mask = mascara
    End Sub

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
            If mask_type = MaskType.porcentaje Then
                Return txt_caja.Text.Trim.Replace("_", "")
            Else
                Return txt_caja.Text.Trim
            End If
        End Get
        Set(ByVal value As String)
            txt_caja.Text = value
        End Set
    End Property

    Public Property _max_length As Integer
        Get
            Return txt_caja.Mask.Length
        End Get
        Set(value As Integer)
            If _Mask = MaskType.texto Then
                txt_caja.PromptChar = " "
                txt_caja.Mask = "".PadLeft(value, "a") ' Crea un string de "aaa", tantas como indique value.
                resize_textBox()
            End If
        End Set
    End Property

    Public Property _Mask As MaskType
        Get
            Return mask_type
        End Get
        Set(value As MaskType)
            mask_type = value
            txt_caja.PromptChar = "_" ' Lo reseteo por si se uso _max_length antes.
            Select Case mask_type
                Case MaskType.texto
                    txt_caja.Mask = ""
                Case MaskType.telefono
                    txt_caja.Mask = "9000-40000009"
                Case MaskType.celular
                    txt_caja.Mask = "9000-150-000000"
                Case MaskType.porcentaje
                    txt_caja.Mask = "09%"
            End Select
            resize_textBox()
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

    Public Function valido() As Boolean
        If not_null Then
            Return Not txt_caja.MaskCompleted
        Else
            Return True
        End If
    End Function

    Private Sub resize_textBox()
        If txt_caja.Mask.Length > 0 Then
            If txt_caja.Mask.Length > 10 Then
                txt_caja.Size = New Size(txt_caja.Mask.Length * 8, txt_caja.Size.Height)
            Else
                txt_caja.Size = New Size(txt_caja.Mask.Length * 12, txt_caja.Size.Height)
            End If
            ' La siguiente linea establece el ancho del control. Actualmente txt_caja tiene un ancho máximo
            ' Y ese va a ser siempre el tamaño del control.
            'Me.Size = New Size(lbl_texto.Size.Width + txt_caja.Size.Width, Me.Size.Height)
        End If
    End Sub
End Class
