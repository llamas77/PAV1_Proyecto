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
            If cmb_combo.SelectedIndex = 0 Then
                Return Nothing
            Else
                Return cmb_combo.SelectedValue
            End If
        End Get
        Set(value As Object)
            cmb_combo.SelectedValue = value
        End Set
    End Property

    Public WriteOnly Property _source As ObjetoDAO
        Set(value As ObjetoDAO)
            Dim objetos As List(Of ObjetoVO) = value.all()

            Dim tabla As DataTable = cmb_combo.DataSource
            tabla.Rows.Clear()

            ' Agregar fila en blanco.
            Dim row As DataRow
            row = tabla.Rows.Add()
            row("value") = Nothing
            row("display") = ""

            For Each valor As ObjetoVO In objetos
                row = tabla.Rows.Add()
                row("value") = valor
                row("display") = valor.toString()
            Next

            ' Los cambios en la tabla se aplican automaticamente al ComboBox.
            cmb_combo.SelectedIndex = -1
            resize_box() ' Actualizar el ancho del control.
        End Set
    End Property



    Public Sub New(id As String, label As String, Optional datos As ObjetoDAO = Nothing)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        init_cmb_combo()
        _id = id
        _label = label
        _source = datos
    End Sub

    Private Sub init_cmb_combo()
        Dim tabla As New DataTable
        tabla.Columns.Add(New DataColumn With {
                            .ColumnName = "value",
                            .DataType = (New Object).GetType
                            })
        tabla.Columns.Add("display")
        cmb_combo.DataSource = tabla
        cmb_combo.ValueMember = "value"
        cmb_combo.DisplayMember = "display"
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
        If _required And (cmb_combo.SelectedIndex = -1 Or cmb_combo.SelectedIndex = 0) Then
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

    Private Sub resize_box()
        If cmb_combo.PreferredSize.Width <> cmb_combo.Width Then
            cmb_combo.Size = New Size(cmb_combo.Size.Height, cmb_combo.PreferredSize.Width)
        End If

        ' cmb_combo.DropDownWidth = 165 ' -- Se puede cambiar el ancho de la lista desplegable.
    End Sub
End Class
