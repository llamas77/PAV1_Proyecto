Imports PAV1_Proyecto

Public Class ClienteGrilla
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
            Return New ClienteVO(sRow.Cells("nroCliente").Value(), sRow.Cells("nombre").Value(), sRow.Cells("apellido").Value(),
                                  sRow.Cells("telefono").Value(), sRow.Cells("direccion").Value(),
                                  sRow.Cells("idTipoCliente").Selected, sRow.Cells("nombreIdTipoCliente").Selected)
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

    Private Sub cargar(clientes As DataTable)
        For i = 0 To clientes.Rows.Count() - 1 ' Recorre filas
            grilla_datos.Rows.Add()
            For Each column_name In {"nroCliente", "nombre", "apellido", "telefono", "direccion", "idTipoCliente", "nombreIdTipoCliente"}
                grilla_datos.Rows(i).Cells(column_name).Value = clientes(i)(column_name)
            Next
        Next
    End Sub

    Public Overloads Sub Focus() Implements ObjetoGrilla.Focus
        MyBase.Focus()
    End Sub

    Private Sub grilla_datos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grilla_datos.CellContentClick

    End Sub

    Public Function get_all() As List(Of ObjetoVO) Implements ObjetoGrilla.get_all
        Throw New NotImplementedException()
    End Function

    Public Sub add_objeto(value As ObjetoVO) Implements ObjetoGrilla.add_objeto
        Throw New NotImplementedException()
    End Sub

    Public Sub delete_selected() Implements ObjetoGrilla.delete_selected
        Throw New NotImplementedException()
    End Sub
End Class
