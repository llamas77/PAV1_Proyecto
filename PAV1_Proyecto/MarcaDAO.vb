Public Class MarcaDAO
    ' DOC: Esta clase se encarga de las consultas SQL a la tabla de Marcas.
    '      Como parametros de entrada/salida trabaja con MarcaVO.

    Public Shared Sub all(ByRef tabla As DataTable)
        Dim marcas As ArrayList = New ArrayList
        Dim sql_select = "SELECT idMarca as id, nombre FROM marcas"
        tabla = DataBase.getInstance().consulta_sql(sql_select)
    End Sub

    Public Shared Sub all(ByRef marcas As ArrayList)
        ' TODO OPTIONAL: Implementar el metodo si alguna vez hace falta.
        ' DOC: Inserta en el array las MarcaVO en lugar de una tabla.

    End Sub

    Public Shared Sub insert(ByRef marca As MarcaVO)
        Dim sql_insertar As String
        sql_insertar = "INSERT INTO marcas (nombre)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & marca.get_nombre() & "')"
        DataBase.getInstance().ejecuta_sql(sql_insertar)
    End Sub

    Public Shared Sub update(ByRef marca As MarcaVO)
        ' TODO: Update a marca en la BD.
        Dim sql_update As String
        sql_update = "UPDATE marcas"
        sql_update &= " SET "
        sql_update &= "nombre='" & marca.get_nombre() & "'"
        sql_update &= " WHERE idMarca=" & marca.get_id()
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Shared Sub save(ByRef marca As MarcaVO)
        ' DOC: Si la marca existe actualiza, sino inserta.
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
