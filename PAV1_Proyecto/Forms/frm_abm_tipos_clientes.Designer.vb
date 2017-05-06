<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_abm_tipos_clientes
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
        Dim TipoClienteVO4 As PAV1_Proyecto.TipoClienteVO = New PAV1_Proyecto.TipoClienteVO()
        Me.btn_actualizar = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.ctrl_tipo_cliente = New PAV1_Proyecto.TipoClienteControl()
        Me.btn_eliminar = New System.Windows.Forms.Button()
        Me.btn_modificar = New System.Windows.Forms.Button()
        Me.grilla_tipo_cliente = New PAV1_Proyecto.TipoClienteGrilla()
        Me.SuspendLayout()
        '
        'btn_actualizar
        '
        Me.btn_actualizar.Location = New System.Drawing.Point(322, 41)
        Me.btn_actualizar.Name = "btn_actualizar"
        Me.btn_actualizar.Size = New System.Drawing.Size(92, 32)
        Me.btn_actualizar.TabIndex = 1
        Me.btn_actualizar.Text = "Actualizar"
        Me.btn_actualizar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(366, 293)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(75, 32)
        Me.btn_cancelar.TabIndex = 1
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'ctrl_tipo_cliente
        '
        TipoClienteVO4._descripcion = ""
        TipoClienteVO4._id = 0
        TipoClienteVO4._nombre = ""
        Me.ctrl_tipo_cliente._TipoClienteVO = TipoClienteVO4
        Me.ctrl_tipo_cliente.Location = New System.Drawing.Point(13, 12)
        Me.ctrl_tipo_cliente.Name = "ctrl_tipo_cliente"
        Me.ctrl_tipo_cliente.Size = New System.Drawing.Size(295, 61)
        Me.ctrl_tipo_cliente.TabIndex = 2
        '
        'btn_eliminar
        '
        Me.btn_eliminar.Location = New System.Drawing.Point(94, 293)
        Me.btn_eliminar.Name = "btn_eliminar"
        Me.btn_eliminar.Size = New System.Drawing.Size(75, 32)
        Me.btn_eliminar.TabIndex = 1
        Me.btn_eliminar.Text = "Eliminar"
        Me.btn_eliminar.UseVisualStyleBackColor = True
        '
        'btn_modificar
        '
        Me.btn_modificar.Location = New System.Drawing.Point(13, 293)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(75, 32)
        Me.btn_modificar.TabIndex = 1
        Me.btn_modificar.Text = "Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'grilla_tipo_cliente
        '
        Me.grilla_tipo_cliente.Location = New System.Drawing.Point(13, 80)
        Me.grilla_tipo_cliente.Name = "grilla_tipo_cliente"
        Me.grilla_tipo_cliente.Size = New System.Drawing.Size(428, 193)
        Me.grilla_tipo_cliente.TabIndex = 3
        '
        'frm_abm_tipos_clientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 337)
        Me.Controls.Add(Me.grilla_tipo_cliente)
        Me.Controls.Add(Me.ctrl_tipo_cliente)
        Me.Controls.Add(Me.btn_modificar)
        Me.Controls.Add(Me.btn_eliminar)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_actualizar)
        Me.Name = "frm_abm_tipos_clientes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ABM Tipos de Clientes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_actualizar As Button
    Friend WithEvents btn_cancelar As Button
    Friend WithEvents ctrl_tipo_cliente As TipoClienteControl
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents btn_modificar As Button
    Friend WithEvents grilla_tipo_cliente As TipoClienteGrilla
End Class
