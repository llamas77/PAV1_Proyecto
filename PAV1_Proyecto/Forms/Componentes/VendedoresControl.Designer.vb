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
        Me.txt_comision = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_direccion = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_telefono = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_apellido = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_nombre = New PAV1_Proyecto.LabeledTextBox()
        Me.SuspendLayout()
        '
        'txt_comision
        '
        Me.txt_comision._label_text = "Comision"
        Me.txt_comision._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.porcentaje
        Me.txt_comision._Not_Null = True
        Me.txt_comision.Location = New System.Drawing.Point(3, 119)
        Me.txt_comision.Name = "txt_comision"
        Me.txt_comision.Size = New System.Drawing.Size(149, 23)
        Me.txt_comision.TabIndex = 4
        '
        'txt_direccion
        '
        Me.txt_direccion._label_text = "Dirección"
        Me.txt_direccion._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.texto
        Me.txt_direccion._Not_Null = True
        Me.txt_direccion.Location = New System.Drawing.Point(3, 90)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(265, 23)
        Me.txt_direccion.TabIndex = 3
        '
        'txt_telefono
        '
        Me.txt_telefono._label_text = "Teléfono"
        Me.txt_telefono._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.telefono
        Me.txt_telefono._Not_Null = True
        Me.txt_telefono.Location = New System.Drawing.Point(3, 61)
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(186, 23)
        Me.txt_telefono.TabIndex = 2
        '
        'txt_apellido
        '
        Me.txt_apellido._label_text = "Apellido"
        Me.txt_apellido._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.texto
        Me.txt_apellido._Not_Null = True
        Me.txt_apellido.Location = New System.Drawing.Point(3, 32)
        Me.txt_apellido.Name = "txt_apellido"
        Me.txt_apellido.Size = New System.Drawing.Size(265, 23)
        Me.txt_apellido.TabIndex = 1
        '
        'txt_nombre
        '
        Me.txt_nombre._label_text = "Nombre"
        Me.txt_nombre._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.texto
        Me.txt_nombre._Not_Null = True
        Me.txt_nombre.Location = New System.Drawing.Point(3, 3)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(265, 23)
        Me.txt_nombre.TabIndex = 0
        '
        'VendedoresControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt_comision)
        Me.Controls.Add(Me.txt_direccion)
        Me.Controls.Add(Me.txt_telefono)
        Me.Controls.Add(Me.txt_apellido)
        Me.Controls.Add(Me.txt_nombre)
        Me.Name = "VendedoresControl"
        Me.Size = New System.Drawing.Size(274, 149)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txt_comision As LabeledTextBox
    Friend WithEvents txt_direccion As LabeledTextBox
    Friend WithEvents txt_telefono As LabeledTextBox
    Friend WithEvents txt_apellido As LabeledTextBox
    Friend WithEvents txt_nombre As LabeledTextBox
End Class
