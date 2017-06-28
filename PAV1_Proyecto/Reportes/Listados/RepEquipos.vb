Public Class RepEquipos
    Private Sub RepVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "marca", ._name = "Marca", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New MarcaDAO})
        ctrl_list.Add(New Campo With {._id = "modelo", ._name = "Modelo"})

        For Each campo In ctrl_list
            panel_control.Controls.Add(campo.get_UserControl)
        Next
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

        Dim sql = "SELECT e.modelo, m.nombre as nombre_marca "
        sql &= " FROM equipos e "
        sql &= " JOIN marcas m ON e.idMarca = m.idMarca "

        Dim hay_where = False
        If Not filtros("modelo") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " e.modelo LIKE '%" & filtros("modelo") & "%' "
            hay_where = True
        End If
        If Not filtros("marca") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("marca"), MarcaVO)
                sql &= " e.idMarca=" & ._id
            End With
            hay_where = True
        End If

        Dim response = db.consulta_sql(sql)

        grid_datos.Rows.Clear()
        Dim currentRow As Integer
        Dim keys = {"nombre_marca", "modelo"}
        For Each row As DataRow In response.Rows
            currentRow = grid_datos.Rows.Add()
            For Each key In keys
                grid_datos.Rows(currentRow).Cells(key).Value = row(key)
            Next

        Next

        lbl_resultados.Text = response.Rows.Count & " resultados"

    End Sub

    Private Sub repCompras_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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