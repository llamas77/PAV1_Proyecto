﻿Public Interface ObjetoGrilla
    '
    ' Todo objeto que implemente la interfaz debe ser capaz de mostrar una lista
    ' de objetos al usuario y permitirle seleccionar uno.
    '

    '
    ' Limpia la pantalla (si esta mostrando objetos) y pasa a mostrar el listado
    ' pasado como parametro.
    '
    Sub recargar(value As List(Of ObjetoVO))

    '
    ' Retorna el ObjetoVO seleccionado por el usuario, o Nothing si no hay seleccion.
    ' Nota: La grilla generica utiliza un ObjectFactory para crear los objetos
    '       y retornarlos.
    '
    Function get_selected() As ObjetoVO

    '
    ' Retorna todos los objetos de la tabla convertidos.
    '
    Function get_all() As List(Of ObjetoVO)

    '
    ' Añade una fila más
    '
    Sub add_objeto(value As ObjetoVO)

    '
    ' Borra la fila seleccionada
    '
    Sub delete_selected()

    ' Función generalmente heredada de UserControl para poner el foco sobre el control.
    Sub Focus()
End Interface
