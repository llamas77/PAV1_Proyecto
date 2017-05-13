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

    Public Sub New(label As String, mascara As Object)
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

    Public Function valido() As Boolean
        If not_null Then
            Return Not txt_caja.MaskCompleted
        Else
            Return True
        End If
    End Function

    Public Property _Mask 'As MaskType ' Mismo error que en campo. TODO: Validar que sea de ese tipo.
        Get
            Return mask_type
        End Get
        Set(value) 'As MaskType. TODO: Validar que sea ese tipo.
            mask_type = value
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
