Imports PAV1_Proyecto

Public Class VendedoresControl
    Implements ObjetoCtrl

    Dim vendedor As New VendedorVO

    Public Property _objeto As ObjetoVO Implements ObjetoCtrl._objeto
        Get
            Return _vendedor
        End Get
        Set(value As ObjetoVO)
            If TypeOf value Is VendedorVO Then
                _vendedor = value
            Else
                Throw New Exception("VendedoresControl solo acepta objetos VendedorVO")
            End If
        End Set
    End Property

    Public Property _vendedor As VendedorVO
        Get
            vendedor._nombre = txt_nombre._text.Trim
            vendedor._apellido = txt_apellido._text.Trim
            vendedor._direccion = txt_direccion._text.Trim
            vendedor._telefono = txt_telefono._text.Trim
            vendedor._porcentaje = txt_comision._text.Trim
            Return vendedor
        End Get
        Set(value As VendedorVO)
            vendedor = value
            txt_nombre._text = vendedor._nombre
            txt_apellido._text = vendedor._apellido
            txt_direccion._text = vendedor._direccion
            txt_telefono._text = vendedor._telefono
            txt_comision._text = vendedor._porcentaje
        End Set
    End Property

    Public Sub reset() Implements ObjetoCtrl.reset
        _vendedor = New VendedorVO()
    End Sub

    Public Function is_valid() As Boolean Implements ObjetoCtrl.is_valid
        Return True ' TODO: Validar. Campos opcionales y obligatorios.
    End Function

    Public Overloads Sub Focus() Implements ObjetoCtrl.Focus
        MyBase.Focus()
    End Sub
End Class
