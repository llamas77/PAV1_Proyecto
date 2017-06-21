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
        Me.cmbCombo = New System.Windows.Forms.ComboBox()
        Me.lblCombo = New System.Windows.Forms.Label()
        CType(Me.bindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'reportViewer
        '
        Me.reportViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reportViewer.Location = New System.Drawing.Point(12, 68)
        Me.reportViewer.Name = "reportViewer"
        Me.reportViewer.ServerReport.BearerToken = Nothing
        Me.reportViewer.Size = New System.Drawing.Size(615, 310)
        Me.reportViewer.TabIndex = 0
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
        'frm_reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 390)
        Me.Controls.Add(Me.lblCombo)
        Me.Controls.Add(Me.cmbCombo)
        Me.Controls.Add(Me.reportViewer)
        Me.Name = "frm_reporte"
        Me.Text = "Reporte"
        CType(Me.bindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents bindingSource As BindingSource
    Friend WithEvents reportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cmbCombo As ComboBox
    Friend WithEvents lblCombo As Label
End Class
