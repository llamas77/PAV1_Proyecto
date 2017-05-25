Imports PAV1_Proyecto

Public Class DetalleCompraVO
    Implements ObjetoVO

    Public Property codigo_producto As String

    Public Property id_compra As Integer

    Public Property costo As Integer

    Public Property cantidad As Integer

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Throw New NotImplementedException()
    End Function

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Throw New NotImplementedException()
    End Function
End Class
