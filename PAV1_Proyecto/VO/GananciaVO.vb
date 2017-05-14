Imports PAV1_Proyecto

Public Class GananciaVO
    Implements ObjetoVO

    Public Property _grupo As GrupoVO
    Public Property _tipo_cliente As TipoClienteVO
    Public Property _ganancia As Double
    Public Property _porcentaje_ganancia As String
        Get
            Return _ganancia * 100 & "%"
        End Get
        Set(value As String)
            value = value.Replace("%", "")
            _ganancia = value / 100
        End Set
    End Property

    Public Sub New(grupo As GrupoVO, tipo_cliente As TipoClienteVO, ganancia As Double)
        _grupo = grupo
        _tipo_cliente = tipo_cliente
        _ganancia = ganancia
    End Sub

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("grupo", _grupo)
        diccionario.Add("tipo_cliente", _tipo_cliente)
        diccionario.Add("ganancia", _ganancia)
        Return diccionario
    End Function

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return _grupo._nombre & " por " & _tipo_cliente._nombre & " (" & _ganancia * 100 & "%)"
    End Function
End Class
