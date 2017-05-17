﻿Imports PAV1_Proyecto
Imports System

Public Class ProductoVO
    Implements ObjetoVO

    'No faltaria además un nombre para el producto?

    Public Property _codigo As String
    Public Property _grupo As GrupoVO
    Public Property _costo As Single
    Public Property _fechaLista As Double
    Public Property _nivelReposicion As Integer
    Public Property _ubicacion As String
    Public Property _stock As Integer

    Public Sub New()
        Me.New(0, Nothing, 0, 0, Nothing, "", 0)
    End Sub

    Public Sub New(codigo, grupo, costo, nivelReposicion, fechaLista, ubicacion, stock)
        _codigo = codigo
        _grupo = grupo
        _costo = costo
        _nivelReposicion = nivelReposicion
        _ubicacion = ubicacion
        _stock = stock

        If TypeOf fechaLista Is DateTime Then
            _fechaLista = Util.DateTimeToUnixTimestamp(fechaLista)
        Else
            _fechaLista = fechaLista
        End If
    End Sub

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("codigoProducto", _codigo)
        diccionario.Add("idGrupo", _grupo._id)
        diccionario.Add("nombre", _grupo._nombre)
        diccionario.Add("costo", _costo)
        diccionario.Add("fechaLista", _fechaLista) 'Propiedad o atributo?? osea, trabajo en Double o DateTime? (ya lo tengo que ver)
        diccionario.Add("nivelReposicion", _nivelReposicion)
        diccionario.Add("ubicacion", _ubicacion)
        diccionario.Add("stock", _stock)
        Return diccionario
    End Function

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return "Producto " & _codigo & ", grupo: " & _grupo._nombre
    End Function
End Class
