Imports PAV1_Proyecto

Public Class LabeledMaskedTextBox
    Inherits UserControl
    Implements ObjetoCampo, Validable

    Dim mask_type As Campo.MaskType

    Public Sub New()
        Me.New("Sin Datos", Campo.MaskType.email)
    End Sub

    Public Sub New(label As String, mascara As Campo.MaskType)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        ' TODO: validar que mascara sea MaskType
        _label = label
        _mask = mascara
    End Sub

    Public Property _mask As Campo.MaskType
        Get
            Return mask_type
        End Get
        Set(value As Campo.MaskType)
            mask_type = value
            txt_caja.PromptChar = "_" ' Lo reseteo por si se uso _max_length antes.
            Select Case mask_type
                Case Campo.MaskType.telefono
                    txt_caja.Mask = "9000-4000009"
                Case Campo.MaskType.celular
                    txt_caja.Mask = "9000-150-000000"
                Case Campo.MaskType.porcentaje
                    txt_caja.Mask = "099%"
                    txt_caja.PromptChar = " "
                Case Campo.MaskType.fecha
                    txt_caja.Mask = "00/00/0000"
                Case Campo.MaskType.cuit
                    txt_caja.Mask = "00-00000000-0"
                Case Campo.MaskType.email
                    txt_caja.Mask = "" ' TODO: Validar que el mail tiene un @
                Case Else
                    ' Ignora todos los otros MaskType
                    txt_caja.Mask = ""
            End Select
            resize_textBox()
        End Set
    End Property

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

    '
    '  -- Interfaz ObjetoCampo
    '
    Public Property _id As String Implements ObjetoCampo._id
    Public Property _label As String Implements ObjetoCampo._label
        Get
            Return lbl_texto.Text.Trim
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
            Return txt_caja.Text.Trim
        End Get
        Set(ByVal value As Object)
            If TypeOf value Is String Then
                txt_caja.Text = value
            Else
                Throw New System.Exception("Un MaskedTextBox solo acepta valores del tipo String")
            End If
        End Set
    End Property

    '
    ' Interfaz Validable
    '
    Public Property _required As Boolean Implements Validable._required
    Public Property _min_lenght As Integer Implements Validable._min_lenght
    Public Property _max_length As Integer Implements Validable._max_lenght
    Public Property _numeric As Boolean Implements Validable._numeric



    Public Function is_valid() As Boolean Implements Validable.is_valid
        Dim valido = True
        If _required Then
            If Not txt_caja.MaskCompleted Then
                ' La longitud máxima y minima se cargan en la máscara, si esta está completa es valido.
                valido = False
            End If
            If _numeric And Not IsNumeric(_value) Then
                valido = False
            End If
        Else
            If _numeric And _value <> "" And Not IsNumeric(_value) Then
                valido = False
            End If
        End If

        If _mask = Campo.MaskType.fecha And _value <> "/  /" Then
            If txt_caja.MaskCompleted Then
                Try
                    DateTime.ParseExact(_value, "dd/MM/yyyy", Nothing)
                Catch ex As Exception
                    valido = False
                End Try
            Else
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
