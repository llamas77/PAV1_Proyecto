<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TipoClienteControl
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
        Me.txt_descripcion = New PAV1_Proyecto.LabeledMaskedTextBox()
        Me.txt_nombre = New PAV1_Proyecto.LabeledMaskedTextBox()
        Me.SuspendLayout()
        '
        'txt_descripcion
        '
        Me.txt_descripcion._label = "Descripción"
        Me.txt_descripcion.Location = New System.Drawing.Point(3, 32)
        Me.txt_descripcion.Name = "txt_descripcion"
        Me.txt_descripcion.Size = New System.Drawing.Size(283, 23)
        Me.txt_descripcion.TabIndex = 1
        '
        'txt_nombre
        '
        Me.txt_nombre._label = "Nombre"
        Me.txt_nombre.Location = New System.Drawing.Point(3, 3)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(283, 23)
        Me.txt_nombre.TabIndex = 0
        '
        'TipoClienteControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt_nombre)
        Me.Controls.Add(Me.txt_descripcion)
        Me.Name = "TipoClienteControl"
        Me.Size = New System.Drawing.Size(295, 61)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txt_descripcion As LabeledMaskedTextBox
    Friend WithEvents txt_nombre As LabeledMaskedTextBox
End Class
