/* NOTA: Siempre que haga falta un Combo probablemente sea mas facil usar 
	los objetos campo:
		New Campo With {._id = "proveedor", ._name = "Proveedor", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New ProveedorDAO
	Luego con campo.get_UserControl obtenemos un Combo cargado con los proveedores.
*/
/* NOTA 2: Los filtros son opcionales, por lo tanto se debe usar un IF que controle si 
	el usuario los esta utilizando y filtre por ellos, y sino que no los incluya en la
	consulta.
*/

/* Comparación de ventas por periodo, grupo y familia. */
/* En este caso el periodo va a ser mensual */
SELECT MONTH(v.fechaVenta) as mes, SUM(dv.cantidad * dv.precio) as monto_ventas
FROM ventas v
JOIN detalleVentas dv ON v.idVenta = dv.idVenta
JOIN productos p ON dv.codigoProducto = p.codigoProducto
JOIN grupos g ON p.idGrupo = g.idGrupo
WHERE p.idGrupo = ##GRUPO_ID## 
AND g.idFamilia = ##FAMILIA_ID##
AND v.fechaVenta <= convert(date, ##FECHA_VENTA_MAX, 103)
AND v.fechaVenta >= convert(date, ##FECHA_VENTA_MIN, 103)
GROUP BY MONTH(v.fechaVenta)

/* Comparación de compras por periodo, grupo y familia. */
/* En este caso el periodo va a ser mensual */
SELECT MONTH(c.fechaCompra) as mes, SUM(dc.cantidad * dc.costo) as monto_compras
FROM compras c
JOIN detalle_compras dc ON c.idCompra = dc.idCompra
JOIN productos p ON dc.codigoProducto = p.codigoProducto
JOIN grupos g ON p.idGrupo = g.idGrupo
WHERE p.idGrupo = ##GRUPO_ID## 
AND g.idFamilia = ##FAMILIA_ID##
AND c.fechaCompra <= convert(date, ##FECHA_COMPRA_MAX, 103)
AND c.fechaCompra >= convert(date, ##FECHA_COMPRA_MIN, 103)
GROUP BY MONTH(c.fechaCompra)

/* Comparación de ventas de productos por equipo, marca y periodo. */
SELECT m.nombre as nombre_marca, e.modelo, ISNULL(SUM(dv.cantidad),0) as cantidad_ventas, 
ISNULL(SUM(dv.cantidad * dv.precio),0) as monto_ventas
FROM equipos e
JOIN marcas m ON e.idMarca = m.idMarca
LEFT JOIN productosxequipos pxe ON e.id = pxe.idEquipo
LEFT JOIN productos p ON p.codigoProducto = pxe.codigoProducto
LEFT JOIN detalleVentas dv ON p.codigoProducto = dv.codigoProducto
LEFT JOIN ventas v ON dv.idVenta = v.idVenta
WHERE e.idMarca = ##MARCA_ID
AND e.modelo LIKE "%##EQUIPO_MODELO##%" /* Nota: Los % si van. */
AND v.fechaVenta <= convert(date, ##FECHA_VENTA_MAX, 103)
AND v.fechaVenta >= convert(date, ##FECHA_VENTA_MIN, 103)
GROUP BY m.nombre, e.modelo

/* Comparación de ventas entre fechas por tipo de cliente. */
SELECT tc.nombre as tipo_cliente, ISNULL(SUM(dv.cantidad * dv.precio), 0) as monto_ventas
FROM tipos_cliente tc
LEFT JOIN clientes c ON tc.idTipo = c.idTipoCliente
LEFT JOIN ventas v ON c.nroCliente = v.nroCliente
LEFT JOIN detalleVentas dv ON v.idVenta = dv.idVenta
WHERE v.fechaVenta <= convert(date, ##FECHA_VENTA_MAX, 103)
AND v.fechaVenta >= convert(date, ##FECHA_VENTA_MIN, 103)
