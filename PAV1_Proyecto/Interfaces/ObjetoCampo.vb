Public Interface ObjetoCampo
    ' Debe heredar de UserControl para poder ubicarlo en pantalla.

    '
    '   Identificador del campo.
    '
    Property _id As String

    '
    '   Texto mostrado al usuario.
    '
    Property _label As String

    '
    '   Valor del campo.
    '
    Property _value As Object

End Interface
