Imports PAV1_Proyecto

Public Class EquiposVO
    Implements ObjetoVO

    Public Property _id As Integer

    Public Property _modelo As String

    Public Property _marca As MarcaVO

    Public Overrides Function toString() As String Implements ObjetoVO.toString
        Return _marca.toString() & ", " & _modelo
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("id", _id)
        diccionario.Add("modelo", _modelo)
        diccionario.Add("marca", _marca)
        Return diccionario
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean Implements ObjetoVO.Equals
        If TypeOf obj Is EquiposVO Then
            With DirectCast(obj, EquiposVO)
                Return ._id = Me._id
            End With
        Else
            Return False
        End If
    End Function

End Class
