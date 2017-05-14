Public Interface ObjetoVO

    '
    ' toString() debe estar definido para poder mostrar el objeto en mensajes al usuario.
    '
    Function toString() As String

    '
    ' toDictionary() se usa para que el control generico pueda cargar el objeto.
    '
    Function toDictionary() As Dictionary(Of String, Object)

End Interface
