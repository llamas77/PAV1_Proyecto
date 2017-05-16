Public Interface ObjetoCtrl
    '
    ' Los objetos que implementen la interfaz deben poder ser mostrados dentro de
    ' un form y permitir que el usuario modifique los atributos de un ObjetoVO.
    '

    '
    ' Get: Retorna un ObjetoVO a partir de los datos que ingreso el usuario.
    '      En el caso del control generico, utiliza la fabrica (ObjectFactory) para
    '      generarlo.
    ' Set: Visualiza un ObjetoVO. Generalmente carga sus valores en los TextBox 
    '      correspondientes.
    Property _objeto As ObjetoVO

    '
    ' Valida que el objeto que devuelve es una instancia válida según el criterio del
    ' objeto. El control generico delega esta tarea a cada LabeledTextBox configurado
    ' con este proposito.
    '
    Function is_valid() As Boolean

    '
    ' Limpia todo lo que haya ingresado el usuario y lo prepara para la inserción de 
    ' un nuevo elemento.
    '
    Sub reset()


    ' Función generalmente heredada de UserControl para poner el foco sobre el control.
    Sub Focus()
End Interface
