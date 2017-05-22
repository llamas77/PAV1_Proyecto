<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ClienteGrilla
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.grilla_datos = New System.Windows.Forms.DataGridView()
        Me.nro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idTipoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombreIdTipoCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idProveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grilla_datos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grilla_datos
        '
        Me.grilla_datos.AllowUserToAddRows = False
        Me.grilla_datos.AllowUserToDeleteRows = False
        Me.grilla_datos.AllowUserToResizeRows = False
        Me.grilla_datos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grilla_datos.BackgroundColor = System.Drawing.Color.White
        Me.grilla_datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nro, Me.nombre, Me.apellido, Me.telefono, Me.direccion, Me.idTipoCliente, Me.nombreIdTipoCliente, Me.idProveedor})
        Me.grilla_datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grilla_datos.Location = New System.Drawing.Point(0, 0)
        Me.grilla_datos.Margin = New System.Windows.Forms.Padding(2)
        Me.grilla_datos.MultiSelect = False
        Me.grilla_datos.Name = "grilla_datos"
        Me.grilla_datos.ReadOnly = True
        Me.grilla_datos.RowTemplate.Height = 24
        Me.grilla_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla_datos.Size = New System.Drawing.Size(232, 227)
        Me.grilla_datos.TabIndex = 1
        '
        'nro
        '
        Me.nro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.nro.HeaderText = "nro"
        Me.nro.Name = "nro"
        Me.nro.ReadOnly = True
        Me.nro.Width = 47
        '
        'nombre
        '
        Me.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 69
        '
        'apellido
        '
        Me.apellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.apellido.HeaderText = "Apellido"
        Me.apellido.Name = "apellido"
        Me.apellido.ReadOnly = True
        Me.apellido.Width = 69
        '
        'telefono
        '
        Me.telefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.telefono.HeaderText = "Telefono"
        Me.telefono.Name = "telefono"
        Me.telefono.ReadOnly = True
        Me.telefono.Visible = False
        '
        'direccion
        '
        Me.direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.direccion.HeaderText = "Direccion"
        Me.direccion.Name = "direccion"
        Me.direccion.ReadOnly = True
        Me.direccion.Visible = False
        '
        'idTipoCliente
        '
        Me.idTipoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.idTipoCliente.HeaderText = "idTipoCliente"
        Me.idTipoCliente.Name = "idTipoCliente"
        Me.idTipoCliente.ReadOnly = True
        Me.idTipoCliente.Visible = False
        '
        'nombreIdTipoCliente
        '
        Me.nombreIdTipoCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.nombreIdTipoCliente.HeaderText = "nombreIdTipoCliente"
        Me.nombreIdTipoCliente.Name = "nombreIdTipoCliente"
        Me.nombreIdTipoCliente.ReadOnly = True
        Me.nombreIdTipoCliente.Visible = False
        '
        'idProveedor
        '
        Me.idProveedor.HeaderText = "ID Proveedor"
        Me.idProveedor.Name = "idProveedor"
        Me.idProveedor.ReadOnly = True
        Me.idProveedor.Visible = False
        Me.idProveedor.Width = 95
        '
        'ClienteGrilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grilla_datos)
        Me.Name = "ClienteGrilla"
        Me.Size = New System.Drawing.Size(232, 227)
        CType(Me.grilla_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grilla_datos As DataGridView
    Friend WithEvents nro As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents apellido As DataGridViewTextBoxColumn
    Friend WithEvents telefono As DataGridViewTextBoxColumn
    Friend WithEvents direccion As DataGridViewTextBoxColumn
    Friend WithEvents idTipoCliente As DataGridViewTextBoxColumn
    Friend WithEvents nombreIdTipoCliente As DataGridViewTextBoxColumn
    Friend WithEvents idProveedor As DataGridViewTextBoxColumn
End Class
