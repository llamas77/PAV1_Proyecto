Public Interface ComboDataSource

    '
    ' Esta funcion debe retornar un DataTable con solo 2 columnas. 
    ' La primer columna seran los value y la segunda los display.
    '
    Function comboSource() As DataTable


End Interface
