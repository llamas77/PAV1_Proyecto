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
            vendedor._nombre = txt_nombre.Text.Trim
            vendedor._apellido = txt_apellido.Text.Trim
            vendedor._direccion = txt_direccion.Text.Trim
            vendedor._telefono = txt_telefono.Text.Trim
            vendedor._porcentaje = txt_comision.Text.Trim
            Return vendedor
        End Get
        Set(value As VendedorVO)
            vendedor = value
            txt_nombre.Text = vendedor._nombre
            txt_apellido.Text = vendedor._apellido
            txt_direccion.Text = vendedor._direccion
            txt_telefono.Text = vendedor._telefono
            txt_comision.Text = vendedor._porcentaje
        End Set
    End Property

    Public Sub reset() Implements ObjetoCtrl.reset
        _vendedor = New VendedorVO()
    End Sub

    Public Function is_valid() As Boolean Implements ObjetoCtrl.is_valid
        Return True ' TODO: Validar. Campos opcionales y obligatorios.
    End Function
End Class
