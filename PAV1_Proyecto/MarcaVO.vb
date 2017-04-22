Public Class MarcaVO
    ' DOC: MarcaVO (MarcaValueObject) solo tiene atributos, getters y setters.
    '      Representa una fila de la tabla Marcas. Se la utiliza para ahorrar parametros (un objeto
    '      en lugar de los atributos) y facilitar la modificacion del sistema.

    Private id As Integer
    Dim nombre As String

    Public Sub New(ByVal id As Integer, ByVal nombre As String)
        ' TODO: Validar ID > 0
        Me.id = id
        Me.nombre = nombre
    End Sub

    Public Sub New(ByVal nombre As String)
        Me.id = 0
        Me.nombre = nombre
    End Sub

    Public Sub set_id(ByVal new_id As Integer)
        If (new_id > 0 And Me.id = 0) Or (new_id = 0 And Me.id > 0) Then
            Me.id = new_id
        End If

    End Sub

    Public Function get_id() As Integer
        Return Me.id
    End Function

    Public Function has_id() As Boolean
        ' Si el ID es 0 no esta en la BD.
        Return IIf(Me.id = 0, True, False)

    End Function

    Public Sub set_nombre(ByVal new_nombre As String)
        Me.nombre = new_nombre
    End Sub

    Public Function get_nombre() As String
        Return Me.nombre
    End Function


End Class
