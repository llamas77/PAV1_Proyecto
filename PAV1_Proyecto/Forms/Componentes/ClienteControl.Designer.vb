<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClienteControl
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
        Me.txt_direccion = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_telefono = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_apellido = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_nombre = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_TipoCliente = New System.Windows.Forms.Label()
        Me.cmb_idTipoCliente = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txt_direccion
        '
        Me.txt_direccion._label = "Dirección"
        Me.txt_direccion._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.texto
        Me.txt_direccion._max_length = 0
        Me.txt_direccion._min_lenght = 0
        Me.txt_direccion._null = False
        Me.txt_direccion._numeric = False
        Me.txt_direccion._text = ""
        Me.txt_direccion.Location = New System.Drawing.Point(3, 90)
        Me.txt_direccion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_direccion.Name = "txt_direccion"
        Me.txt_direccion.Size = New System.Drawing.Size(265, 23)
        Me.txt_direccion.TabIndex = 7
        '
        'txt_telefono
        '
        Me.txt_telefono._label = "Teléfono"
        Me.txt_telefono._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.telefono
        Me.txt_telefono._max_length = 13
        Me.txt_telefono._min_lenght = 0
        Me.txt_telefono._null = False
        Me.txt_telefono._numeric = False
        Me.txt_telefono._text = "-4"
        Me.txt_telefono.Location = New System.Drawing.Point(3, 62)
        Me.txt_telefono.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(250, 23)
        Me.txt_telefono.TabIndex = 6
        '
        'txt_apellido
        '
        Me.txt_apellido._label = "Apellido"
        Me.txt_apellido._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.texto
        Me.txt_apellido._max_length = 0
        Me.txt_apellido._min_lenght = 0
        Me.txt_apellido._null = False
        Me.txt_apellido._numeric = False
        Me.txt_apellido._text = ""
        Me.txt_apellido.Location = New System.Drawing.Point(3, 32)
        Me.txt_apellido.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_apellido.Name = "txt_apellido"
        Me.txt_apellido.Size = New System.Drawing.Size(265, 23)
        Me.txt_apellido.TabIndex = 5
        '
        'txt_nombre
        '
        Me.txt_nombre._label = "Nombre"
        Me.txt_nombre._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.texto
        Me.txt_nombre._max_length = 0
        Me.txt_nombre._min_lenght = 0
        Me.txt_nombre._null = False
        Me.txt_nombre._numeric = False
        Me.txt_nombre._text = ""
        Me.txt_nombre.Location = New System.Drawing.Point(3, 2)
        Me.txt_nombre.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txt_nombre.Name = "txt_nombre"
        Me.txt_nombre.Size = New System.Drawing.Size(265, 23)
        Me.txt_nombre.TabIndex = 4
        '
        'txt_TipoCliente
        '
        Me.txt_TipoCliente.AutoSize = True
        Me.txt_TipoCliente.Location = New System.Drawing.Point(39, 128)
        Me.txt_TipoCliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txt_TipoCliente.Name = "txt_TipoCliente"
        Me.txt_TipoCliente.Size = New System.Drawing.Size(83, 17)
        Me.txt_TipoCliente.TabIndex = 9
        Me.txt_TipoCliente.Text = "Tipo Cliente"
        '
        'cmb_idTipoCliente
        '
        Me.cmb_idTipoCliente.FormattingEnabled = True
        Me.cmb_idTipoCliente.Location = New System.Drawing.Point(127, 125)
        Me.cmb_idTipoCliente.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmb_idTipoCliente.Name = "cmb_idTipoCliente"
        Me.cmb_idTipoCliente.Size = New System.Drawing.Size(141, 24)
        Me.cmb_idTipoCliente.TabIndex = 8
        '
        'ClienteControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt_TipoCliente)
        Me.Controls.Add(Me.cmb_idTipoCliente)
        Me.Controls.Add(Me.txt_direccion)
        Me.Controls.Add(Me.txt_telefono)
        Me.Controls.Add(Me.txt_apellido)
        Me.Controls.Add(Me.txt_nombre)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ClienteControl"
        Me.Size = New System.Drawing.Size(280, 159)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_direccion As LabeledTextBox
    Friend WithEvents txt_telefono As LabeledTextBox
    Friend WithEvents txt_apellido As LabeledTextBox
    Friend WithEvents txt_nombre As LabeledTextBox
    Friend WithEvents txt_TipoCliente As Label
    Friend WithEvents cmb_idTipoCliente As ComboBox
End Class
