<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProveedorControl
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
        Me.txt_razonSocial = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_cuit = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_domicilio = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_telefono = New PAV1_Proyecto.LabeledTextBox()
        Me.txt_email = New PAV1_Proyecto.LabeledTextBox()
        Me.SuspendLayout()
        '
        'txt_razonSocial
        '
        Me.txt_razonSocial._label = "Razón Social"
        Me.txt_razonSocial._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.texto
        Me.txt_razonSocial._max_length = 0
        Me.txt_razonSocial._min_lenght = 0
        Me.txt_razonSocial._numeric = False
        Me.txt_razonSocial._required = False
        Me.txt_razonSocial._text = ""
        Me.txt_razonSocial.Location = New System.Drawing.Point(12, 11)
        Me.txt_razonSocial.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_razonSocial.Name = "txt_razonSocial"
        Me.txt_razonSocial.Size = New System.Drawing.Size(199, 19)
        Me.txt_razonSocial.TabIndex = 0
        '
        'txt_cuit
        '
        Me.txt_cuit._label = "CUIT"
        Me.txt_cuit._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.cuit
        Me.txt_cuit._max_length = 13
        Me.txt_cuit._min_lenght = 0
        Me.txt_cuit._numeric = False
        Me.txt_cuit._required = False
        Me.txt_cuit._text = "-        -"
        Me.txt_cuit.Location = New System.Drawing.Point(12, 44)
        Me.txt_cuit.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_cuit.Name = "txt_cuit"
        Me.txt_cuit.Size = New System.Drawing.Size(199, 19)
        Me.txt_cuit.TabIndex = 1
        '
        'txt_domicilio
        '
        Me.txt_domicilio._label = "Domicilio "
        Me.txt_domicilio._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.texto
        Me.txt_domicilio._max_length = 0
        Me.txt_domicilio._min_lenght = 0
        Me.txt_domicilio._numeric = False
        Me.txt_domicilio._required = False
        Me.txt_domicilio._text = ""
        Me.txt_domicilio.Location = New System.Drawing.Point(12, 77)
        Me.txt_domicilio.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_domicilio.Name = "txt_domicilio"
        Me.txt_domicilio.Size = New System.Drawing.Size(199, 19)
        Me.txt_domicilio.TabIndex = 2
        '
        'txt_telefono
        '
        Me.txt_telefono._label = "Teléfono"
        Me.txt_telefono._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.telefono
        Me.txt_telefono._max_length = 12
        Me.txt_telefono._min_lenght = 0
        Me.txt_telefono._numeric = False
        Me.txt_telefono._required = False
        Me.txt_telefono._text = "4   -4"
        Me.txt_telefono.Location = New System.Drawing.Point(12, 109)
        Me.txt_telefono.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_telefono.Name = "txt_telefono"
        Me.txt_telefono.Size = New System.Drawing.Size(199, 19)
        Me.txt_telefono.TabIndex = 3
        '
        'txt_email
        '
        Me.txt_email._label = "Email"
        Me.txt_email._Mask = PAV1_Proyecto.LabeledTextBox.MaskType.email
        Me.txt_email._max_length = 0
        Me.txt_email._min_lenght = 0
        Me.txt_email._numeric = False
        Me.txt_email._required = False
        Me.txt_email._text = ""
        Me.txt_email.Location = New System.Drawing.Point(12, 142)
        Me.txt_email.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.txt_email.Name = "txt_email"
        Me.txt_email.Size = New System.Drawing.Size(199, 19)
        Me.txt_email.TabIndex = 4
        '
        'ProveedorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txt_email)
        Me.Controls.Add(Me.txt_telefono)
        Me.Controls.Add(Me.txt_domicilio)
        Me.Controls.Add(Me.txt_cuit)
        Me.Controls.Add(Me.txt_razonSocial)
        Me.Name = "ProveedorControl"
        Me.Size = New System.Drawing.Size(234, 177)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txt_razonSocial As LabeledTextBox
    Friend WithEvents txt_cuit As LabeledTextBox
    Friend WithEvents txt_domicilio As LabeledTextBox
    Friend WithEvents txt_telefono As LabeledTextBox
    Friend WithEvents txt_email As LabeledTextBox
End Class
