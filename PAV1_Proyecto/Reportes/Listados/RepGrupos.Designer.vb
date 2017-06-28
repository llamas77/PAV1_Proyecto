<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepGrupos
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
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre_familia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_limpiar = New System.Windows.Forms.Button()
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_resultados
        '
        Me.lbl_resultados.AutoSize = True
        Me.lbl_resultados.Location = New System.Drawing.Point(20, 97)
        Me.lbl_resultados.Name = "lbl_resultados"
        Me.lbl_resultados.Size = New System.Drawing.Size(91, 17)
        Me.lbl_resultados.TabIndex = 16
        Me.lbl_resultados.Text = "0 Resultados"
        '
        'btn_buscar
        '
        Me.btn_buscar.Location = New System.Drawing.Point(126, 81)
        Me.btn_buscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btn_buscar.Name = "btn_buscar"
        Me.btn_buscar.Size = New System.Drawing.Size(153, 33)
        Me.btn_buscar.TabIndex = 14
        Me.btn_buscar.Text = "Buscar"
        Me.btn_buscar.UseVisualStyleBackColor = True
        '
        'panel_control
        '
        Me.panel_control.Location = New System.Drawing.Point(20, 11)
        Me.panel_control.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.panel_control.Name = "panel_control"
        Me.panel_control.Size = New System.Drawing.Size(340, 65)
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
        Me.grid_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nombre, Me.nombre_familia})
        Me.grid_datos.Location = New System.Drawing.Point(20, 121)
        Me.grid_datos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.grid_datos.MultiSelect = False
        Me.grid_datos.Name = "grid_datos"
        Me.grid_datos.ReadOnly = True
        Me.grid_datos.RowTemplate.Height = 24
        Me.grid_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_datos.Size = New System.Drawing.Size(340, 190)
        Me.grid_datos.TabIndex = 15
        '
        'nombre
        '
        Me.nombre.HeaderText = "Grupo"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 77
        '
        'nombre_familia
        '
        Me.nombre_familia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nombre_familia.HeaderText = "Familia"
        Me.nombre_familia.Name = "nombre_familia"
        Me.nombre_familia.ReadOnly = True
        '
        'btn_limpiar
        '
        Me.btn_limpiar.Location = New System.Drawing.Point(289, 80)
        Me.btn_limpiar.Name = "btn_limpiar"
        Me.btn_limpiar.Size = New System.Drawing.Size(71, 34)
        Me.btn_limpiar.TabIndex = 17
        Me.btn_limpiar.Text = "Limpiar"
        Me.btn_limpiar.UseVisualStyleBackColor = True
        '
        'RepGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 321)
        Me.Controls.Add(Me.btn_limpiar)
        Me.Controls.Add(Me.lbl_resultados)
        Me.Controls.Add(Me.btn_buscar)
        Me.Controls.Add(Me.panel_control)
        Me.Controls.Add(Me.grid_datos)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximumSize = New System.Drawing.Size(397, 9999)
        Me.MinimumSize = New System.Drawing.Size(397, 300)
        Me.Name = "RepGrupos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RepGrupos"
        CType(Me.grid_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbl_resultados As Label
    Friend WithEvents btn_buscar As Button
    Friend WithEvents panel_control As FlowLayoutPanel
    Friend WithEvents grid_datos As DataGridView
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents nombre_familia As DataGridViewTextBoxColumn
    Friend WithEvents btn_limpiar As Button
End Class
