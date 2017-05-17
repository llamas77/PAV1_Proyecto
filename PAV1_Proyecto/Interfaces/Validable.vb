Public Interface Validable
    '
    ' Los objetos que implementen esta interfaz son capaces de validar su contenido
    ' según ciertas reglas.
    ' La interfaz solo valida la entrada del usuario, no hace validaciones 
    ' que impacten la base de datos (de negocio).
    '

    ' -- Reglas de validacion --
    Property _required As Boolean ' Si es True: el contenido no puede ser Nothing ni ""
    Property _min_lenght As Integer ' Es la longitud mínima del contenido.
    Property _max_lenght As Integer ' Es la longitud máxima del contenido.
    Property _numeric As Boolean ' Si es True: el contenido debe ser un numero o un string numerico ("1")

    '
    ' Ejecuta la validacion con los valores actuales y retorna su resultado.
    '
    Function is_valid() As Boolean

End Interface
