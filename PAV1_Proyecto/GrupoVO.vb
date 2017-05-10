Public Class GrupoVO
    Dim id As Integer
    Dim nombre As String
    Dim familia As FamiliaVO

    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByRef familia As FamiliaVO)
        If id > 0 Then ' Valida que el ID sea >= 0 sino lo pone en 0
            Me.id = id
        Else
            Me.id = 0
        End If
        Me.familia = familia
        Me.nombre = nombre.Trim 'TODO: Validar String de longitud < 50 (segun BD)
    End Sub

    Public Sub New(ByVal nombre As String, ByRef familia As FamiliaVO)
        Me.New(0, nombre, familia)
    End Sub

    Public Property _id As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property

    Public Property _nombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property _familia As FamiliaVO
        Get
            Return familia
        End Get
        Set(value As FamiliaVO)
            familia = value
        End Set
    End Property
End Class
