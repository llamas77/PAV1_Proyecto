Imports PAV1_Proyecto

Public Class VendedorVO
    Implements ObjetoVO

    Dim comision As Double

    Public Property _id As Integer

    Public Property _nombre As String

    Public Property _apellido As String

    Public Property _telefono As String

    Public Property _direccion As String

    Public Property _comision As Double
        Get
            Return comision
        End Get
        Set(value As Double)
            If value < 0 Or value > 1 Then
                comision = 0
            Else
                comision = value
            End If
        End Set
    End Property

    Public Property _porcentaje As String ' String de la mascara 990%
        Get
            Return _comision & "%"
        End Get
        Set(value As String)
            value = value.Replace("%", "")
            value = value.Replace("_", "")
            _comision = value / 100
        End Set
    End Property

    Public Sub New(id, nombre, apellido, telefono, direccion, comision)
        _id = id
        _nombre = nombre
        _apellido = apellido
        _telefono = telefono
        _direccion = direccion
        If TypeOf comision Is Double Then
            Me.comision = comision
        Else
            _porcentaje = comision
        End If
    End Sub

    Public Sub New()
        Me.New(0, "", "", "", "", 0.0)
    End Sub

    '
    ' Interfaz ObjetoVO
    '
    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return _apellido & ", " & _nombre
    End Function
End Class
