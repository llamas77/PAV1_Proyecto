﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabeledComboBox
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
        Me.lbl_label = New System.Windows.Forms.Label()
        Me.cmb_combo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lbl_label
        '
        Me.lbl_label.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbl_label.Location = New System.Drawing.Point(0, 0)
        Me.lbl_label.Name = "lbl_label"
        Me.lbl_label.Size = New System.Drawing.Size(83, 28)
        Me.lbl_label.TabIndex = 0
        Me.lbl_label.Text = "DefaultText"
        Me.lbl_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmb_combo
        '
        Me.cmb_combo.FormattingEnabled = True
        Me.cmb_combo.Location = New System.Drawing.Point(88, 3)
        Me.cmb_combo.MaximumSize = New System.Drawing.Size(165, 0)
        Me.cmb_combo.MinimumSize = New System.Drawing.Size(4, 0)
        Me.cmb_combo.Name = "cmb_combo"
        Me.cmb_combo.Size = New System.Drawing.Size(165, 24)
        Me.cmb_combo.TabIndex = 0
        '
        'LabeledComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmb_combo)
        Me.Controls.Add(Me.lbl_label)
        Me.Name = "LabeledComboBox"
        Me.Size = New System.Drawing.Size(255, 28)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbl_label As Label
    Friend WithEvents cmb_combo As ComboBox
End Class
