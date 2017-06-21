<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_menu
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosEnStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosBajoLimiteDeRepToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesPorFechaDeUltimaCompraToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosAsociadosAUnEquipoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadísticasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FamiliasDeProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GruposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GananciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GruposToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EquiposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarcasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EquiposToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TiposDeClientesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VendedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VendedoresToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProveedoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProveedoresToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeComprasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VentasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteDeVentasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprasPorMesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportesToolStripMenuItem, Me.ProductosToolStripMenuItem, Me.EquiposToolStripMenuItem, Me.ClientesToolStripMenuItem, Me.VendedoresToolStripMenuItem, Me.ProveedoresToolStripMenuItem, Me.ComprasToolStripMenuItem, Me.VentasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(693, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListadosToolStripMenuItem, Me.EstadísticasToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'ListadosToolStripMenuItem
        '
        Me.ListadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProductosEnStockToolStripMenuItem, Me.ProductosBajoLimiteDeRepToolStripMenuItem, Me.ClientesPorFechaDeUltimaCompraToolStripMenuItem, Me.ProductosAsociadosAUnEquipoToolStripMenuItem, Me.ComprasPorMesToolStripMenuItem})
        Me.ListadosToolStripMenuItem.Name = "ListadosToolStripMenuItem"
        Me.ListadosToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ListadosToolStripMenuItem.Text = "Listados"
        '
        'ProductosEnStockToolStripMenuItem
        '
        Me.ProductosEnStockToolStripMenuItem.Name = "ProductosEnStockToolStripMenuItem"
        Me.ProductosEnStockToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.ProductosEnStockToolStripMenuItem.Text = "Productos en Stock"
        '
        'ProductosBajoLimiteDeRepToolStripMenuItem
        '
        Me.ProductosBajoLimiteDeRepToolStripMenuItem.Name = "ProductosBajoLimiteDeRepToolStripMenuItem"
        Me.ProductosBajoLimiteDeRepToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.ProductosBajoLimiteDeRepToolStripMenuItem.Text = "Productos bajo limite de rep"
        '
        'ClientesPorFechaDeUltimaCompraToolStripMenuItem
        '
        Me.ClientesPorFechaDeUltimaCompraToolStripMenuItem.Name = "ClientesPorFechaDeUltimaCompraToolStripMenuItem"
        Me.ClientesPorFechaDeUltimaCompraToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.ClientesPorFechaDeUltimaCompraToolStripMenuItem.Text = "Clientes por fecha de ultima compra"
        '
        'ProductosAsociadosAUnEquipoToolStripMenuItem
        '
        Me.ProductosAsociadosAUnEquipoToolStripMenuItem.Enabled = False
        Me.ProductosAsociadosAUnEquipoToolStripMenuItem.Name = "ProductosAsociadosAUnEquipoToolStripMenuItem"
        Me.ProductosAsociadosAUnEquipoToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.ProductosAsociadosAUnEquipoToolStripMenuItem.Text = "Productos asociados a un equipo"
        '
        'EstadísticasToolStripMenuItem
        '
        Me.EstadísticasToolStripMenuItem.Name = "EstadísticasToolStripMenuItem"
        Me.EstadísticasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EstadísticasToolStripMenuItem.Text = "Estadísticas"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FamiliasDeProductosToolStripMenuItem, Me.GruposToolStripMenuItem, Me.ProductosToolStripMenuItem1})
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'FamiliasDeProductosToolStripMenuItem
        '
        Me.FamiliasDeProductosToolStripMenuItem.Name = "FamiliasDeProductosToolStripMenuItem"
        Me.FamiliasDeProductosToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.FamiliasDeProductosToolStripMenuItem.Text = "Familias de productos"
        '
        'GruposToolStripMenuItem
        '
        Me.GruposToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GananciasToolStripMenuItem, Me.GruposToolStripMenuItem1})
        Me.GruposToolStripMenuItem.Name = "GruposToolStripMenuItem"
        Me.GruposToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.GruposToolStripMenuItem.Text = "Grupos"
        '
        'GananciasToolStripMenuItem
        '
        Me.GananciasToolStripMenuItem.Name = "GananciasToolStripMenuItem"
        Me.GananciasToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.GananciasToolStripMenuItem.Text = "Ganancias"
        '
        'GruposToolStripMenuItem1
        '
        Me.GruposToolStripMenuItem1.Name = "GruposToolStripMenuItem1"
        Me.GruposToolStripMenuItem1.Size = New System.Drawing.Size(128, 22)
        Me.GruposToolStripMenuItem1.Text = "Grupos"
        '
        'ProductosToolStripMenuItem1
        '
        Me.ProductosToolStripMenuItem1.Name = "ProductosToolStripMenuItem1"
        Me.ProductosToolStripMenuItem1.Size = New System.Drawing.Size(190, 22)
        Me.ProductosToolStripMenuItem1.Text = "Productos"
        '
        'EquiposToolStripMenuItem
        '
        Me.EquiposToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MarcasToolStripMenuItem, Me.EquiposToolStripMenuItem1})
        Me.EquiposToolStripMenuItem.Name = "EquiposToolStripMenuItem"
        Me.EquiposToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.EquiposToolStripMenuItem.Text = "Equipos"
        '
        'MarcasToolStripMenuItem
        '
        Me.MarcasToolStripMenuItem.Name = "MarcasToolStripMenuItem"
        Me.MarcasToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.MarcasToolStripMenuItem.Text = "Marcas"
        '
        'EquiposToolStripMenuItem1
        '
        Me.EquiposToolStripMenuItem1.Name = "EquiposToolStripMenuItem1"
        Me.EquiposToolStripMenuItem1.Size = New System.Drawing.Size(116, 22)
        Me.EquiposToolStripMenuItem1.Text = "Equipos"
        '
        'ClientesToolStripMenuItem
        '
        Me.ClientesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TiposDeClientesToolStripMenuItem, Me.ClientesToolStripMenuItem1})
        Me.ClientesToolStripMenuItem.Name = "ClientesToolStripMenuItem"
        Me.ClientesToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ClientesToolStripMenuItem.Text = "Clientes"
        '
        'TiposDeClientesToolStripMenuItem
        '
        Me.TiposDeClientesToolStripMenuItem.Name = "TiposDeClientesToolStripMenuItem"
        Me.TiposDeClientesToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.TiposDeClientesToolStripMenuItem.Text = "Tipos de clientes"
        '
        'ClientesToolStripMenuItem1
        '
        Me.ClientesToolStripMenuItem1.Name = "ClientesToolStripMenuItem1"
        Me.ClientesToolStripMenuItem1.Size = New System.Drawing.Size(162, 22)
        Me.ClientesToolStripMenuItem1.Text = "Clientes"
        '
        'VendedoresToolStripMenuItem
        '
        Me.VendedoresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VendedoresToolStripMenuItem1})
        Me.VendedoresToolStripMenuItem.Name = "VendedoresToolStripMenuItem"
        Me.VendedoresToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
        Me.VendedoresToolStripMenuItem.Text = "Vendedores"
        '
        'VendedoresToolStripMenuItem1
        '
        Me.VendedoresToolStripMenuItem1.Name = "VendedoresToolStripMenuItem1"
        Me.VendedoresToolStripMenuItem1.Size = New System.Drawing.Size(135, 22)
        Me.VendedoresToolStripMenuItem1.Text = "Vendedores"
        '
        'ProveedoresToolStripMenuItem
        '
        Me.ProveedoresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ProveedoresToolStripMenuItem1})
        Me.ProveedoresToolStripMenuItem.Name = "ProveedoresToolStripMenuItem"
        Me.ProveedoresToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.ProveedoresToolStripMenuItem.Text = "Proveedores"
        '
        'ProveedoresToolStripMenuItem1
        '
        Me.ProveedoresToolStripMenuItem1.Name = "ProveedoresToolStripMenuItem1"
        Me.ProveedoresToolStripMenuItem1.Size = New System.Drawing.Size(139, 22)
        Me.ProveedoresToolStripMenuItem1.Text = "Proveedores"
        '
        'ComprasToolStripMenuItem
        '
        Me.ComprasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ComprasToolStripMenuItem1, Me.ReporteDeComprasToolStripMenuItem})
        Me.ComprasToolStripMenuItem.Name = "ComprasToolStripMenuItem"
        Me.ComprasToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.ComprasToolStripMenuItem.Text = "Compras"
        '
        'ComprasToolStripMenuItem1
        '
        Me.ComprasToolStripMenuItem1.Name = "ComprasToolStripMenuItem1"
        Me.ComprasToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.ComprasToolStripMenuItem1.Text = "Compras"
        '
        'ReporteDeComprasToolStripMenuItem
        '
        Me.ReporteDeComprasToolStripMenuItem.Enabled = False
        Me.ReporteDeComprasToolStripMenuItem.Name = "ReporteDeComprasToolStripMenuItem"
        Me.ReporteDeComprasToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ReporteDeComprasToolStripMenuItem.Text = "Reporte de compras"
        '
        'VentasToolStripMenuItem
        '
        Me.VentasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VentasToolStripMenuItem1, Me.ReporteDeVentasToolStripMenuItem})
        Me.VentasToolStripMenuItem.Name = "VentasToolStripMenuItem"
        Me.VentasToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.VentasToolStripMenuItem.Text = "Ventas"
        '
        'VentasToolStripMenuItem1
        '
        Me.VentasToolStripMenuItem1.Name = "VentasToolStripMenuItem1"
        Me.VentasToolStripMenuItem1.Size = New System.Drawing.Size(168, 22)
        Me.VentasToolStripMenuItem1.Text = "Ventas"
        '
        'ReporteDeVentasToolStripMenuItem
        '
        Me.ReporteDeVentasToolStripMenuItem.Enabled = False
        Me.ReporteDeVentasToolStripMenuItem.Name = "ReporteDeVentasToolStripMenuItem"
        Me.ReporteDeVentasToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ReporteDeVentasToolStripMenuItem.Text = "Reporte de ventas"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AcercaDeToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Enabled = False
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca de..."
        '
        'ComprasPorMesToolStripMenuItem
        '
        Me.ComprasPorMesToolStripMenuItem.Name = "ComprasPorMesToolStripMenuItem"
        Me.ComprasPorMesToolStripMenuItem.Size = New System.Drawing.Size(266, 22)
        Me.ComprasPorMesToolStripMenuItem.Text = "Compras por mes"
        '
        'frm_menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(693, 444)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frm_menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAV1 Proyecto"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FamiliasDeProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GruposToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EquiposToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MarcasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EquiposToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TiposDeClientesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents GananciasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GruposToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents VendedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VendedoresToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProveedoresToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ComprasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComprasToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VentasToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ReporteDeComprasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteDeVentasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadísticasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosEnStockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosBajoLimiteDeRepToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClientesPorFechaDeUltimaCompraToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosAsociadosAUnEquipoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComprasPorMesToolStripMenuItem As ToolStripMenuItem
End Class
