Public Interface ObjetoVO
    '
    ' Los objetos que implementan esta interfaz son aquellos que solo guardan
    ' valores y tienen muy escaso o nulo comportamiento por fuera de los get y set.
    '

    '
    ' Retorna una cadena que representa al objeto. Generalmente comienza con el
    ' tipo de objeto (ej. Vendedor)
    '
    Function toString() As String

    '
    ' Guarda todos sus valores en forma de diccionario y lo retorna.
    ' Actualmente se utiliza para cargar un ControlGenerico.
    '
    Function toDictionary() As Dictionary(Of String, Object)

    ' Proximamente:
    ' Function fromDictionary() As Dictionary(Of String, Object)

End Interface
