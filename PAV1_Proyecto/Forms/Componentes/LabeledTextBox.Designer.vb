﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabeledTextBox
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
        Me.lbl_texto = New System.Windows.Forms.Label()
        Me.txt_caja = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lbl_texto
        '
        Me.lbl_texto.Dock = System.Windows.Forms.DockStyle.Left
        Me.lbl_texto.Location = New System.Drawing.Point(0, 0)
        Me.lbl_texto.Name = "lbl_texto"
        Me.lbl_texto.Size = New System.Drawing.Size(83, 23)
        Me.lbl_texto.TabIndex = 0
        Me.lbl_texto.Text = "DefaultText"
        Me.lbl_texto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txt_caja
        '
        Me.txt_caja.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txt_caja.Location = New System.Drawing.Point(89, 0)
        Me.txt_caja.Name = "txt_caja"
        Me.txt_caja.Size = New System.Drawing.Size(176, 22)
        Me.txt_caja.TabIndex = 1
        '
        'LabeledTextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt_caja)
        Me.Controls.Add(Me.lbl_texto)
        Me.Name = "LabeledTextBox"
        Me.Size = New System.Drawing.Size(265, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_texto As Label
    Friend WithEvents txt_caja As TextBox
End Class