﻿Public Class Campo
    Implements Validable

    Enum MaskType
        texto
        telefono
        celular
        porcentaje
        fecha
        cuit
        email
        comboBox
    End Enum

    ' Propiedades obligatorias.
    Public Property _id As String
    Public Property _name As String

    ' Propiedades opcionales.
    Public Property _visible As Boolean
    Public Property _maskType As MaskType
    Public Property _combo_data_source As ComboDataSource ' Solo para ser usado con BoxType.comboBox

    ' Propiedades de interfaz Validable
    Public Property _required As Boolean Implements Validable._required
    Public Property _min_lenght As Integer Implements Validable._min_lenght
    Public Property _max_lenght As Integer Implements Validable._max_lenght
    Public Property _numeric As Boolean Implements Validable._numeric

    Public Sub New(id As String, name As String,
                   Optional visible As Boolean = True,
                   Optional maskType As MaskType = MaskType.texto,
                   Optional combo_data_source As ComboDataSource = Nothing,
                   Optional required As Boolean = False,
                   Optional min_lenght As Integer = 0,
                   Optional maxLenght As Integer = 0,
                   Optional numeric As Boolean = False)
        _id = id
        _name = name
        _visible = visible
        _maskType = maskType
        _combo_data_source = combo_data_source
        _required = required
        _min_lenght = min_lenght
        _max_lenght = maxLenght
        _numeric = numeric
    End Sub

    Public Function is_valid() As Boolean Implements Validable.is_valid
        ' La clase Campo es una abstraccion. Solo almacena datos, no valida.
        Throw New NotImplementedException()
    End Function

    Public Function get_UserControl() As UserControl
        Dim control As ObjetoCampo
        If _visible Then
            Select Case _maskType
                Case MaskType.comboBox
                    control = New LabeledComboBox(_id, _name, _combo_data_source)
                Case MaskType.texto
                    control = New LabeledTextBox With {._id = _id And ._label = _name}
                Case Else
                    control = New LabeledMaskedTextBox With {._id = _id And
                                                               ._label = _name And
                                                               ._mask = _maskType}
            End Select
            'control.Name = _id
            Return Control
        Else
            control = New InvisibleControl(_id, Nothing)
        End If

        If TypeOf control Is Validable Then
            With DirectCast(control, Validable) ' Evita guardar el Cast en una variable.
                ._max_lenght = _max_lenght
                ._min_lenght = _min_lenght
                ._numeric = _numeric
                ._required = _required
            End With
        End If

        Return control
    End Function
End Class
