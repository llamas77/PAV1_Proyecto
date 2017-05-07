<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VendedorGrilla
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
        Me.grilla_datos = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.apellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.telefono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.direccion = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.grilla_datos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.nombre, Me.apellido, Me.comision, Me.telefono, Me.direccion})
        Me.grilla_datos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grilla_datos.Location = New System.Drawing.Point(0, 0)
        Me.grilla_datos.MultiSelect = False
        Me.grilla_datos.Name = "grilla_datos"
        Me.grilla_datos.ReadOnly = True
        Me.grilla_datos.RowTemplate.Height = 24
        Me.grilla_datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla_datos.Size = New System.Drawing.Size(506, 290)
        Me.grilla_datos.TabIndex = 0
        '
        'id
        '
        Me.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.id.HeaderText = "ID"
        Me.id.Name = "id"
        Me.id.ReadOnly = True
        Me.id.Width = 50
        '
        'nombre
        '
        Me.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.nombre.HeaderText = "Nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 87
        '
        'apellido
        '
        Me.apellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.apellido.HeaderText = "Apellido"
        Me.apellido.Name = "apellido"
        Me.apellido.ReadOnly = True
        Me.apellido.Width = 87
        '
        'comision
        '
        Me.comision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.comision.HeaderText = "Comision"
        Me.comision.Name = "comision"
        Me.comision.ReadOnly = True
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
        'VendedorGrilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grilla_datos)
        Me.Name = "VendedorGrilla"
        Me.Size = New System.Drawing.Size(506, 290)
        CType(Me.grilla_datos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grilla_datos As DataGridView
    Friend WithEvents id As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents apellido As DataGridViewTextBoxColumn
    Friend WithEvents comision As DataGridViewTextBoxColumn
    Friend WithEvents telefono As DataGridViewTextBoxColumn
    Friend WithEvents direccion As DataGridViewTextBoxColumn
End Class
