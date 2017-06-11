Imports PAV1_Proyecto

Public Class GrupoVO
    Implements ObjetoVO

    Public Property _id As Integer = 0
    Public Property _nombre As String = ""
    Public Property _familia As FamiliaVO = Nothing

    Public Overrides Function toString() As String Implements ObjetoVO.toString
        Return _nombre & " de " & _familia.toString()
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("id", _id)
        diccionario.Add("nombre", _nombre)
        diccionario.Add("familia", _familia)
        Return diccionario
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean Implements ObjetoVO.Equals
        If TypeOf obj Is GrupoVO Then
            With DirectCast(obj, GrupoVO)
                Return ._id = Me._id
            End With
        Else
            Return False
        End If
    End Function
End Class
