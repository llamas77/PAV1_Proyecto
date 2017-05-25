﻿Imports PAV1_Proyecto

Public Class DetalleCompraVO
    Implements ObjetoVO

    Public Property codigo_producto As String

    Public Property id_compra As Integer

    Public Property costo As Integer

    Public Property cantidad As Integer

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("codigo_producto", codigo_producto)
        diccionario.Add("id_compra", id_compra)
        diccionario.Add("costo", costo)
        diccionario.Add("cantidad", cantidad)
        Return diccionario
    End Function

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Throw New NotImplementedException()
    End Function
End Class
