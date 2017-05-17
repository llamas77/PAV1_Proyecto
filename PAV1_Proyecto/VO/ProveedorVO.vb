Imports PAV1_Proyecto

Public Class ProveedorVO
    Implements ObjetoVO

    Public Property _id_proveedor As Integer

    Public Property _razon_social As String

    Public Property _cuit As String

    Public Property _domicilio As String

    Public Property _telefono As String

    Public Property _email As String

    Public Sub New(id_proveedor, razon_social, cuit, domicilio, telefono, email)
        _id_proveedor = id_proveedor
        _razon_social = razon_social
        _cuit = cuit
        _domicilio = domicilio
        _telefono = telefono
        _email = email
    End Sub

    Public Sub New()
        Me.New(0, "", 0, "", "", "")
    End Sub


    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return _cuit & " - " & _razon_social
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Throw New NotImplementedException()
    End Function
End Class
