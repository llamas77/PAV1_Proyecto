<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ControlYGrilla
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.btn_agregar = New System.Windows.Forms.Button()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.lbl_label = New System.Windows.Forms.Label()
        Me.panel = New System.Windows.Forms.Panel()
        Me.panel.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_agregar
        '
        Me.btn_agregar.AutoSize = True
        Me.btn_agregar.Location = New System.Drawing.Point(9, 10)
        Me.btn_agregar.Name = "btn_agregar"
        Me.btn_agregar.Size = New System.Drawing.Size(69, 27)
        Me.btn_agregar.TabIndex = 2
        Me.btn_agregar.Text = "Agregar"
        Me.btn_agregar.UseVisualStyleBackColor = True
        '
        'btn_eliminar
        '
        Me.btn_eliminar.AutoSize = True
        Me.btn_eliminar.Location = New System.Drawing.Point(40, 10)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(68, 27)
        Me.btn_eliminar.TabIndex = 4
        Me.btn_eliminar.Text = "Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'lbl_label
        '
        Me.lbl_label.AutoSize = True
        Me.lbl_label.Location = New System.Drawing.Point(15, 7)
        Me.lbl_label.Name = "lbl_label"
        Me.lbl_label.Size = New System.Drawing.Size(84, 17)
        Me.lbl_label.TabIndex = 5
        Me.lbl_label.Text = "Default Text"
        '
        'panel
        '
        Me.panel.AutoSize = True
        Me.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel.Controls.Add(Me.btn_eliminar)
        Me.panel.Controls.Add(Me.btn_agregar)
        Me.panel.Location = New System.Drawing.Point(8, 16)
        Me.panel.Name = "panel"
        Me.panel.Size = New System.Drawing.Size(113, 42)
        Me.panel.TabIndex = 6
        Me.panel.Tag = ""
        '
        'ControlYGrilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Controls.Add(Me.lbl_label)
        Me.Controls.Add(Me.panel)
        Me.Name = "ControlYGrilla"
        Me.Size = New System.Drawing.Size(124, 61)
        Me.panel.ResumeLayout(False)
        Me.panel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_agregar As Button
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents lbl_label As Label
    Friend WithEvents panel As Panel
End Class
