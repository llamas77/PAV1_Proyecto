Imports PAV1_Proyecto
Imports System

Public Class ProductoVO
    Implements ObjetoVO

    Public Property _codigo As String = ""
    Public Property _grupo As GrupoVO = Nothing
    Public Property _costo As Double = 0.0
    Public Property _fechaLista As String = ""
    Public Property _nivelReposicion As Integer = 0
    Public Property _ubicacion As String = ""
    Public Property _stock As Integer = 0
    Public Property _equipos As New List(Of ObjetoVO)


    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("codigo", _codigo)
        diccionario.Add("grupo", _grupo)
        diccionario.Add("costo", _costo)
        diccionario.Add("fechaLista", _fechaLista)
        diccionario.Add("nivelReposicion", _nivelReposicion)
        diccionario.Add("ubicacion", _ubicacion)
        diccionario.Add("stock", _stock)
        diccionario.Add("equipos", _equipos)
        Return diccionario
    End Function

    Public Overrides Function toString() As String Implements ObjetoVO.toString
        Return _codigo
    End Function
End Class
