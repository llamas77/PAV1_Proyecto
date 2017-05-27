Imports PAV1_Proyecto

Public Class MarcaVO
    Implements ObjetoVO

    Public Property _id As Integer
    Public Property _nombre As String

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("id", _id)
        diccionario.Add("nombre", _nombre)
        Return diccionario
    End Function

    Public Overrides Function toString() As String Implements ObjetoVO.toString
        Return _nombre
    End Function
End Class
