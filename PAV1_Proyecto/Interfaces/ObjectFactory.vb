Public Interface ObjectFactory
    '
    ' Los objetos que implementen esta interfaz deben ser capaces de crear nuevos
    ' objetos del tipo ObjetoVO.
    '

    '
    ' Params: valores -> Un diccionario (tiene pares clave:valor) que contiene datos
    '         para la creacion del objeto.
    ' Returns: ObjetoVO. Una instancia de ObjetoVO (ej. VendedorVO)
    '
    Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO

End Interface
