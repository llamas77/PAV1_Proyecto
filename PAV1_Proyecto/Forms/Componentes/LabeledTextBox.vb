Imports PAV1_Proyecto

Public Class LabeledTextBox
    Inherits UserControl
    Implements Validable

    Enum MaskType
        texto
        telefono
        celular
        porcentaje
    End Enum

    Dim mask_type As MaskType

    Public Sub New()
        Me.New("", MaskType.texto)
    End Sub

    Public Sub New(label As String, mascara As MaskType)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ' TODO: validar que mascara sea MaskType
        Me._label = label
        Me._Mask = mascara
    End Sub

    Public Property _label As String
        Get
            Return lbl_texto.Text
        End Get
        Set(ByVal value As String)
            lbl_texto.Text = value
        End Set
    End Property

    Public Property _text As String
        Get
            Return txt_caja.Text.Trim
        End Get
        Set(ByVal value As String)
            txt_caja.Text = value
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

    '
    ' Interfaz Validable
    '
    Public Property _null As Boolean Implements Validable._null

    Public Property _min_lenght As Integer Implements Validable._min_lenght
        Get
            Return 0
        End Get
        Set(value As Integer)
            valid_lenght(value, _max_length)
        End Set
    End Property

    Public Property _max_length As Integer Implements Validable._max_lenght
        Get
            Return txt_caja.Mask.Length
        End Get
        Set(value As Integer)
            valid_lenght(_min_lenght, value)
        End Set
    End Property

    Public Property _numeric As Boolean Implements Validable._numeric

    Private Sub valid_lenght(min As Integer, max As Integer)
        If _Mask = MaskType.texto Then
            txt_caja.PromptChar = " "
            txt_caja.Mask = "".PadLeft(min, "A").PadLeft(max - min, "a")
            resize_textBox()
        End If
    End Sub

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

    Public Function is_valid() As Boolean Implements Validable.is_valid
        Dim valido = True

        If Not _null Then
            If Not txt_caja.MaskCompleted Then
                ' La longitud máxima y minima se cargan en la máscara, si esta está completa es valido.
                valido = False
            End If
            If _numeric And Not IsNumeric(Me._text) Then
                valido = False
            End If
        Else
            If _numeric And _text <> "" And Not IsNumeric(_text) Then
                valido = False
            End If
        End If

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
