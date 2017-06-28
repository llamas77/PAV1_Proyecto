Public Class RepProductos

    Dim chk_bajo_reposicion As New CheckBox With {
        .Text = "Por debajo de nivel de reposicion.",
        .AutoSize = True
    }

    Private Sub RepProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "fecha_desde", ._name = "Fecha Lista Desde", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "costo_min", ._name = "Costo Min.", ._numeric = True})
        ctrl_list.Add(New Campo With {._id = "fecha_hasta", ._name = "Fecha Lista Hasta", ._maskType = Campo.MaskType.fecha})
        ctrl_list.Add(New Campo With {._id = "costo_max", ._name = "Costo Max.", ._numeric = True})

        ctrl_list.Add(New Campo With {._id = "grupo", ._name = "Grupo", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New GrupoDAO})
        ctrl_list.Add(New Campo With {._id = "equipo", ._name = "Equipo", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New EquiposDAO})
        ctrl_list.Add(New Campo With {._id = "familia", ._name = "Familia", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New FamiliaDAO})
        ctrl_list.Add(New Campo With {._id = "stock_min", ._name = "Stock Min.", ._numeric = True})
        ctrl_list.Add(New Campo With {._id = "ubicacion", ._name = "Ubicacion"})
        ctrl_list.Add(New Campo With {._id = "stock_max", ._name = "Stock Max.", ._numeric = True})
        ctrl_list.Add(New Campo With {._id = "codigo", ._name = "Código"})


        For Each campo In ctrl_list
            panel_control.Controls.Add(campo.get_UserControl)
        Next
        chk_bajo_reposicion.Location = New Point(panel_control.Location.X, panel_control.Location.Y + panel_control.Size.Height)
        Me.Controls.Add(chk_bajo_reposicion)


        buscar()
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        buscar()
    End Sub
    Private Function validar_filtros() As Boolean
        Dim valido = True
        For Each campo As Validable In panel_control.Controls
            valido = IIf(campo.is_valid, valido, False)
        Next
        Return valido
    End Function
    Private Sub buscar()
        If Not validar_filtros() Then
            MsgBox("Algun/os campos de filtro son invalidos.")
            Exit Sub
        End If
        Dim db = DataBase.getInstance()
        Dim filtros As New Dictionary(Of String, Object)
        For Each campo As ObjetoCampo In panel_control.Controls
            filtros(campo._id) = campo._value
        Next
        filtros("bajo_reposicion") = chk_bajo_reposicion.Checked

        Dim sql = "SELECT p.codigoProducto as codigo, g.nombre as nombre_grupo, f.nombre as nombre_familia, "
        sql &= " p.costo, convert(char(10), p.fechaLista, 103) as fecha_lista, p.stock, p.nivelReposicion as nivel_reposicion, "
        sql &= " p.ubicacion"
        sql &= " FROM productos p "
        sql &= " JOIN grupos g ON p.idGrupo = g.idGrupo"
        sql &= " JOIN familias f ON g.idFamilia = f.idFamilia"

        Dim hay_where = False
        If Not filtros("fecha_desde") = "/  /" Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.fechaLista >= convert(date,'" & filtros("fecha_desde") & "', 103) "
            hay_where = True
        End If
        If Not filtros("fecha_hasta") = "/  /" Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.fechaLista <= convert(date,'" & filtros("fecha_hasta") & "', 103) "
            hay_where = True
        End If

        If filtros("costo_min") <> 0 Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.costo >= " & filtros("costo_min")
            hay_where = True
        End If
        If filtros("costo_max") <> 0 Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.costo <= " & filtros("costo_max")
            hay_where = True
        End If
        If filtros("stock_min") <> 0 Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.stock >= " & filtros("stock_min")
            hay_where = True
        End If
        If filtros("stock_max") <> 0 Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.stock <= " & filtros("stock_max")
            hay_where = True
        End If
        If filtros("bajo_reposicion") Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.stock < p.nivelReposicion "
            hay_where = True
        End If
        If Not filtros("codigo") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.codigoProducto LIKE '%" & filtros("codigo") & "%' "
            hay_where = True
        End If
        If Not filtros("ubicacion") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " p.ubicacion LIKE '%" & filtros("ubicacion") & "%' "
            hay_where = True
        End If
        If Not filtros("grupo") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("grupo"), GrupoVO)
                sql &= " p.idGrupo=" & ._id
            End With
            hay_where = True
        End If
        If Not filtros("familia") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("familia"), FamiliaVO)
                sql &= " g.idFamilia=" & ._id
            End With
            hay_where = True
        End If
        If Not filtros("equipo") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("equipo"), EquiposVO)
                sql &= " EXISTS (SELECT TOP 1 0 FROM productosxequipos pxe"
                sql &= " WHERE pxe.codigoProducto = p.codigoProducto"
                sql &= " AND pxe.idEquipo=" & ._id & ")"
            End With
            hay_where = True
        End If

        Dim response = db.consulta_sql(sql)

        grid_datos.Rows.Clear()
        Dim currentRow As Integer
        Dim keys = {"codigo", "nombre_grupo", "nombre_familia", "costo", "fecha_lista", "stock", "nivel_reposicion", "ubicacion"}
        For Each row As DataRow In response.Rows
            currentRow = grid_datos.Rows.Add()
            For Each key In keys
                grid_datos.Rows(currentRow).Cells(key).Value = row(key)
            Next
        Next
        lbl_resultados.Text = response.Rows.Count & " resultados"

    End Sub

    Private Sub repVentas_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click
        For Each campo As Control In panel_control.Controls
            campo.ResetText()
        Next
    End Sub
End Class