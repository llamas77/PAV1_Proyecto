<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepClientes
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
        Me.nroCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre_tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.monto_ventas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_resultados
        '
        Me.lbl_resultados.AutoSize = True
        Me.lbl_resultados.Location = New System.Drawing.Point(9, 202)
        Me.lbl_resultados.Name = "lbl_resultados"
        Me.lbl_resultados.Size = New System.Drawing.Size(91, 17)
        Me.lbl_resultados.TabIndex = 12
        Me.lbl_resultados.Text = "0 Resultados"
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(434, 186)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(153, 33)
        Me.btn_buscar.TabIndex = 10
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'panel_control
        '
        Me.panel_control.Location = New System.Drawing.Point(12, 12)
        Me.panel_control.Name = "panel_control"
        Me.panel_control.Size = New System.Drawing.Size(652, 168)
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
        Me.grid_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nroCliente, Me.nombre, Me.apellido, Me.direccion, Me.telefono, Me.nombre_tipo, Me.monto_ventas})
        Me.grid_datos.Location = New System.Drawing.Point(11, 222)
        Me.grid_datos.MultiSelect = False
        Me.grid_datos.Name = "grid_datos"
        Me.grid_datos.ReadOnly = True
        Me.grid_datos.RowTemplate.Height = 24
        Me.grid_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_datos.Size = New System.Drawing.Size(737, 374)
        Me.grid_datos.TabIndex = 11
        '
        'nroCliente
        '
        Me.nroCliente.HeaderText = "Nro Cliente"
        Me.nroCliente.Name = "nroCliente"
        Me.nroCliente.ReadOnly = True
        Me.nroCliente.Width = 99
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
        'nombre_tipo
        '
        Me.nombre_tipo.HeaderText = "Tipo de Cliente"
        Me.nombre_tipo.Name = "nombre_tipo"
        Me.nombre_tipo.ReadOnly = True
        Me.nombre_tipo.Width = 121
        '
        'monto_ventas
        '
        Me.monto_ventas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.monto_ventas.HeaderText = "Monto de Ventas"
        Me.monto_ventas.Name = "monto_ventas"
        Me.monto_ventas.ReadOnly = True
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Location = New System.Drawing.Point(593, 185)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(71, 34)
        Me.btn_limpiar.TabIndex = 13
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'RepClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 608)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.lbl_resultados)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.panel_control)
        Me.Controls.Add(Me.grid_datos)
        Me.MaximumSize = New System.Drawing.Size(781, 9999)
        Me.MinimumSize = New System.Drawing.Size(781, 500)
        Me.Name = "RepClientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RepClientes"
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_resultados As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents panel_control As FlowLayoutPanel
    Friend WithEvents grid_datos As DataGridView
    Friend WithEvents nroCliente As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents apellido As DataGridViewTextBoxColumn
    Friend WithEvents direccion As DataGridViewTextBoxColumn
    Friend WithEvents telefono As DataGridViewTextBoxColumn
    Friend WithEvents nombre_tipo As DataGridViewTextBoxColumn
    Friend WithEvents monto_ventas As DataGridViewTextBoxColumn
    Friend WithEvents btn_limpiar As Button
End Class
