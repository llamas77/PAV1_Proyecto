<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_reporte
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.bindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.reportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.bindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'reportViewer
        '
        Me.reportViewer.Location = New System.Drawing.Point(12, 12)
        Me.reportViewer.Name = "reportViewer"
        Me.reportViewer.ServerReport.BearerToken = Nothing
        Me.reportViewer.Size = New System.Drawing.Size(615, 366)
        Me.reportViewer.TabIndex = 0
        '
        'frm_reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 390)
        Me.Controls.Add(Me.reportViewer)
        Me.Name = "frm_reporte"
        Me.Text = "Reporte"
        CType(Me.bindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents bindingSource As BindingSource
    Friend WithEvents reportViewer As Microsoft.Reporting.WinForms.ReportViewer
End Class
