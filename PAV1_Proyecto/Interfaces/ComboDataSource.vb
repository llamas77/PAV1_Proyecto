Public Interface ComboDataSource
    '
    ' Los objetos que implementen la interfaz son aquellos que pueden ser utilizados en 
    ' un ComboBox.
    '

    '
    ' Retorna: DataTable de 2 columnas con el que se cargara un ComboBox.
    ' La primer columna seran los value y la segunda los display.
    '
    Function comboSource() As DataTable

    ' Ignorar por ahora.
    'Function get_object_from_combo(value As Object, display As String) As ObjetoVO

End Interface
