Imports PAV1_Proyecto

Public Class LabeledComboBox
    Inherits UserControl
    Implements Validable

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

    Public Property _null As Boolean Implements Validable._null
    Public Property _min_lenght As Integer Implements Validable._min_lenght
    Public Property _max_lenght As Integer Implements Validable._max_lenght
    Public Property _numeric As Boolean Implements Validable._numeric

    Public Function is_valid() As Boolean Implements Validable.is_valid
        Dim valido As Boolean = True
        If Not _null And cmb_combo.SelectedIndex = -1 Then
            valido = False
        End If
        If _numeric And Not IsNumeric(cmb_combo.SelectedValue) Then
            valido = False
        End If

        If Not valido Then
            _combo.BackColor = System.Drawing.Color.Gold
        End If

        Return valido
    End Function

    Private Sub cmb_combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_combo.SelectedIndexChanged
        _combo.BackColor = System.Drawing.SystemColors.Window
    End Sub
End Class
