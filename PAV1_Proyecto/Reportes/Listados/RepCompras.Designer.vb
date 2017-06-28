<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepCompras
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
        Me.idCompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.razon_social = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_compra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_resultados
        '
        Me.lbl_resultados.AutoSize = True
        Me.lbl_resultados.Location = New System.Drawing.Point(11, 128)
        Me.lbl_resultados.Name = "lbl_resultados"
        Me.lbl_resultados.Size = New System.Drawing.Size(91, 17)
        Me.lbl_resultados.TabIndex = 8
        Me.lbl_resultados.Text = "0 Resultados"
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(422, 112)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(153, 33)
        Me.btn_buscar.TabIndex = 6
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'panel_control
        '
        Me.panel_control.Location = New System.Drawing.Point(12, 12)
        Me.panel_control.Name = "panel_control"
        Me.panel_control.Size = New System.Drawing.Size(652, 95)
        Me.panel_control.TabIndex = 5
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
        Me.grid_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idCompra, Me.razon_social, Me.fecha_compra, Me.monto})
        Me.grid_datos.Location = New System.Drawing.Point(11, 151)
        Me.grid_datos.MultiSelect = False
        Me.grid_datos.Name = "grid_datos"
        Me.grid_datos.ReadOnly = True
        Me.grid_datos.RowTemplate.Height = 24
        Me.grid_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_datos.Size = New System.Drawing.Size(652, 392)
        Me.grid_datos.TabIndex = 7
        '
        'idCompra
        '
        Me.idCompra.HeaderText = "ID"
        Me.idCompra.Name = "idCompra"
        Me.idCompra.ReadOnly = True
        Me.idCompra.Width = 50
        '
        'razon_social
        '
        Me.razon_social.HeaderText = "Proveedor"
        Me.razon_social.MinimumWidth = 200
        Me.razon_social.Name = "razon_social"
        Me.razon_social.ReadOnly = True
        Me.razon_social.Width = 200
        '
        'fecha_compra
        '
        Me.fecha_compra.HeaderText = "Fecha"
        Me.fecha_compra.MinimumWidth = 125
        Me.fecha_compra.Name = "fecha_compra"
        Me.fecha_compra.ReadOnly = True
        Me.fecha_compra.Width = 125
        '
        'monto
        '
        Me.monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.monto.HeaderText = "Monto"
        Me.monto.Name = "monto"
        Me.monto.ReadOnly = True
        '
        'RepCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 555)
        Me.Controls.Add(Me.lbl_resultados)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.panel_control)
        Me.Controls.Add(Me.grid_datos)
        Me.MaximumSize = New System.Drawing.Size(690, 9999)
        Me.MinimumSize = New System.Drawing.Size(690, 400)
        Me.Name = "RepCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RepCompras"
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_resultados As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents panel_control As FlowLayoutPanel
    Friend WithEvents grid_datos As DataGridView
    Friend WithEvents idCompra As DataGridViewTextBoxColumn
    Friend WithEvents razon_social As DataGridViewTextBoxColumn
    Friend WithEvents fecha_compra As DataGridViewTextBoxColumn
    Friend WithEvents monto As DataGridViewTextBoxColumn
End Class
