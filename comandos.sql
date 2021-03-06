USE [master]
GO
/****** Object:  Database [sistema_stock]    Script Date: 26/06/2017 11:32:17 p.m. ******/
CREATE DATABASE [sistema_stock]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sistema_stock', FILENAME = N'd:\Programas Windows\SQL Server Express 2012\MSSQL11.SQLEXPRESS\MSSQL\DATA\sistema_stock.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sistema_stock_log', FILENAME = N'd:\Programas Windows\SQL Server Express 2012\MSSQL11.SQLEXPRESS\MSSQL\DATA\sistema_stock_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [sistema_stock] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sistema_stock].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sistema_stock] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sistema_stock] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sistema_stock] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sistema_stock] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sistema_stock] SET ARITHABORT OFF 
GO
ALTER DATABASE [sistema_stock] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sistema_stock] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [sistema_stock] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sistema_stock] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sistema_stock] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sistema_stock] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sistema_stock] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sistema_stock] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sistema_stock] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sistema_stock] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sistema_stock] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sistema_stock] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sistema_stock] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sistema_stock] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sistema_stock] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sistema_stock] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sistema_stock] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sistema_stock] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sistema_stock] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sistema_stock] SET  MULTI_USER 
GO
ALTER DATABASE [sistema_stock] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sistema_stock] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sistema_stock] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sistema_stock] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [sistema_stock]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[clientes](
	[nroCliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[idTipoCliente] [int] NOT NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[nroCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[compras]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[compras](
	[idCompra] [int] IDENTITY(1,1) NOT NULL,
	[fechaCompra] [datetime] NOT NULL,
	[idProveedor] [int] NOT NULL,
 CONSTRAINT [PK_compras] PRIMARY KEY CLUSTERED 
(
	[idCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detalle_compras]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[detalle_compras](
	[codigoProducto] [varchar](20) NOT NULL,
	[idCompra] [int] NOT NULL,
	[costo] [float] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_detalle_compras] PRIMARY KEY CLUSTERED 
(
	[codigoProducto] ASC,
	[idCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detalleVentas]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[detalleVentas](
	[idVenta] [int] NOT NULL,
	[codigoProducto] [varchar](20) NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio] [float] NOT NULL,
 CONSTRAINT [PK_detalleVentas] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC,
	[codigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[equipos]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[equipos](
	[modelo] [varchar](50) NOT NULL,
	[idMarca] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_equipos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UNIQUE_marca_modelo] UNIQUE NONCLUSTERED 
(
	[modelo] ASC,
	[idMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[familias]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[familias](
	[idFamilia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_familias] PRIMARY KEY CLUSTERED 
(
	[idFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UNIQUE_nombre_familias] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ganancias]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ganancias](
	[idGrupo] [int] NOT NULL,
	[idTipo] [int] NOT NULL,
	[ganancia] [float] NOT NULL,
 CONSTRAINT [PK_ganancias] PRIMARY KEY CLUSTERED 
(
	[idGrupo] ASC,
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[grupos]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[grupos](
	[idGrupo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[idFamilia] [int] NOT NULL,
 CONSTRAINT [PK_grupos] PRIMARY KEY CLUSTERED 
(
	[idGrupo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UNIQUE_grupos] UNIQUE NONCLUSTERED 
(
	[idFamilia] ASC,
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[marcas]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[marcas](
	[idMarca] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_marcas] PRIMARY KEY CLUSTERED 
(
	[idMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UNIQUE_nombre] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[productos]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[productos](
	[codigoProducto] [varchar](20) NOT NULL,
	[idGrupo] [int] NOT NULL,
	[costo] [float] NOT NULL,
	[fechaLista] [date] NOT NULL,
	[nivelReposicion] [int] NULL,
	[ubicacion] [varchar](25) NULL,
	[stock] [int] NOT NULL,
 CONSTRAINT [PK_productos] PRIMARY KEY CLUSTERED 
(
	[codigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[productosxequipos]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[productosxequipos](
	[codigoProducto] [varchar](20) NOT NULL,
	[idEquipo] [int] NOT NULL,
 CONSTRAINT [PK_productosxequipos] PRIMARY KEY CLUSTERED 
(
	[codigoProducto] ASC,
	[idEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedores]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedores](
	[idProveedor] [int] IDENTITY(1,1) NOT NULL,
	[razonSocial] [varchar](50) NOT NULL,
	[cuit] [varchar](20) NOT NULL,
	[domicilio] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_proveedores] PRIMARY KEY CLUSTERED 
(
	[idProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UNIQUE_cuit] UNIQUE NONCLUSTERED 
(
	[cuit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipos_cliente]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipos_cliente](
	[idTipo] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](20) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_tipos_cliente] PRIMARY KEY CLUSTERED 
(
	[idTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UNIQUE_tipos_cliente] UNIQUE NONCLUSTERED 
(
	[nombre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vendedores]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[vendedores](
	[idVendedor] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NULL,
	[direccion] [varchar](50) NULL,
	[telefono] [varchar](50) NULL,
	[comision] [float] NOT NULL,
 CONSTRAINT [PK_vendedores] PRIMARY KEY CLUSTERED 
(
	[idVendedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 26/06/2017 11:32:17 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ventas](
	[idVenta] [int] IDENTITY(1,1) NOT NULL,
	[nroCliente] [int] NOT NULL,
	[idVendedor] [int] NOT NULL,
	[fechaVenta] [date] NOT NULL,
	[nroComprobante] [varchar](20) NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_productos]    Script Date: 26/06/2017 11:32:17 p.m. ******/
CREATE NONCLUSTERED INDEX [IX_productos] ON [dbo].[productos]
(
	[codigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[productos] ADD  CONSTRAINT [DF_productos_fechaLista]  DEFAULT (getdate()) FOR [fechaLista]
GO
ALTER TABLE [dbo].[vendedores] ADD  CONSTRAINT [DF_vendedores_comision]  DEFAULT ((0)) FOR [comision]
GO
ALTER TABLE [dbo].[clientes]  WITH CHECK ADD  CONSTRAINT [FK_clientes_tipos_cliente] FOREIGN KEY([idTipoCliente])
REFERENCES [dbo].[tipos_cliente] ([idTipo])
GO
ALTER TABLE [dbo].[clientes] CHECK CONSTRAINT [FK_clientes_tipos_cliente]
GO
ALTER TABLE [dbo].[compras]  WITH CHECK ADD  CONSTRAINT [FK_compras_proveedores] FOREIGN KEY([idProveedor])
REFERENCES [dbo].[proveedores] ([idProveedor])
GO
ALTER TABLE [dbo].[compras] CHECK CONSTRAINT [FK_compras_proveedores]
GO
ALTER TABLE [dbo].[detalle_compras]  WITH CHECK ADD  CONSTRAINT [FK_detalle_compras_compras] FOREIGN KEY([idCompra])
REFERENCES [dbo].[compras] ([idCompra])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_compras] CHECK CONSTRAINT [FK_detalle_compras_compras]
GO
ALTER TABLE [dbo].[detalle_compras]  WITH CHECK ADD  CONSTRAINT [FK_detalle_compras_productos] FOREIGN KEY([codigoProducto])
REFERENCES [dbo].[productos] ([codigoProducto])
GO
ALTER TABLE [dbo].[detalle_compras] CHECK CONSTRAINT [FK_detalle_compras_productos]
GO
ALTER TABLE [dbo].[detalleVentas]  WITH CHECK ADD  CONSTRAINT [FK_detalleVentas_productos] FOREIGN KEY([codigoProducto])
REFERENCES [dbo].[productos] ([codigoProducto])
GO
ALTER TABLE [dbo].[detalleVentas] CHECK CONSTRAINT [FK_detalleVentas_productos]
GO
ALTER TABLE [dbo].[detalleVentas]  WITH CHECK ADD  CONSTRAINT [FK_detalleVentas_ventas] FOREIGN KEY([idVenta])
REFERENCES [dbo].[ventas] ([idVenta])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalleVentas] CHECK CONSTRAINT [FK_detalleVentas_ventas]
GO
ALTER TABLE [dbo].[equipos]  WITH CHECK ADD  CONSTRAINT [FK_equipos_marcas] FOREIGN KEY([idMarca])
REFERENCES [dbo].[marcas] ([idMarca])
GO
ALTER TABLE [dbo].[equipos] CHECK CONSTRAINT [FK_equipos_marcas]
GO
ALTER TABLE [dbo].[ganancias]  WITH CHECK ADD  CONSTRAINT [FK_ganancias_grupos] FOREIGN KEY([idGrupo])
REFERENCES [dbo].[grupos] ([idGrupo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ganancias] CHECK CONSTRAINT [FK_ganancias_grupos]
GO
ALTER TABLE [dbo].[ganancias]  WITH CHECK ADD  CONSTRAINT [FK_ganancias_tipos_cliente] FOREIGN KEY([idTipo])
REFERENCES [dbo].[tipos_cliente] ([idTipo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ganancias] CHECK CONSTRAINT [FK_ganancias_tipos_cliente]
GO
ALTER TABLE [dbo].[grupos]  WITH CHECK ADD  CONSTRAINT [FK_grupos_familias] FOREIGN KEY([idFamilia])
REFERENCES [dbo].[familias] ([idFamilia])
GO
ALTER TABLE [dbo].[grupos] CHECK CONSTRAINT [FK_grupos_familias]
GO
ALTER TABLE [dbo].[productos]  WITH CHECK ADD  CONSTRAINT [FK_productos_grupos] FOREIGN KEY([idGrupo])
REFERENCES [dbo].[grupos] ([idGrupo])
GO
ALTER TABLE [dbo].[productos] CHECK CONSTRAINT [FK_productos_grupos]
GO
ALTER TABLE [dbo].[productosxequipos]  WITH CHECK ADD  CONSTRAINT [FK_productosxequipos_equipos] FOREIGN KEY([idEquipo])
REFERENCES [dbo].[equipos] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[productosxequipos] CHECK CONSTRAINT [FK_productosxequipos_equipos]
GO
ALTER TABLE [dbo].[productosxequipos]  WITH CHECK ADD  CONSTRAINT [FK_productosxequipos_productos] FOREIGN KEY([codigoProducto])
REFERENCES [dbo].[productos] ([codigoProducto])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[productosxequipos] CHECK CONSTRAINT [FK_productosxequipos_productos]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_clientes] FOREIGN KEY([nroCliente])
REFERENCES [dbo].[clientes] ([nroCliente])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_clientes]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_vendedores] FOREIGN KEY([idVendedor])
REFERENCES [dbo].[vendedores] ([idVendedor])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_vendedores]
GO
USE [master]
GO
ALTER DATABASE [sistema_stock] SET  READ_WRITE 
GO
