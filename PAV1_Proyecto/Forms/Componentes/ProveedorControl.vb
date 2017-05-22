Imports PAV1_Proyecto

Public Class ProveedorControl
    Implements ObjetoCtrl

    Dim proveedor As New ProveedorVO

    Public Property _objeto As ObjetoVO Implements ObjetoCtrl._objeto
        Get
            Return _proveedor
        End Get
        Set(value As ObjetoVO)
            If TypeOf value Is ProveedorVO Then
                _proveedor = value
            Else
                Throw New Exception("ProveedorControl solo acepta objetos ProveedorVO")
            End If
        End Set
    End Property

    Public Property _proveedor As ProveedorVO
        Get
            proveedor._razonSocial = txt_razonSocial._text.Trim
            proveedor._cuit = txt_cuit._text.Trim
            proveedor._domicilio = txt_domicilio._text.Trim
            proveedor._telefono = txt_telefono._text.Trim
            proveedor._email = txt_email._text.Trim
            Return proveedor
        End Get
        Set(value As ProveedorVO)
            proveedor = value
            txt_razonSocial._text = proveedor._razonSocial
            txt_cuit._text = proveedor._cuit
            txt_domicilio._text = proveedor._domicilio
            txt_telefono._text = proveedor._telefono
            txt_email._text = proveedor._email
        End Set
    End Property
    Public Sub reset() Implements ObjetoCtrl.reset
        _proveedor = New ProveedorVO()
    End Sub


    Public Function sql_leerTabla(ByVal nombreTabla As String) As DataTable
        Dim sql_select = "SELECT * FROM " & nombreTabla
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Function is_valid() As Boolean Implements ObjetoCtrl.is_valid
        If txt_razonSocial.Text = "" Or txt_cuit.Text = "" Then
            Return False
        End If
        Return True
    End Function

    Public Overloads Sub Focus() Implements ObjetoCtrl.Focus
        MyBase.Focus()
    End Sub
End Class
