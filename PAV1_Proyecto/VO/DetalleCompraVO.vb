Imports PAV1_Proyecto

Public Class DetalleCompraVO
    Implements ObjetoVO

    Public Property codigo_producto As String = ""

    Public Property id_compra As Integer = 0

    Public Property costo As Double = 0.0

    Public Property cantidad As Integer = 0

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

    Public Overrides Function Equals(obj As Object) As Boolean
        ' Valida que la PK sea igual. Los contenidos pueden ser distintos.
        If TypeOf obj Is DetalleCompraVO Then
            With DirectCast(obj, DetalleCompraVO)
                Return .id_compra = Me.id_compra And .codigo_producto = Me.codigo_producto
            End With
        Else
            Return False
        End If
    End Function
End Class
