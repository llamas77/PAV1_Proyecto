Imports PAV1_Proyecto

Public Class DetalleVentaVO
    Implements ObjetoVO

    Public Property codigo_producto As String

    Public Property id_venta As Integer

    Public Property precio As Double

    Public Property cantidad As Integer

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("codigo_producto", codigo_producto)
        diccionario.Add("id_venta", id_venta)
        diccionario.Add("precio", precio)
        diccionario.Add("cantidad", cantidad)
        Return diccionario
    End Function

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Throw New NotImplementedException()
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean Implements ObjetoVO.Equals
        If TypeOf obj Is DetalleVentaVO Then
            With DirectCast(obj, DetalleVentaVO)
                Return .id_venta = Me.id_venta And .codigo_producto = Me.codigo_producto
            End With
        Else
            Return False
        End If
    End Function
End Class
