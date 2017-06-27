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
        Me.panel_control = New System.Windows.Forms.FlowLayoutPanel()
        Me.btn_buscar = New System.Windows.Forms.Button()
        Me.idVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre_cliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre_vendedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_venta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nro_comprobante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid_datos
        '
        Me.grid_datos.AllowUserToAddRows = False
        Me.grid_datos.AllowUserToDeleteRows = False
        Me.grid_datos.BackgroundColor = System.Drawing.Color.White
        Me.grid_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idVenta, Me.nombre_cliente, Me.nombre_vendedor, Me.fecha_venta, Me.nro_comprobante})
        Me.grid_datos.Location = New System.Drawing.Point(13, 170)
        Me.grid_datos.MultiSelect = False
        Me.grid_datos.Name = "grid_datos"
        Me.grid_datos.ReadOnly = True
        Me.grid_datos.RowTemplate.Height = 24
        Me.grid_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_datos.Size = New System.Drawing.Size(652, 298)
        Me.grid_datos.TabIndex = 3
        '
        'panel_control
        '
        Me.panel_control.Location = New System.Drawing.Point(13, 13)
        Me.panel_control.Name = "panel_control"
        Me.panel_control.Size = New System.Drawing.Size(652, 111)
        Me.panel_control.TabIndex = 1
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(590, 130)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(75, 34)
        Me.btn_buscar.TabIndex = 2
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'idVenta
        '
        Me.idVenta.HeaderText = "ID"
        Me.idVenta.Name = "idVenta"
        Me.idVenta.ReadOnly = True
        '
        'nombre_cliente
        '
        Me.nombre_cliente.HeaderText = "Cliente"
        Me.nombre_cliente.Name = "nombre_cliente"
        Me.nombre_cliente.ReadOnly = True
        '
        'nombre_vendedor
        '
        Me.nombre_vendedor.HeaderText = "Vendedor"
        Me.nombre_vendedor.Name = "nombre_vendedor"
        Me.nombre_vendedor.ReadOnly = True
        '
        'fecha_venta
        '
        Me.fecha_venta.HeaderText = "Fecha"
        Me.fecha_venta.Name = "fecha_venta"
        Me.fecha_venta.ReadOnly = True
        '
        'nro_comprobante
        '
        Me.nro_comprobante.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nro_comprobante.HeaderText = "Nro Comprobante"
        Me.nro_comprobante.Name = "nro_comprobante"
        Me.nro_comprobante.ReadOnly = True
        '
        'RepVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 480)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.panel_control)
        Me.Controls.Add(Me.grid_datos)
        Me.Name = "RepVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RepVentas"
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grid_datos As DataGridView
    Friend WithEvents panel_control As FlowLayoutPanel
    Friend WithEvents btn_buscar As Button
    Friend WithEvents idVenta As DataGridViewTextBoxColumn
    Friend WithEvents nombre_cliente As DataGridViewTextBoxColumn
    Friend WithEvents nombre_vendedor As DataGridViewTextBoxColumn
    Friend WithEvents fecha_venta As DataGridViewTextBoxColumn
    Friend WithEvents nro_comprobante As DataGridViewTextBoxColumn
End Class
