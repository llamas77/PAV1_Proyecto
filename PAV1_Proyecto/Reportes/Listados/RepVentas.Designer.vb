<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepVentas
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
        Me.grid_datos = New System.Windows.Forms.DataGridView()
        Me.idVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre_vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_venta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nro_comprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panel_control = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.lbl_resultados = New System.Windows.Forms.Label()
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.grid_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idVenta, Me.nombre_cliente, Me.nombre_vendedor, Me.fecha_venta, Me.monto, Me.nro_comprobante})
        Me.grid_datos.Location = New System.Drawing.Point(12, 191)
        Me.grid_datos.MultiSelect = False
        Me.grid_datos.Name = "grid_datos"
        Me.grid_datos.ReadOnly = True
        Me.grid_datos.RowTemplate.Height = 24
        Me.grid_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_datos.Size = New System.Drawing.Size(652, 445)
        Me.grid_datos.TabIndex = 3
        '
        'idVenta
        '
        Me.idVenta.HeaderText = "ID"
        Me.idVenta.Name = "idVenta"
        Me.idVenta.ReadOnly = True
        Me.idVenta.Width = 50
        '
        'nombre_cliente
        '
        Me.nombre_cliente.HeaderText = "Cliente"
        Me.nombre_cliente.Name = "nombre_cliente"
        Me.nombre_cliente.ReadOnly = True
        Me.nombre_cliente.Width = 80
        '
        'nombre_vendedor
        '
        Me.nombre_vendedor.HeaderText = "Vendedor"
        Me.nombre_vendedor.Name = "nombre_vendedor"
        Me.nombre_vendedor.ReadOnly = True
        Me.nombre_vendedor.Width = 99
        '
        'fecha_venta
        '
        Me.fecha_venta.HeaderText = "Fecha"
        Me.fecha_venta.Name = "fecha_venta"
        Me.fecha_venta.ReadOnly = True
        Me.fecha_venta.Width = 76
        '
        'monto
        '
        Me.monto.HeaderText = "Monto"
        Me.monto.Name = "monto"
        Me.monto.ReadOnly = True
        Me.monto.Width = 76
        '
        'nro_comprobante
        '
        Me.nro_comprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nro_comprobante.HeaderText = "Nro Comprobante"
        Me.nro_comprobante.Name = "nro_comprobante"
        Me.nro_comprobante.ReadOnly = True
        '
        'panel_control
        '
        Me.panel_control.Location = New System.Drawing.Point(13, 13)
        Me.panel_control.Name = "panel_control"
        Me.panel_control.Size = New System.Drawing.Size(652, 132)
        Me.panel_control.TabIndex = 1
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(512, 151)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(153, 34)
        Me.btn_buscar.TabIndex = 2
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'lbl_resultados
        '
        Me.lbl_resultados.AutoSize = True
        Me.lbl_resultados.Location = New System.Drawing.Point(12, 167)
        Me.lbl_resultados.Name = "lbl_resultados"
        Me.lbl_resultados.Size = New System.Drawing.Size(91, 17)
        Me.lbl_resultados.TabIndex = 4
        Me.lbl_resultados.Text = "0 Resultados"
        '
        'RepVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 650)
        Me.Controls.Add(Me.lbl_resultados)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.panel_control)
        Me.Controls.Add(Me.grid_datos)
        Me.MaximumSize = New System.Drawing.Size(695, 9999)
        Me.MinimumSize = New System.Drawing.Size(695, 395)
        Me.Name = "RepVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RepVentas"
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grid_datos As DataGridView
    Friend WithEvents panel_control As FlowLayoutPanel
    Friend WithEvents btn_buscar As Button
    Friend WithEvents idVenta As DataGridViewTextBoxColumn
    Friend WithEvents nombre_cliente As DataGridViewTextBoxColumn
    Friend WithEvents nombre_vendedor As DataGridViewTextBoxColumn
    Friend WithEvents fecha_venta As DataGridViewTextBoxColumn
    Friend WithEvents monto As DataGridViewTextBoxColumn
    Friend WithEvents nro_comprobante As DataGridViewTextBoxColumn
    Friend WithEvents lbl_resultados As Label
End Class
