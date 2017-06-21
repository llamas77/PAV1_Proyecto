

Partial Public Class DatosListado
    Partial Public Class ganancias_por_tipo_de_ClienteDataTable
        Private Sub ganancias_por_tipo_de_ClienteDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.gananciaColumn.ColumnName) Then
                'Agregar código de usuario aquí
            End If

        End Sub

    End Class
End Class
