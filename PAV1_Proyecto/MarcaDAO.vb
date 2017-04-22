Public Class MarcaDAO
    ' DOC: Esta clase se encarga de las consultas SQL a la tabla de Marcas.
    '      Como parametros de entrada/salida trabaja con MarcaVO.

    Public Shared Function all() As ArrayList
        Dim marcas As ArrayList = New ArrayList
        ' TODO: Hace un SELECT de la tabla entera y devuelve un conjunto de elementos.
        Return marcas
    End Function

    Public Shared Sub insert(ByRef marca As MarcaVO)
        Dim sql_insertar As String
        sql_insertar = "INSERT INTO marcas (nombre)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & marca.get_nombre() & "')"
        DataBase.getInstance().ejecuta_sql(sql_insertar)
    End Sub

    Public Shared Sub update(ByRef marca As MarcaVO)
        ' TODO: Update a marca en la BD.
    End Sub

    Public Shared Sub save(ByRef marca As MarcaVO)
        If marca.has_id() Then
            MarcaDAO.update(marca)
        Else
            MarcaDAO.insert(marca)
        End If
    End Sub

    Public Shared Sub delete(ByRef marca As MarcaVO)
        ' TODO: Validar que tenga un ID (esta en la BD) y eliminar la marca.
    End Sub






End Class
