<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class repEstMovXFlia
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
        Me.txt_lim_sup = New System.Windows.Forms.TextBox()
        Me.txt_lim_inf = New System.Windows.Forms.TextBox()
        Me.lblLimiteSup = New System.Windows.Forms.Label()
        Me.lblLimiteInf = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txt_lim_sup
        '
        Me.txt_lim_sup.Location = New System.Drawing.Point(318, 24)
        Me.txt_lim_sup.Name = "txt_lim_sup"
        Me.txt_lim_sup.Size = New System.Drawing.Size(98, 20)
        Me.txt_lim_sup.TabIndex = 13
        '
        'txt_lim_inf
        '
        Me.txt_lim_inf.Location = New System.Drawing.Point(115, 24)
        Me.txt_lim_inf.Name = "txt_lim_inf"
        Me.txt_lim_inf.Size = New System.Drawing.Size(98, 20)
        Me.txt_lim_inf.TabIndex = 12
        '
        'lblLimiteSup
        '
        Me.lblLimiteSup.AutoSize = True
        Me.lblLimiteSup.Location = New System.Drawing.Point(243, 27)
        Me.lblLimiteSup.Name = "lblLimiteSup"
        Me.lblLimiteSup.Size = New System.Drawing.Size(76, 13)
        Me.lblLimiteSup.TabIndex = 14
        Me.lblLimiteSup.Text = "Limite Superior"
        '
        'lblLimiteInf
        '
        Me.lblLimiteInf.AutoSize = True
        Me.lblLimiteInf.Location = New System.Drawing.Point(40, 27)
        Me.lblLimiteInf.Name = "lblLimiteInf"
        Me.lblLimiteInf.Size = New System.Drawing.Size(69, 13)
        Me.lblLimiteInf.TabIndex = 15
        Me.lblLimiteInf.Text = "Limite Inferior"
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(480, 21)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(75, 23)
        Me.btn_buscar.TabIndex = 16
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 50)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(572, 288)
        Me.ReportViewer1.TabIndex = 17
        '
        'repEstMovXFlia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(596, 350)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.lblLimiteInf)
        Me.Controls.Add(Me.lblLimiteSup)
        Me.Controls.Add(Me.txt_lim_sup)
        Me.Controls.Add(Me.txt_lim_inf)
        Me.Name = "repEstMovXFlia"
        Me.Text = "repEstMovXFlia"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txt_lim_sup As TextBox
    Friend WithEvents txt_lim_inf As TextBox
    Friend WithEvents lblLimiteSup As Label
    Friend WithEvents lblLimiteInf As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
