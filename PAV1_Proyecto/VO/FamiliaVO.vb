Public Class FamiliaVO
    ' DOC: FamiliaVO (FamilliaValueObject) solo tiene propiedades.
    '      Representa una fila de la tabla Familia. Se la utiliza para ahorrar parametros (un objeto
    '      en lugar de los atributos) y facilitar la modificacion del sistema.

    Public Property _id As Integer
    Public Property _nombre As String

    Public Sub New()
        ' Para usar con With al crear el objeto.
    End Sub

    <Obsolete>
    Public Sub New(ByVal id As Integer, ByVal nombre As String)
        If id > 0 Then ' Valida que el ID sea >= 0 sino lo pone en 0
            Me._id = id
        Else
            Me._id = 0
        End If
        Me._nombre = nombre.Trim 'TODO: Validar String de longitud < 50 (segun BD)
    End Sub

End Class
