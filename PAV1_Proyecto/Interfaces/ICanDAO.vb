Public Interface ICanDAO
    '
    ' Verifica para insercion en base de datos:
    '   - PK existente o nula
    '   - Campo no nulo con valor nulo
    '   - Campo FK que no apunta a un objeto valido
    '   - Valor fuera del dominio del campo
    '   - Campo UNIQUE con valor duplicado
    ' Returns ErrMsg as String o Valid as Nothing
    '
    Function can_insert(value As ObjetoVO) As String

    '
    ' Verifica para modificacion en base de datos:
    '   - PK existente o nula
    '   - Campo no nulo con valor nulo
    '   - Campo FK que no apunta a un objeto valido
    '   - Valor fuera del dominio del campo
    '   - Campo UNIQUE con valor duplicado
    '   - Detectar cambio de PK (es inexistente) 
    ' Returns ErrMsg as String o Valid as Nothing
    '
    Function can_update(value As ObjetoVO) As String

    '
    ' Verifica para modificacion en base de datos:
    '   - El objeto a borrar tiene hijos.
    ' Returns ErrMsg as String o Valid as Nothing
    '
    Function can_delete(value As ObjetoVO) As String
End Interface
