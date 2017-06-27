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
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.fecha_inf = New System.Windows.Forms.MaskedTextBox()
        Me.fecha_sup = New System.Windows.Forms.MaskedTextBox()
        Me.lblFechaSup = New System.Windows.Forms.Label()
        Me.lblFechaInf = New System.Windows.Forms.Label()
        Me.txt_gan_inf = New System.Windows.Forms.TextBox()
        Me.txt_gan_sup = New System.Windows.Forms.TextBox()
        Me.lblGanSup = New System.Windows.Forms.Label()
        Me.lblGanInf = New System.Windows.Forms.Label()
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
        'cmbCombo
        '
        Me.cmbCombo.FormattingEnabled = True
        Me.cmbCombo.Location = New System.Drawing.Point(107, 24)
        Me.cmbCombo.Name = "cmbCombo"
        Me.cmbCombo.Size = New System.Drawing.Size(125, 21)
        Me.cmbCombo.TabIndex = 1
        Me.cmbCombo.Visible = False
        '
        'lblCombo
        '
        Me.lblCombo.Location = New System.Drawing.Point(9, 23)
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
        'fecha_inf
        '
        Me.fecha_inf.Location = New System.Drawing.Point(307, 27)
        Me.fecha_inf.Mask = "00/00/0000"
        Me.fecha_inf.Name = "fecha_inf"
        Me.fecha_inf.Size = New System.Drawing.Size(116, 20)
        Me.fecha_inf.TabIndex = 6
        Me.fecha_inf.ValidatingType = GetType(Date)
        Me.fecha_inf.Visible = False
        '
        'fecha_sup
        '
        Me.fecha_sup.Location = New System.Drawing.Point(511, 27)
        Me.fecha_sup.Mask = "00/00/0000"
        Me.fecha_sup.Name = "fecha_sup"
        Me.fecha_sup.Size = New System.Drawing.Size(116, 20)
        Me.fecha_sup.TabIndex = 7
        Me.fecha_sup.ValidatingType = GetType(Date)
        Me.fecha_sup.Visible = False
        '
        'lblFechaSup
        '
        Me.lblFechaSup.AutoSize = True
        Me.lblFechaSup.Location = New System.Drawing.Point(429, 31)
        Me.lblFechaSup.Name = "lblFechaSup"
        Me.lblFechaSup.Size = New System.Drawing.Size(79, 13)
        Me.lblFechaSup.TabIndex = 8
        Me.lblFechaSup.Text = "Fecha Superior"
        Me.lblFechaSup.Visible = False
        '
        'lblFechaInf
        '
        Me.lblFechaInf.AutoSize = True
        Me.lblFechaInf.Location = New System.Drawing.Point(238, 30)
        Me.lblFechaInf.Name = "lblFechaInf"
        Me.lblFechaInf.Size = New System.Drawing.Size(72, 13)
        Me.lblFechaInf.TabIndex = 9
        Me.lblFechaInf.Text = "Fecha Inferior"
        Me.lblFechaInf.Visible = False
        '
        'txt_gan_inf
        '
        Me.txt_gan_inf.Location = New System.Drawing.Point(124, 59)
        Me.txt_gan_inf.Name = "txt_gan_inf"
        Me.txt_gan_inf.Size = New System.Drawing.Size(98, 20)
        Me.txt_gan_inf.TabIndex = 10
        Me.txt_gan_inf.Visible = False
        '
        'txt_gan_sup
        '
        Me.txt_gan_sup.Location = New System.Drawing.Point(334, 61)
        Me.txt_gan_sup.Name = "txt_gan_sup"
        Me.txt_gan_sup.Size = New System.Drawing.Size(98, 20)
        Me.txt_gan_sup.TabIndex = 11
        Me.txt_gan_sup.Visible = False
        '
        'lblGanSup
        '
        Me.lblGanSup.AutoSize = True
        Me.lblGanSup.Location = New System.Drawing.Point(228, 64)
        Me.lblGanSup.Name = "lblGanSup"
        Me.lblGanSup.Size = New System.Drawing.Size(100, 13)
        Me.lblGanSup.TabIndex = 12
        Me.lblGanSup.Text = "Porcentaje Superior"
        Me.lblGanSup.Visible = False
        '
        'lblGanInf
        '
        Me.lblGanInf.AutoSize = True
        Me.lblGanInf.Location = New System.Drawing.Point(25, 64)
        Me.lblGanInf.Name = "lblGanInf"
        Me.lblGanInf.Size = New System.Drawing.Size(93, 13)
        Me.lblGanInf.TabIndex = 13
        Me.lblGanInf.Text = "Porcentaje Inferior"
        Me.lblGanInf.Visible = False
        '
        'frm_reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(639, 390)
        Me.Controls.Add(Me.lblGanInf)
        Me.Controls.Add(Me.lblGanSup)
        Me.Controls.Add(Me.txt_gan_sup)
        Me.Controls.Add(Me.txt_gan_inf)
        Me.Controls.Add(Me.lblFechaInf)
        Me.Controls.Add(Me.lblFechaSup)
        Me.Controls.Add(Me.fecha_sup)
        Me.Controls.Add(Me.fecha_inf)
        Me.Controls.Add(Me.btn_buscar)
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
    Friend WithEvents cmbCombo As ComboBox
    Friend WithEvents lblCombo As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents fecha_inf As MaskedTextBox
    Friend WithEvents fecha_sup As MaskedTextBox
    Friend WithEvents lblFechaSup As Label
    Friend WithEvents lblFechaInf As Label
    Friend WithEvents txt_gan_inf As TextBox
    Friend WithEvents txt_gan_sup As TextBox
    Friend WithEvents lblGanSup As Label
    Friend WithEvents lblGanInf As Label
End Class
