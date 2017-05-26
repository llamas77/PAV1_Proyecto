Imports PAV1_Proyecto

Public Class GananciaVO
    Implements ObjetoVO

    Public Property _grupo As GrupoVO
    Public Property _tipo_cliente As TipoClienteVO
    Public Property _proporcion_ganancia As Double
    Public Property _porcentaje_ganancia As String
        Get
            Return _proporcion_ganancia * 100 & "%"
        End Get
        Set(value As String)
            value = value.Replace("%", "")
            _proporcion_ganancia = value / 100
        End Set
    End Property

    Public Sub New()
        ' Necesario para usar New con With.
    End Sub

    Public Sub New(grupo As GrupoVO, tipo_cliente As TipoClienteVO, ganancia As Double)
        _grupo = grupo
        _tipo_cliente = tipo_cliente
        _proporcion_ganancia = ganancia
    End Sub

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("grupo", _grupo)
        diccionario.Add("id_grupo", _grupo._id)
        diccionario.Add("nombre_grupo", _grupo._nombre)
        diccionario.Add("tipo_cliente", _tipo_cliente)
        diccionario.Add("id_tipo_cliente", _tipo_cliente._id)
        diccionario.Add("nombre_tipo_cliente", _tipo_cliente._nombre)
        diccionario.Add("ganancia", _proporcion_ganancia)
        diccionario.Add("porcentaje_ganancia", _porcentaje_ganancia)
        Return diccionario
    End Function

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return "Ganancia sobre " & _tipo_cliente._nombre & " en " & _grupo._nombre & " (" & _porcentaje_ganancia & ")"
    End Function
End Class
