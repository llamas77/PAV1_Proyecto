﻿Public Class repEstMovXFlia



    Private Sub repEstMovXFlia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim db As DataBase = DataBase.getInstance()
        Dim sql As String = ""
        Dim tabla As New DataTable

        sql = "select z.nombre, sum(z.CantidadMov) as CantidadMov "
        sql &= "from ((select f.nombre, COUNT(dc.idCompra) as CantidadMov "
        sql &= "from familias f join grupos g on f.idFamilia = g.idFamilia "
        sql &= "join productos p on g.idGrupo = p.idGrupo "
        sql &= "join detalle_compras dc on p.codigoProducto = dc.codigoProducto "
        sql &= "group by f.nombre) "
        sql &= "union all "
        sql &= "(select f.nombre, COUNT(dv.idVenta) as CantidadMov "
        sql &= "from familias f join grupos g on f.idFamilia = g.idFamilia "
        sql &= "join productos p on g.idGrupo = p.idGrupo "
        sql &= "join detalleVentas dv on p.codigoProducto = dv.codigoProducto "
        sql &= "group by f.nombre)) as z "
        sql &= "group by z.nombre "

        If txt_lim_inf.Text <> "" And txt_lim_sup.Text <> "" Then
            sql &= " having SUM(z.CantidadMov) between '" & txt_lim_inf.Text & "' and '" & txt_lim_sup.Text & "' "

        End If
        tabla = db.consulta_sql(sql)

        'NOMBREBindingSource.DataSource = tabla
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        repEstMovXFlia_Load(sender, e)
    End Sub
End Class