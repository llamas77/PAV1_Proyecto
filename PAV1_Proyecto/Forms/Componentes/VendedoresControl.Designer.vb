<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VendedoresControl
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
        Me.txt_direccion = New PAV1_Proyecto.LabeledMaskedTextBox()
        Me.txt_telefono = New PAV1_Proyecto.LabeledMaskedTextBox()
        Me.txt_apellido = New PAV1_Proyecto.LabeledMaskedTextBox()
        Me.txt_nombre = New PAV1_Proyecto.LabeledMaskedTextBox()
        Me.txt_comision = New PAV1_Proyecto.LabeledMaskedTextBox()
        Me.SuspendLayout()
        '
        'txt_direccion
        '
        Me.txt_direccion._label = "Dirección"
        Me.txt_direccion._mask = PAV1_Proyecto.Campo.MaskType.texto
        Me.txt_direccion._required = False
        Me.txt_direccion.Location = New System.Drawing.Point(2, 73)
        Me.txt_direccion.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(199, 19)
        Me.txt_direccion.TabIndex = 3
        '
        'txt_telefono
        '
        Me.txt_telefono._label = "Teléfono"
        Me.txt_telefono._mask = PAV1_Proyecto.Campo.MaskType.telefono
        Me.txt_telefono._required = False
        Me.txt_telefono.Location = New System.Drawing.Point(2, 50)
        Me.txt_telefono.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(140, 19)
        Me.txt_telefono.TabIndex = 2
        '
        'txt_apellido
        '
        Me.txt_apellido._label = "Apellido"
        Me.txt_apellido._mask = PAV1_Proyecto.Campo.MaskType.texto
        Me.txt_apellido._required = False
        Me.txt_apellido.Location = New System.Drawing.Point(2, 26)
        Me.txt_apellido.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_apellido.Name = "txt_apellido"
        Me.txt_apellido.Size = New System.Drawing.Size(199, 19)
        Me.txt_apellido.TabIndex = 1
        '
        'txt_nombre
        '
        Me.txt_nombre._label = "Nombre"
        Me.txt_nombre._mask = PAV1_Proyecto.Campo.MaskType.texto
        Me.txt_nombre._required = False
        Me.txt_nombre.Location = New System.Drawing.Point(2, 2)
        Me.txt_nombre.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(199, 19)
        Me.txt_nombre.TabIndex = 0
        '
        'txt_comision
        '
        Me.txt_comision._label = "Comision"
        Me.txt_comision._mask = PAV1_Proyecto.Campo.MaskType.porcentaje
        Me.txt_comision._required = False
        Me.txt_comision.Location = New System.Drawing.Point(2, 97)
        Me.txt_comision.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_comision.Name = "txt_comision"
        Me.txt_comision.Size = New System.Drawing.Size(112, 19)
        Me.txt_comision.TabIndex = 4
        '
        'VendedoresControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt_comision)
        Me.Controls.Add(Me.txt_direccion)
        Me.Controls.Add(Me.txt_telefono)
        Me.Controls.Add(Me.txt_apellido)
        Me.Controls.Add(Me.txt_nombre)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "VendedoresControl"
        Me.Size = New System.Drawing.Size(206, 121)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txt_direccion As LabeledMaskedTextBox
    Friend WithEvents txt_telefono As LabeledMaskedTextBox
    Friend WithEvents txt_apellido As LabeledMaskedTextBox
    Friend WithEvents txt_nombre As LabeledMaskedTextBox
    Friend WithEvents txt_comision As LabeledMaskedTextBox
End Class
