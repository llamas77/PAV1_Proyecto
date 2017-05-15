Imports PAV1_Proyecto

Public Class Campo
    Implements Validable

    Private maskType As LabeledTextBox.MaskType

    Enum BoxType
        maskedTextBox
        comboBox
    End Enum

    ' Propiedades obligatorias.
    Public Property _id As String
    Public Property _name As String

    ' Propiedades opcionales.
    Public Property _visible As Boolean
    Public Property _maskType As LabeledTextBox.MaskType
    Public Property _boxType As BoxType
    Public Property _combo_data_source As ComboDataSource ' Solo para ser usado con BoxType.comboBox

    ' Propiedades de interfaz Validable
    Public Property _required As Boolean Implements Validable._required
    Public Property _min_lenght As Integer Implements Validable._min_lenght
    Public Property _max_lenght As Integer Implements Validable._max_lenght
    Public Property _numeric As Boolean Implements Validable._numeric

    Public Sub New(id As String, name As String,
                   Optional visible As Boolean = True,
                   Optional maskType As LabeledTextBox.MaskType = LabeledTextBox.MaskType.texto,
                   Optional boxType As BoxType = BoxType.maskedTextBox,
                   Optional combo_data_source As ComboDataSource = Nothing,
                   Optional required As Boolean = False,
                   Optional min_lenght As Integer = 0,
                   Optional maxLenght As Integer = 0,
                   Optional numeric As Boolean = False)
        _id = id
        _name = name
        _visible = visible
        _maskType = maskType
        _boxType = boxType
        _combo_data_source = combo_data_source
        _required = required
        _min_lenght = min_lenght
        _max_lenght = maxLenght
        _numeric = numeric
    End Sub

    Public Function is_valid() As Boolean Implements Validable.is_valid
        Throw New NotImplementedException()
    End Function
End Class
