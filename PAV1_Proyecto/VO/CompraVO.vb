Imports PAV1_Proyecto

Public Class CompraVO
    Implements ObjetoVO

    Public Property _id As Integer = 0
    Public Property _fecha_compra As String = ""
    Public Property _proveedor As ProveedorVO = Nothing
    Public Property detalle As List(Of DetalleCompraVO)

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("id", _id)
        diccionario.Add("fecha_compra", _fecha_compra)
        diccionario.Add("proveedor", _proveedor)
        diccionario.Add("detalles", detalle)
        Return diccionario
    End Function

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return "Compra del " & _fecha_compra.ToString & "(" & _id & ")"
    End Function
End Class
