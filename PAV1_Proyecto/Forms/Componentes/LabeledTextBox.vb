﻿Imports PAV1_Proyecto

Public Class LabeledTextBox
    Inherits UserControl
    Implements Validable

    Dim mask_type As Campo.MaskType

    Public Sub New()
        Me.New("", Campo.MaskType.texto)
    End Sub

    Public Sub New(label As String, mascara As Campo.MaskType)
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

    Public Property _Mask As Campo.MaskType
        Get
            Return mask_type
        End Get
        Set(value As Campo.MaskType)
            mask_type = value
            txt_caja.PromptChar = "_" ' Lo reseteo por si se uso _max_length antes.
            Select Case mask_type
                Case Campo.MaskType.texto
                    txt_caja.Mask = ""
                Case Campo.MaskType.telefono
                    txt_caja.Mask = "9000-4000009"
                Case Campo.MaskType.celular
                    txt_caja.Mask = "9000-150-000000"
                Case Campo.MaskType.porcentaje
                    txt_caja.Mask = "09%"
                Case Campo.MaskType.fecha
                    txt_caja.Mask = "00/00/0000"
                Case Campo.MaskType.cuit
                    txt_caja.Mask = "00-00000000-0"
                Case Campo.MaskType.email
                    txt_caja.Mask = "" ' TODO: Validar que el mail tiene un @
            End Select
            resize_textBox()
        End Set
    End Property

    '
    ' Interfaz Validable
    '
    Public Property _required As Boolean Implements Validable._required

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
        If _Mask = Campo.MaskType.texto Then
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

        If _required Then
            If Not txt_caja.MaskCompleted Or txt_caja.Text = "" Then
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
