Public Class TipoClienteControl
    Dim tipoCliente = New TipoClienteVO()

    Public Property _TipoClienteVO As TipoClienteVO
        ' El ID Nunca cambia.
        Get
            tipoCliente._nombre = txt_nombre.Text.Trim
            tipoCliente._descripcion = txt_descripcion.Text.Trim
            Return tipoCliente
        End Get
        Set(value As TipoClienteVO)
            tipoCliente = value
            txt_nombre.Text = value._nombre
            txt_descripcion.Text = value._descripcion
        End Set
    End Property

    Public Function is_valid() As Boolean
        ' TODO: Hacer validacion. (Longitudes, Not Null)
        Return True
    End Function
End Class
