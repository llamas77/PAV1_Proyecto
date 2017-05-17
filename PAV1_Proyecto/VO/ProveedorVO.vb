Imports PAV1_Proyecto

Public Class ProveedorVO
    Implements ObjetoVO

    Public Property _id As Integer

    Public Property _razonSocial As String

    Public Property _cuit As String

    Public Property _domicilio As String

    Public Property _telefono As String

    Public Property _email As String

    Public Sub New(id, razonSocial, cuit, domicilio, telefono, email)
        _id = id
        _razonSocial = razonSocial
        _cuit = cuit
        _domicilio = domicilio
        _telefono = telefono
        _email = email
    End Sub

    Public Sub New()
        Me.New(0, "", 0, "", "", "")
    End Sub


    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return _cuit & " - " & _razonSocial
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Throw New NotImplementedException()
    End Function
End Class
