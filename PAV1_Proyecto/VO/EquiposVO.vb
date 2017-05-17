Imports PAV1_Proyecto

Public Class EquiposVO
    Implements ObjetoVO


    Public Property _id As Integer

    Public Property _idMarca As Integer

    Public Property _modelo As String

    Public Property _marca As String

    Public Sub New(id, idMarca, marca, modelo)
        _id = id
        _idMarca = idMarca
        _marca = marca
        _modelo = modelo

    End Sub

    Public Sub New()
        Me.New(0, 0, "", "")
    End Sub

    '
    ' Interfaz ObjetoVO
    '
    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return _marca & ", " & _modelo
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Throw New NotImplementedException()
    End Function

End Class
