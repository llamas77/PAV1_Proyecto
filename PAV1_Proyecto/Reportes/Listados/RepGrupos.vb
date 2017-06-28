Public Class RepGrupos
    Private Sub RepGrupos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctrl_list As New List(Of Campo)
        ctrl_list.Add(New Campo With {._id = "familia", ._name = "Familia", ._maskType = Campo.MaskType.comboBox,
                      ._objetoDAO = New FamiliaDAO})
        ctrl_list.Add(New Campo With {._id = "nombre", ._name = "Nombre grupo"})

        For Each campo In ctrl_list
            panel_control.Controls.Add(campo.get_UserControl)
        Next
        buscar()
    End Sub

    Private Sub btn_buscar_Click(sender As Object, e As EventArgs) Handles btn_buscar.Click
        buscar()
    End Sub

    Private Sub buscar()
        Dim db = DataBase.getInstance()
        Dim filtros As New Dictionary(Of String, Object)
        For Each campo As ObjetoCampo In panel_control.Controls
            filtros(campo._id) = campo._value
        Next

        Dim sql = "SELECT g.nombre, f.nombre as nombre_familia "
        sql &= " FROM grupos g "
        sql &= " JOIN familias f ON g.idFamilia = f.idFamilia "

        Dim hay_where = False
        If Not filtros("nombre") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            sql &= " g.nombre LIKE '%" & filtros("nombre") & "%' "
            hay_where = True
        End If
        If Not filtros("familia") Is Nothing Then
            sql &= IIf(hay_where, " AND ", " WHERE ")
            With DirectCast(filtros("familia"), FamiliaVO)
                sql &= " g.idFamilia=" & ._id
            End With
            hay_where = True
        End If

        Dim response = db.consulta_sql(sql)

        grid_datos.Rows.Clear()
        Dim currentRow As Integer
        Dim keys = {"nombre", "nombre_familia"}
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

    End Sub
End Class