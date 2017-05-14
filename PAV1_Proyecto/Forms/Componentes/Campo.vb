Public Class Campo
    Private maskType As LabeledTextBox.MaskType

    Enum BoxType
        maskedTextBox
        comboBox
    End Enum

    Public Property _id As String
    Public Property _name As String
    Public Property _visible As Boolean
    Public Property _maskType As LabeledTextBox.MaskType
    Public Property _boxType As BoxType
    Public Property _maxLenght As Integer

    Public Sub New(id As String, name As String,
                   Optional visible As Boolean = True,
                   Optional maxLenght As Integer = 0,
                   Optional maskType As LabeledTextBox.MaskType = LabeledTextBox.MaskType.texto,
                   Optional boxType As BoxType = BoxType.maskedTextBox)
        _id = id
        _name = name
        _visible = visible
        _maxLenght = maxLenght
        _maskType = maskType
        _boxType = boxType
    End Sub

End Class
