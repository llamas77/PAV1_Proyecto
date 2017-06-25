Imports PAV1_Proyecto

Public Class ClienteVO
    Implements ObjetoVO

    Public Property _nro As Integer = 0

    Public Property _nombre As String = ""

    Public Property _apellido As String = ""

    Public Property _telefono As String = ""

    Public Property _direccion As String = ""

    Public Property _tipo_cliente As TipoClienteVO = Nothing


    Public Overrides Function toString() As String Implements ObjetoVO.toString
        Return _apellido & ", " & _nombre
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("nro", _nro)
        diccionario.Add("nombre", _nombre)
        diccionario.Add("apellido", _apellido)
        diccionario.Add("telefono", _telefono)
        diccionario.Add("direccion", _direccion)
        diccionario.Add("tipo_cliente", _tipo_cliente)
        Return diccionario
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean Implements ObjetoVO.Equals
        If TypeOf obj Is ClienteVO Then
            With DirectCast(obj, ClienteVO)
                Return ._nro = Me._nro
            End With
        Else
            Return False
        End If
    End Function
End Class
