Imports PAV1_Proyecto

Public Class VendedorGrilla
    Implements ObjetoGrilla

    Public Sub recargar(value As DataTable) Implements ObjetoGrilla.recargar
        Dim index = vaciar()
        ' TODO: Validar que el DataTable tiene un formato aceptable (minimo de columnas)
        cargar(value)
        set_index(index)
    End Sub

    Public Function get_selected() As ObjetoVO Implements ObjetoGrilla.get_selected
        ' DOC: Retorna el ObjetoVO seleccionado en la grilla.
        Dim sRow = grilla_datos.CurrentRow()
        If IsNothing(sRow) Then
            Return Nothing
        Else
            Return New VendedorVO(sRow.Cells("id").Value(), sRow.Cells("nombre").Value(), sRow.Cells("apellido").Value(),
                                  sRow.Cells("telefono").Value(), sRow.Cells("direccion").Value(),
                                  sRow.Cells("comision").Value())
        End If
    End Function

    Private Function vaciar() As Integer
        Dim index = 0
        If grilla_datos.Rows.Count > 0 Then
            index = grilla_datos.CurrentRow().Index
            grilla_datos.Rows.Clear()
        End If
        Return index
    End Function

    Private Sub set_index(index As Integer)
        ' Si no hay datos no setea. 
        If grilla_datos.Rows.Count > 0 Then
            If grilla_datos.Rows.Count() <= index Then ' Si el indice esta fuera de rango, pongo al ultimo.
                index = grilla_datos.Rows.Count - 1
            End If
            grilla_datos.CurrentCell = grilla_datos.Rows(index).Cells(0)
        End If
    End Sub

    Private Sub cargar(tipos_clientes As DataTable)
        For i = 0 To tipos_clientes.Rows.Count() - 1 ' Recorre filas
            grilla_datos.Rows.Add()
            For Each column_name In {"id", "nombre", "apellido", "telefono", "direccion", "comision"}
                grilla_datos.Rows(i).Cells(column_name).Value = tipos_clientes(i)(column_name)
            Next
        Next
    End Sub

End Class
