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
            value = value.Replace("%", "").Replace(" ", "")
            If value <> "" Then
                _proporcion_ganancia = value / 100
            Else
                _proporcion_ganancia = Nothing
            End If
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
        diccionario.Add("tipo_cliente", _tipo_cliente)
        diccionario.Add("ganancia", _proporcion_ganancia)
        diccionario.Add("porcentaje_ganancia", _porcentaje_ganancia)
        Return diccionario
    End Function

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return "Ganancia sobre " & _tipo_cliente._nombre & " en " & _grupo._nombre & " (" & _porcentaje_ganancia & ")"
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean Implements ObjetoVO.Equals
        If TypeOf obj Is GananciaVO Then
            With DirectCast(obj, GananciaVO)
                Return ._grupo.Equals(Me._grupo) And ._tipo_cliente.Equals(Me._tipo_cliente)
            End With
        Else
            Return False
        End If
    End Function
End Class
