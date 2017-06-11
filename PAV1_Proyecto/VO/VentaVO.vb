
Imports PAV1_Proyecto
Public Class VentaVO
    Implements ObjetoVO

    Public Property _id As Integer = 0
    Public Property _vendedor As VendedorVO = Nothing
    Public Property _cliente As ClienteVO = Nothing
    Public Property _fecha_venta As String = ""
    Public Property _nro_comprobante As Integer = 0
    Public Property detalle As List(Of ObjetoVO) = Nothing

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("id", _id)
        diccionario.Add("vendedor", _vendedor)
        diccionario.Add("cliente", _cliente)
        diccionario.Add("fecha_venta", _fecha_venta)
        diccionario.Add("nroComprobante", _nro_comprobante)
        diccionario.Add("detalles", detalle)
        Return diccionario
    End Function

    Public Overrides Function ToString() As String Implements ObjetoVO.toString
        Return "Venta del " & _fecha_venta.ToString & "(" & _id & ")"
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean Implements ObjetoVO.Equals
        ' Valida que la PK sea igual. Los contenidos pueden ser distintos.
        If TypeOf obj Is VentaVO Then
            With DirectCast(obj, VentaVO)
                Return ._id = Me._id
            End With
        Else
            Return False
        End If
    End Function
End Class
