Public Interface ObjetoDAO
    '
    ' El objeto que implemente esta interfaz es capaz de mantener ciertos objetosVO
    ' persistentes a lo largo del tiempo. Se encarga de guardar, recuperar y borrar
    ' algun tipo ObjetoVO o varios.

    '
    ' Retorna un DataTable con todos los ObjetosVO de la base de datos de forma completa.
    ' Generalmente lo usamos para cargar una grilla con todos los objetos.
    '
    Function all() As DataTable

    '
    ' Almacena el objeto.
    '
    Sub insert(value As ObjetoVO)

    '
    ' Almacena un objeto modificado. (Guarda la modificación).
    '
    Sub update(value As ObjetoVO)

    '
    ' Borra un objeto del almacenamiento.
    '
    Sub delete(value As ObjetoVO)

    '
    ' Valida si el objeto está almacenado.
    '
    Function exists(value As ObjetoVO) As Boolean

    ' -- Nota: Las funciones anteriores trabajan con la interfaz ObjetoVO, pero el objeto que
    ' --       implemente esta interfaz generalmente trabajara con un tipo de ObjetoVO (ej. VendedorVO)
    ' --       no cualquiera, entonces lo primero que hace es validar que sea de ese tipo.

    '
    ' Retorna un control de objeto listo para mostrar en pantalla.
    ' Nota: En la implementacion se puede inicializar un ControlGenerico o hacer
    '       new a un control diseñado manualmente.
    '
    Function get_IU_control() As ObjetoCtrl

    '
    ' Retorna una grilla de objeto lista para mostrar en pantalla.
    ' Nota: En la implementacion se puede inicializar una GrillaGenerica o hacer
    '       new a una grilla diseñada manualmente.
    '
    Function get_IU_grilla() As ObjetoGrilla

End Interface
