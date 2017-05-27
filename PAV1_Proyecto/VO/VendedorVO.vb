Imports PAV1_Proyecto

Public Class VendedorVO
    Implements ObjetoVO

    Dim comision As Double

    Public Property _id As Integer

    Public Property _nombre As String

    Public Property _apellido As String

    Public Property _telefono As String

    Public Property _direccion As String

    Public Property _proporcion_comision As Double
        Get
            Return comision
        End Get
        Set(value As Double)
            If value < 0 Then
                Throw New System.Exception("Un vendedor no puede tener una comision negativa.")
            Else
                comision = value
            End If
        End Set
    End Property

    Public Property _porcentaje_comision As String ' String de la mascara 990%
        Get
            Return _proporcion_comision * 100 & "%"
        End Get
        Set(value As String)
            value = value.Replace("%", "")
            _proporcion_comision = value / 100
        End Set
    End Property

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return _apellido & ", " & _nombre
    End Function

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("id", _id)
        diccionario.Add("nombre", _nombre)
        diccionario.Add("apellido", _apellido)
        diccionario.Add("telefono", _telefono)
        diccionario.Add("direccion", _direccion)
        diccionario.Add("proporcion_comision", _proporcion_comision)
        diccionario.Add("porcentaje_comision", _porcentaje_comision)
        Return diccionario
    End Function
End Class
