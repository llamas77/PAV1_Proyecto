Imports PAV1_Proyecto

Public Class LabeledComboBox
    Inherits UserControl
    Implements ObjetoCampo, Validable

    '
    '   -- Interfaz ObjetoCampo
    '
    Public Property _id As String Implements ObjetoCampo._id
    Public Property _label As String Implements ObjetoCampo._label
        Get
            Return lbl_label.Text
        End Get
        Set(value As String)
            lbl_label.Text = value
        End Set
    End Property

    Public Property _value As Object Implements ObjetoCampo._value
        Get
            Return cmb_combo.SelectedValue
        End Get
        Set(value As Object)
            cmb_combo.SelectedValue = value
        End Set
    End Property

    Public WriteOnly Property _source As ComboDataSource
        Set(value As ComboDataSource)
            cmb_combo.DataSource = value.comboSource()
            cmb_combo.SelectedIndex = -1
        End Set
    End Property

    Public Sub New(id As String, label As String, Optional datos As ComboDataSource = Nothing)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _id = id
        _label = label
        _source = datos
    End Sub

    '
    ' -- Interfaz Validable
    '
    Public Property _required As Boolean Implements Validable._required
    Public Property _min_lenght As Integer Implements Validable._min_lenght
    Public Property _max_lenght As Integer Implements Validable._max_lenght
    Public Property _numeric As Boolean Implements Validable._numeric


    Public Function is_valid() As Boolean Implements Validable.is_valid
        Dim valido As Boolean = True
        If Not _required And cmb_combo.SelectedIndex = -1 Then
            valido = False
        End If
        If _numeric And Not IsNumeric(cmb_combo.SelectedValue) Then
            valido = False
        End If

        If Not valido Then
            lbl_label.ForeColor = System.Drawing.Color.Red
        End If

        Return valido
    End Function

    Public Overrides Sub ResetText()
        MyBase.ResetText()
        cmb_combo.SelectedIndex = -1
        lbl_label.ForeColor = System.Drawing.SystemColors.ControlText
    End Sub

    Private Sub cmb_combo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_combo.SelectedIndexChanged
        lbl_label.ForeColor = System.Drawing.SystemColors.ControlText
    End Sub
End Class
