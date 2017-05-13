Public Class LabeledComboBox
    Inherits UserControl

    ' TODO: Implementar.
    Public Sub New(label As String)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _label = label
    End Sub


    Public ReadOnly Property _combo As ComboBox
        Get
            Return Me.cmb_combo
        End Get
    End Property

    Public Property _label As String
        Get
            Return lbl_label.Text
        End Get
        Set(value As String)
            lbl_label.Text = value
        End Set
    End Property
End Class
