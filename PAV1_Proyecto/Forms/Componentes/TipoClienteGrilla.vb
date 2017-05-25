﻿Imports PAV1_Proyecto

Public Class TipoClienteGrilla
    Inherits UserControl
    Implements ObjetoGrilla

    Public Sub recargar(valores As List(Of ObjetoVO)) Implements ObjetoGrilla.recargar
        Dim index = vaciar()

        For Each valor As ObjetoVO In valores
            add_row(valor.toDictionary())
        Next
        set_index(index)
    End Sub

    Public Function get_selected() As ObjetoVO Implements ObjetoGrilla.get_selected
        ' DOC: Retorna el ObjetoVO seleccionado en la grilla.
        Dim sRow = grilla_datos.CurrentRow()
        If IsNothing(sRow) Then
            Return Nothing
        Else
            Return New TipoClienteVO(sRow.Cells(0).Value(), sRow.Cells(1).Value(), sRow.Cells(2).Value())
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

    Private Sub add_row(tipos_clientes As Dictionary(Of String, Object))
        Dim i = grilla_datos.Rows.Add()
        grilla_datos.Rows(i).Cells(0).Value = tipos_clientes.ElementAt(0)
        grilla_datos.Rows(i).Cells(1).Value = tipos_clientes.ElementAt(1)
        grilla_datos.Rows(i).Cells(2).Value = tipos_clientes.ElementAt(2)
    End Sub

    Public Overloads Sub Focus() Implements ObjetoGrilla.Focus
        MyBase.Focus()
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
