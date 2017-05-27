<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EquiposControl
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
        Me._txt_modelo = New PAV1_Proyecto.LabeledMaskedTextBox()
        Me.txt_Marca = New System.Windows.Forms.Label()
        Me.cmb_idMarca = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        '_txt_modelo
        '
        Me._txt_modelo._label = "Modelo"
        Me._txt_modelo._mask = PAV1_Proyecto.Campo.MaskType.texto
        Me._txt_modelo._max_length = 0
        Me._txt_modelo._min_lenght = 0
        Me._txt_modelo._numeric = False
        Me._txt_modelo._required = False
        Me._txt_modelo._value = ""
        Me._txt_modelo.Location = New System.Drawing.Point(-7, 0)
        Me._txt_modelo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me._txt_modelo.Name = "_txt_modelo"
        Me._txt_modelo.Size = New System.Drawing.Size(226, 23)
        Me._txt_modelo.TabIndex = 0
        '
        'txt_Marca
        '
        Me.txt_Marca.AutoSize = True
        Me.txt_Marca.Location = New System.Drawing.Point(42, 33)
        Me.txt_Marca.Name = "txt_Marca"
        Me.txt_Marca.Size = New System.Drawing.Size(37, 13)
        Me.txt_Marca.TabIndex = 13
        Me.txt_Marca.Text = "Marca"
        '
        'cmb_idMarca
        '
        Me.cmb_idMarca.FormattingEnabled = True
        Me.cmb_idMarca.Location = New System.Drawing.Point(85, 30)
        Me.cmb_idMarca.Name = "cmb_idMarca"
        Me.cmb_idMarca.Size = New System.Drawing.Size(133, 21)
        Me.cmb_idMarca.TabIndex = 12
        '
        'EquiposControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt_Marca)
        Me.Controls.Add(Me.cmb_idMarca)
        Me.Controls.Add(Me._txt_modelo)
        Me.Name = "EquiposControl"
        Me.Size = New System.Drawing.Size(222, 56)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents _txt_modelo As LabeledMaskedTextBox
    Friend WithEvents txt_Marca As Label
    Friend WithEvents cmb_idMarca As ComboBox
End Class
