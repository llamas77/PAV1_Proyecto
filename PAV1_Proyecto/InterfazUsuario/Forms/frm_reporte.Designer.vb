<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_reporte
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.bindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.reportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.txt_fecha_sup = New PAV1_Proyecto.LabeledMaskedTextBox()
        Me.txt_fecha_inf = New PAV1_Proyecto.LabeledMaskedTextBox()
        Me.cmbCombo = New System.Windows.Forms.ComboBox()
        Me.lblCombo = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        CType(Me.bindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'reportViewer
        '
        Me.reportViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reportViewer.Location = New System.Drawing.Point(12, 88)
        Me.reportViewer.Name = "reportViewer"
        Me.reportViewer.ServerReport.BearerToken = Nothing
        Me.reportViewer.Size = New System.Drawing.Size(615, 290)
        Me.reportViewer.TabIndex = 0
        '
        'txt_fecha_sup
        '
        Me.txt_fecha_sup._id = Nothing
        Me.txt_fecha_sup._label = "FechaSup"
        Me.txt_fecha_sup._mask = PAV1_Proyecto.Campo.MaskType.fecha
        Me.txt_fecha_sup._max_length = 0
        Me.txt_fecha_sup._min_lenght = 0
        Me.txt_fecha_sup._numeric = False
        Me.txt_fecha_sup._required = False
        Me.txt_fecha_sup._value = "/  /"
        Me.txt_fecha_sup.AutoSize = True
        Me.txt_fecha_sup.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.txt_fecha_sup.Location = New System.Drawing.Point(411, 27)
        Me.txt_fecha_sup.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_fecha_sup.MaximumSize = New System.Drawing.Size(0, 23)
        Me.txt_fecha_sup.Name = "txt_fecha_sup"
        Me.txt_fecha_sup.Size = New System.Drawing.Size(216, 23)
        Me.txt_fecha_sup.TabIndex = 3
        Me.txt_fecha_sup.Visible = False
        '
        'txt_fecha_inf
        '
        Me.txt_fecha_inf._id = Nothing
        Me.txt_fecha_inf._label = "FechaInf"
        Me.txt_fecha_inf._mask = PAV1_Proyecto.Campo.MaskType.fecha
        Me.txt_fecha_inf._max_length = 0
        Me.txt_fecha_inf._min_lenght = 0
        Me.txt_fecha_inf._numeric = False
        Me.txt_fecha_inf._required = False
        Me.txt_fecha_inf._value = "/  /"
        Me.txt_fecha_inf.AutoSize = True
        Me.txt_fecha_inf.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.txt_fecha_inf.Location = New System.Drawing.Point(231, 25)
        Me.txt_fecha_inf.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_fecha_inf.MaximumSize = New System.Drawing.Size(0, 23)
        Me.txt_fecha_inf.Name = "txt_fecha_inf"
        Me.txt_fecha_inf.Size = New System.Drawing.Size(216, 23)
        Me.txt_fecha_inf.TabIndex = 4
        Me.txt_fecha_inf.Visible = False
        '
        'cmbCombo
        '
        Me.cmbCombo.FormattingEnabled = True
        Me.cmbCombo.Location = New System.Drawing.Point(117, 27)
        Me.cmbCombo.Name = "cmbCombo"
        Me.cmbCombo.Size = New System.Drawing.Size(125, 21)
        Me.cmbCombo.TabIndex = 1
        Me.cmbCombo.Visible = False
        '
        'lblCombo
        '
        Me.lblCombo.Location = New System.Drawing.Point(12, 27)
        Me.lblCombo.Name = "lblCombo"
        Me.lblCombo.Size = New System.Drawing.Size(99, 21)
        Me.lblCombo.TabIndex = 2
        Me.lblCombo.Text = "lblCombo"
        Me.lblCombo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCombo.Visible = False
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(552, 59)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(75, 23)
        Me.btn_buscar.TabIndex = 5
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'frm_reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 390)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.txt_fecha_inf)
        Me.Controls.Add(Me.txt_fecha_sup)
        Me.Controls.Add(Me.lblCombo)
        Me.Controls.Add(Me.cmbCombo)
        Me.Controls.Add(Me.reportViewer)
        Me.Name = "frm_reporte"
        Me.Text = "Reporte"
        CType(Me.bindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents bindingSource As BindingSource
    Friend WithEvents reportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents txt_fecha_sup As LabeledMaskedTextBox
    Friend WithEvents txt_fecha_inf As LabeledMaskedTextBox
    Friend WithEvents cmbCombo As ComboBox
    Friend WithEvents lblCombo As Label
    Friend WithEvents btn_buscar As Button
End Class
