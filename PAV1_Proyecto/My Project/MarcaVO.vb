Public Class MarcaVO
    Private id As Integer = 0
    Dim nombre As String

    Public Sub set_id(ByVal new_id As Integer)
        If (new_id > 0 And Me.id = 0) Or (new_id = 0 And Me.id > 0) Then
            Me.id = new_id
        End If

    End Sub

    Public Function get_id() As Integer
        Return Me.id
    End Function

    Public Function has_id() As Boolean
        ' Si el ID es 0 consideramos que no existe.
        Return IIf(Me.id = 0, True, False)

    End Function

    Public Sub set_nombre(ByVal new_nombre As String)
        Me.nombre = new_nombre
    End Sub

    Public Function get_nombre() As String
        Return Me.nombre
    End Function


End Class
