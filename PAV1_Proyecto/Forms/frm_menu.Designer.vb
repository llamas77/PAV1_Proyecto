<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_menu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btn_marcas = New System.Windows.Forms.Button()
        Me.btn_familias = New System.Windows.Forms.Button()
        Me.btn_tipos_cliente = New System.Windows.Forms.Button()
        Me.btn_vendedores = New System.Windows.Forms.Button()
        Me.btn_grupos = New System.Windows.Forms.Button()
        Me.btn_ganancias = New System.Windows.Forms.Button()
        Me.btn_Clientes = New System.Windows.Forms.Button()
        Me.btn_ganancias2 = New System.Windows.Forms.Button()
        Me.btn_productos = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_marcas
        '
        Me.btn_marcas.Location = New System.Drawing.Point(26, 20)
        Me.btn_marcas.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_marcas.Name = "btn_marcas"
        Me.btn_marcas.Size = New System.Drawing.Size(96, 67)
        Me.btn_marcas.TabIndex = 0
        Me.btn_marcas.Text = "ABM Marcas"
        Me.btn_marcas.UseVisualStyleBackColor = True
        '
        'btn_familias
        '
        Me.btn_familias.Location = New System.Drawing.Point(126, 21)
        Me.btn_familias.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_familias.Name = "btn_familias"
        Me.btn_familias.Size = New System.Drawing.Size(101, 67)
        Me.btn_familias.TabIndex = 0
        Me.btn_familias.Text = "ABM Familias"
        Me.btn_familias.UseVisualStyleBackColor = True
        '
        'btn_tipos_cliente
        '
        Me.btn_tipos_cliente.Location = New System.Drawing.Point(230, 21)
        Me.btn_tipos_cliente.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_tipos_cliente.Name = "btn_tipos_cliente"
        Me.btn_tipos_cliente.Size = New System.Drawing.Size(101, 67)
        Me.btn_tipos_cliente.TabIndex = 0
        Me.btn_tipos_cliente.Text = "Tipos de Clientes"
        Me.btn_tipos_cliente.UseVisualStyleBackColor = True
        '
        'btn_vendedores
        '
        Me.btn_vendedores.Location = New System.Drawing.Point(230, 91)
        Me.btn_vendedores.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_vendedores.Name = "btn_vendedores"
        Me.btn_vendedores.Size = New System.Drawing.Size(101, 67)
        Me.btn_vendedores.TabIndex = 1
        Me.btn_vendedores.Text = "Vendedores"
        Me.btn_vendedores.UseVisualStyleBackColor = True
        '
        'btn_grupos
        '
        Me.btn_grupos.Location = New System.Drawing.Point(26, 91)
        Me.btn_grupos.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_grupos.Name = "btn_grupos"
        Me.btn_grupos.Size = New System.Drawing.Size(96, 67)
        Me.btn_grupos.TabIndex = 0
        Me.btn_grupos.Text = "ABM Grupos"
        Me.btn_grupos.UseVisualStyleBackColor = True
        '
        'btn_ganancias
        '
        Me.btn_ganancias.Location = New System.Drawing.Point(26, 162)
        Me.btn_ganancias.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_ganancias.Name = "btn_ganancias"
        Me.btn_ganancias.Size = New System.Drawing.Size(96, 63)
        Me.btn_ganancias.TabIndex = 2
        Me.btn_ganancias.Text = "Ganancias"
        Me.btn_ganancias.UseVisualStyleBackColor = True
        '
        'btn_Clientes
        '
        Me.btn_Clientes.Location = New System.Drawing.Point(126, 91)
        Me.btn_Clientes.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_Clientes.Name = "btn_Clientes"
        Me.btn_Clientes.Size = New System.Drawing.Size(101, 67)
        Me.btn_Clientes.TabIndex = 2
        Me.btn_Clientes.Text = "Clientes"
        Me.btn_Clientes.UseVisualStyleBackColor = True
        '
        'btn_ganancias2
        '
        Me.btn_ganancias2.Location = New System.Drawing.Point(126, 162)
        Me.btn_ganancias2.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_ganancias2.Name = "btn_ganancias2"
        Me.btn_ganancias2.Size = New System.Drawing.Size(101, 63)
        Me.btn_ganancias2.TabIndex = 2
        Me.btn_ganancias2.Text = "Ganancias Diseño 2"
        Me.btn_ganancias2.UseVisualStyleBackColor = True
        '
        'btn_productos
        '
        Me.btn_productos.Location = New System.Drawing.Point(230, 162)
        Me.btn_productos.Margin = New System.Windows.Forms.Padding(2)
        Me.btn_productos.Name = "btn_productos"
        Me.btn_productos.Size = New System.Drawing.Size(101, 63)
        Me.btn_productos.TabIndex = 2
        Me.btn_productos.Text = "Productos"
        Me.btn_productos.UseVisualStyleBackColor = True
        '
        'frm_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 243)
        Me.Controls.Add(Me.btn_ganancias2)
        Me.Controls.Add(Me.btn_productos)
        Me.Controls.Add(Me.btn_ganancias)
        Me.Controls.Add(Me.btn_Clientes)
        Me.Controls.Add(Me.btn_vendedores)
        Me.Controls.Add(Me.btn_tipos_cliente)
        Me.Controls.Add(Me.btn_familias)
        Me.Controls.Add(Me.btn_grupos)
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
    Friend WithEvents btn_tipos_cliente As Button
    Friend WithEvents btn_vendedores As Button
    Friend WithEvents btn_grupos As Button
    Friend WithEvents btn_ganancias As Button
    Friend WithEvents btn_Clientes As Button
    Friend WithEvents btn_ganancias2 As Button
    Friend WithEvents btn_productos As Button
End Class
