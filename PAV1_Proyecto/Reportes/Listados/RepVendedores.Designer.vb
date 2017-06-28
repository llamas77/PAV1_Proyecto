<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepVendedores
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.lbl_resultados = New System.Windows.Forms.Label()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.panel_control = New System.Windows.Forms.FlowLayoutPanel()
        Me.grid_datos = New System.Windows.Forms.DataGridView()
        Me.idVendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.monto_ventas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_resultados
        '
        Me.lbl_resultados.AutoSize = True
        Me.lbl_resultados.Location = New System.Drawing.Point(8, 170)
        Me.lbl_resultados.Name = "lbl_resultados"
        Me.lbl_resultados.Size = New System.Drawing.Size(91, 17)
        Me.lbl_resultados.TabIndex = 12
        Me.lbl_resultados.Text = "0 Resultados"
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(419, 154)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(153, 33)
        Me.btn_buscar.TabIndex = 10
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'panel_control
        '
        Me.panel_control.Location = New System.Drawing.Point(12, 3)
        Me.panel_control.Name = "panel_control"
        Me.panel_control.Size = New System.Drawing.Size(652, 145)
        Me.panel_control.TabIndex = 9
        '
        'grid_datos
        '
        Me.grid_datos.AllowUserToAddRows = False
        Me.grid_datos.AllowUserToDeleteRows = False
        Me.grid_datos.AllowUserToResizeRows = False
        Me.grid_datos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid_datos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grid_datos.BackgroundColor = System.Drawing.Color.White
        Me.grid_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idVendedor, Me.nombre, Me.apellido, Me.direccion, Me.telefono, Me.monto_ventas})
        Me.grid_datos.Location = New System.Drawing.Point(11, 190)
        Me.grid_datos.MultiSelect = False
        Me.grid_datos.Name = "grid_datos"
        Me.grid_datos.ReadOnly = True
        Me.grid_datos.RowTemplate.Height = 24
        Me.grid_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_datos.Size = New System.Drawing.Size(653, 253)
        Me.grid_datos.TabIndex = 11
        '
        'idVendedor
        '
        Me.idVendedor.HeaderText = "ID"
        Me.idVendedor.Name = "idVendedor"
        Me.idVendedor.ReadOnly = True
        Me.idVendedor.Width = 50
        '
        'nombre
        '
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 87
        '
        'apellido
        '
        Me.apellido.HeaderText = "Apellido"
        Me.apellido.Name = "apellido"
        Me.apellido.ReadOnly = True
        Me.apellido.Width = 87
        '
        'direccion
        '
        Me.direccion.HeaderText = "Direccion"
        Me.direccion.Name = "direccion"
        Me.direccion.ReadOnly = True
        Me.direccion.Width = 96
        '
        'telefono
        '
        Me.telefono.HeaderText = "Telefono"
        Me.telefono.Name = "telefono"
        Me.telefono.ReadOnly = True
        Me.telefono.Width = 93
        '
        'monto_ventas
        '
        Me.monto_ventas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.monto_ventas.HeaderText = "Monto de Ventas"
        Me.monto_ventas.Name = "monto_ventas"
        Me.monto_ventas.ReadOnly = True
        '
        'btn_imprimir
        '
        Me.btn_imprimir.Location = New System.Drawing.Point(300, 154)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(100, 33)
        Me.btn_imprimir.TabIndex = 13
        Me.btn_imprimir.Text = "Imprimir"
        Me.btn_imprimir.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'RepVendedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 455)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.lbl_resultados)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.panel_control)
        Me.Controls.Add(Me.grid_datos)
        Me.MaximumSize = New System.Drawing.Size(697, 9999)
        Me.MinimumSize = New System.Drawing.Size(697, 400)
        Me.Name = "RepVendedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RepVendedores"
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_resultados As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents panel_control As FlowLayoutPanel
    Friend WithEvents grid_datos As DataGridView
    Friend WithEvents idVendedor As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents apellido As DataGridViewTextBoxColumn
    Friend WithEvents direccion As DataGridViewTextBoxColumn
    Friend WithEvents telefono As DataGridViewTextBoxColumn
    Friend WithEvents monto_ventas As DataGridViewTextBoxColumn
    Friend WithEvents btn_imprimir As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
End Class
