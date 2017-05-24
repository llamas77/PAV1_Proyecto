﻿Public Class TipoClienteControl
    Inherits UserControl
    Implements ObjetoCtrl

    Dim tipoCliente = New TipoClienteVO()

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me._TipoClienteVO = New TipoClienteVO
    End Sub

    Public Property _objeto As ObjetoVO Implements ObjetoCtrl._objeto
        Get
            Return Me._TipoClienteVO
        End Get
        Set(value As ObjetoVO)
            If TypeOf value Is TipoClienteVO Then
                Me._TipoClienteVO = value
            Else
                Throw New System.Exception("Error: TipoClienteControl solo admite objetos TipoClienteVO")
            End If
        End Set
    End Property

    Public Property _TipoClienteVO As TipoClienteVO
        ' El ID Nunca cambia.
        Get
            tipoCliente._nombre = txt_nombre._value.Trim
            tipoCliente._descripcion = txt_descripcion._value.Trim
            Return tipoCliente
        End Get
        Set(value As TipoClienteVO)
            tipoCliente = value
            txt_nombre._value = value._nombre
            txt_descripcion._value = value._descripcion
        End Set
    End Property

    Public Function is_valid() As Boolean Implements ObjetoCtrl.is_valid
        ' TODO: Hacer validacion. (Longitudes, Not Null)
        Return True
    End Function

    Public Sub reset() Implements ObjetoCtrl.reset
        Me._TipoClienteVO = New TipoClienteVO()
    End Sub

    Public Overloads Sub Focus() Implements ObjetoCtrl.Focus
        MyBase.Focus()
    End Sub
End Class
