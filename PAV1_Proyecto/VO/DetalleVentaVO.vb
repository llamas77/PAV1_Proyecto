Imports PAV1_Proyecto

Public Class DetalleVentaVO
    Implements ObjetoVO

    Public Property codigo_producto As String

    Public Property id_venta As Integer

    Public Property costo As Double

    Public Property cantidad As Integer

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("codigo_producto", codigo_producto)
        diccionario.Add("id_venta", id_venta)
        diccionario.Add("costo", costo)
        diccionario.Add("cantidad", cantidad)
        Return diccionario
    End Function

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Throw New NotImplementedException()
    End Function
End Class
