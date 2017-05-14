﻿Imports PAV1_Proyecto

Public Class TipoClienteVO
    Implements ObjetoVO

    Dim id As Integer
    Dim nombre As String
    Dim descripcion As String

    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal descripcion As String)
        Me.id = id
        Me.nombre = nombre
        Me.descripcion = descripcion
    End Sub

    Public Sub New()
        Me.New(0, "", "")
    End Sub

    Public Sub New(id As Integer)
        Me.New(id, "", "")
    End Sub

    Public Property _id
        Get
            Return id
        End Get
        Set(value)
            id = value
        End Set
    End Property

    Public Property _nombre
        Get
            Return nombre
        End Get
        Set(value)
            nombre = value
        End Set
    End Property

    Public Property _descripcion
        Get
            Return descripcion
        End Get
        Set(value)
            descripcion = value
        End Set
    End Property

    Public Function toString() As String Implements ObjetoVO.toString
        Return nombre
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Throw New NotImplementedException()
    End Function

    'Public Function estructura_grilla(visibles As Boolean) As List(Of String) Implements ObjetoVOGrillable.estructura_grilla
    '    If visibles Then ' Lista de columnas visibles
    '        Return New List(Of String) From {"id", "nombre", "descripcion"}
    '    Else ' Lista de columnas ocultas
    '        Return New List(Of String) From {}
    '    End If
    'End Function
End Class
