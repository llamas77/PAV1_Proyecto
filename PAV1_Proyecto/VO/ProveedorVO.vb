﻿Imports PAV1_Proyecto

Public Class ProveedorVO
    Implements ObjetoVO

    Public Property _id As Integer = 0

    Public Property _razonSocial As String = ""

    Public Property _cuit As String = ""

    Public Property _domicilio As String = ""

    Public Property _telefono As String = ""

    Public Property _email As String = ""

    Public Overrides Function toString() As String Implements ObjetoVO.toString
        Return _razonSocial
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("idProveedor", _id)
        diccionario.Add("razonSocial", _razonSocial)
        diccionario.Add("cuit", _cuit)
        diccionario.Add("domicilio", _domicilio)
        diccionario.Add("telefono", _telefono)
        diccionario.Add("email", _email)
        Return diccionario
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean Implements ObjetoVO.Equals
        If TypeOf obj Is ProveedorVO Then
            With DirectCast(obj, ProveedorVO)
                Return ._id = Me._id
            End With
        Else
            Return False
        End If
    End Function
End Class
