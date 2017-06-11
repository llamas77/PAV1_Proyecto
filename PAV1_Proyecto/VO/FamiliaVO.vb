Imports PAV1_Proyecto

Public Class FamiliaVO
    Implements ObjetoVO

    ' DOC: FamiliaVO (FamilliaValueObject) solo tiene propiedades.
    '      Representa una fila de la tabla Familia. Se la utiliza para ahorrar parametros (un objeto
    '      en lugar de los atributos) y facilitar la modificacion del sistema.

    Public Property _id As Integer
    Public Property _nombre As String

    Public Overrides Function toString() As String Implements ObjetoVO.toString
        Return _nombre
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("id", _id)
        diccionario.Add("nombre", _nombre)
        Return diccionario
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean Implements ObjetoVO.Equals
        If TypeOf obj Is FamiliaVO Then
            With DirectCast(obj, FamiliaVO)
                Return ._id = Me._id
            End With
        Else
            Return False
        End If
    End Function
End Class
