Imports PAV1_Proyecto

Public Class TipoClienteVO
    Implements ObjetoVO

    Public Property _id As Integer = 0
    Public Property _nombre As String = ""
    Public Property _descripcion As String = ""

    Public Overrides Function toString() As String Implements ObjetoVO.toString
        Return _nombre
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("id", _id)
        diccionario.Add("nombre", _nombre)
        diccionario.Add("descripcion", _descripcion)
        Return diccionario
    End Function
End Class
