Imports PAV1_Proyecto

Public Class ClienteVO
    Implements ObjetoVO


    Public Property _nro As Integer

    Public Property _nombre As String

    Public Property _apellido As String

    Public Property _telefono As String

    Public Property _direccion As String

    Public Property _idTipoCliente As Integer

    Public Property _nombreIdTipoCliente As String

    Public Sub New(nro, nombre, apellido, telefono, direccion, idTipoCliente, nombreIdTipoCliente)
        _nro = nro
        _nombre = nombre
        _apellido = apellido
        _telefono = telefono
        _direccion = direccion
        _idTipoCliente = idTipoCliente
        _nombreIdTipoCliente = nombreIdTipoCliente
    End Sub

    Public Sub New()
        Me.New(0, "", "", "", "", 0, "")
    End Sub

    '
    ' Interfaz ObjetoVO
    '
    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return _apellido & ", " & _nombre
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Throw New NotImplementedException()
    End Function
End Class
