Public Interface Validable
    '
    ' Interfaz para definir controles validables. Solo se valida entrada del usuario.
    ' No se hacen validaciones que impacten la base de datos (de negocio).
    '

    ' Cosas validables.
    Property _required As Boolean
    Property _min_lenght As Integer
    Property _max_lenght As Integer
    Property _numeric As Boolean

    Function is_valid() As Boolean

End Interface
