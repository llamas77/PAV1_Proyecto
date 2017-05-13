Public Class Campo
    Private maskType As LabeledTextBox.MaskType

    Enum BoxType
        maskedTextBox
        comboBox
    End Enum

    Public Property _id As String
    Public Property _name As String
    Public Property _visible As Boolean
    Public Property _maskType 'As MaskType ' No permite usar una enumeracion declarada fuera como objeto.
    ' TODO: Hacer setter de _maskType validando que sea del tipo MaskType
    Public Property _boxType As BoxType

    Public Sub New(id As String, name As String, visible As Boolean,
                   Optional maskType As Object = LabeledTextBox.MaskType.texto,
                   Optional boxType As BoxType = BoxType.maskedTextBox)
        _id = id
        _name = name
        _visible = visible
        _maskType = maskType
        _boxType = boxType
    End Sub

End Class
