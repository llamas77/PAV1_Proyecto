<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepProveedores
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
        Me.razon_social = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.domicilio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.monto_compras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_resultados
        '
        Me.lbl_resultados.AutoSize = True
        Me.lbl_resultados.Location = New System.Drawing.Point(8, 179)
        Me.lbl_resultados.Name = "lbl_resultados"
        Me.lbl_resultados.Size = New System.Drawing.Size(91, 17)
        Me.lbl_resultados.TabIndex = 16
        Me.lbl_resultados.Text = "0 Resultados"
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(434, 163)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(153, 33)
        Me.btn_buscar.TabIndex = 14
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'panel_control
        '
        Me.panel_control.Location = New System.Drawing.Point(12, 12)
        Me.panel_control.Name = "panel_control"
        Me.panel_control.Size = New System.Drawing.Size(652, 145)
        Me.panel_control.TabIndex = 13
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
        Me.grid_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.razon_social, Me.domicilio, Me.telefono, Me.email, Me.monto_compras})
        Me.grid_datos.Location = New System.Drawing.Point(11, 199)
        Me.grid_datos.MultiSelect = False
        Me.grid_datos.Name = "grid_datos"
        Me.grid_datos.ReadOnly = True
        Me.grid_datos.RowTemplate.Height = 24
        Me.grid_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_datos.Size = New System.Drawing.Size(653, 364)
        Me.grid_datos.TabIndex = 15
        '
        'razon_social
        '
        Me.razon_social.HeaderText = "Razon Social"
        Me.razon_social.Name = "razon_social"
        Me.razon_social.ReadOnly = True
        Me.razon_social.Width = 110
        '
        'domicilio
        '
        Me.domicilio.HeaderText = "Domicilio"
        Me.domicilio.Name = "domicilio"
        Me.domicilio.ReadOnly = True
        Me.domicilio.Width = 93
        '
        'telefono
        '
        Me.telefono.HeaderText = "Telefono"
        Me.telefono.Name = "telefono"
        Me.telefono.ReadOnly = True
        Me.telefono.Width = 93
        '
        'email
        '
        Me.email.HeaderText = "E-mail"
        Me.email.Name = "email"
        Me.email.ReadOnly = True
        Me.email.Width = 76
        '
        'monto_compras
        '
        Me.monto_compras.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.monto_compras.HeaderText = "Monto de Compras"
        Me.monto_compras.Name = "monto_compras"
        Me.monto_compras.ReadOnly = True
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Location = New System.Drawing.Point(593, 162)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(71, 34)
        Me.btn_limpiar.TabIndex = 17
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'RepProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 575)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.lbl_resultados)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.panel_control)
        Me.Controls.Add(Me.grid_datos)
        Me.MaximumSize = New System.Drawing.Size(696, 9999)
        Me.MinimumSize = New System.Drawing.Size(696, 400)
        Me.Name = "RepProveedores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RepProveedores"
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_resultados As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents panel_control As FlowLayoutPanel
    Friend WithEvents grid_datos As DataGridView
    Friend WithEvents razon_social As DataGridViewTextBoxColumn
    Friend WithEvents domicilio As DataGridViewTextBoxColumn
    Friend WithEvents telefono As DataGridViewTextBoxColumn
    Friend WithEvents email As DataGridViewTextBoxColumn
    Friend WithEvents monto_compras As DataGridViewTextBoxColumn
    Friend WithEvents btn_limpiar As Button
End Class
