<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_menu
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
        Me.btn_marcas = New System.Windows.Forms.Button()
        Me.btn_familias = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_marcas
        '
        Me.btn_marcas.Location = New System.Drawing.Point(26, 20)
        Me.btn_marcas.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btn_marcas.Name = "btn_marcas"
        Me.btn_marcas.Size = New System.Drawing.Size(96, 67)
        Me.btn_marcas.TabIndex = 0
        Me.btn_marcas.Text = "ABM Marcas"
        Me.btn_marcas.UseVisualStyleBackColor = True
        '
        'btn_familias
        '
        Me.btn_familias.Location = New System.Drawing.Point(127, 20)
        Me.btn_familias.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.btn_familias.Name = "btn_familias"
        Me.btn_familias.Size = New System.Drawing.Size(101, 67)
        Me.btn_familias.TabIndex = 0
        Me.btn_familias.Text = "ABM Familias"
        Me.btn_familias.UseVisualStyleBackColor = True
        '
        'frm_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 116)
        Me.Controls.Add(Me.btn_familias)
        Me.Controls.Add(Me.btn_marcas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm_menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_marcas As Button
    Friend WithEvents btn_familias As Button
End Class
