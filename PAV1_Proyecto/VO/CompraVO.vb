Imports PAV1_Proyecto

Public Class CompraVO
    Implements ObjetoVO

    Public Property _id As Integer = 0
    Public Property _fecha_compra As String = ""
    Public Property _proveedor As ProveedorVO = Nothing
    Public Property detalle As List(Of ObjetoVO) = Nothing

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

    Public Overrides Function Equals(obj As Object) As Boolean Implements ObjetoVO.Equals
        If TypeOf obj Is CompraVO Then
            With DirectCast(obj, CompraVO)
                Return ._id = Me._id
            End With
        Else
            Return False
        End If
    End Function
End Class
