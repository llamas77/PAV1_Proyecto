Imports PAV1_Proyecto

Public Class GrupoDAO
    Implements ComboDataSource

    ' DOC: (MarcaDataAccessObject) Esta clase se encarga de las consultas SQL a la tabla de Grupos.
    '      Como parametros de entrada/salida generalmente trabaja con GrupoVO.

    Public Shared Function all() As DataTable
        Dim sql_select = ""
        sql_select &= "SELECT idGrupo, grupos.nombre, familias.nombre as nombreFamilia, familias.idFamilia FROM GRUPOS "
        sql_select &= "INNER JOIN FAMILIAS ON grupos.idFamilia=familias.idFamilia"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Shared Sub insert(ByRef grupo As GrupoVO)
        ' DOC: Inserta el grupo en la BD y actualiza el objeto asignandole su ID.

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO grupos (nombre, idFamilia)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & grupo._nombre & "', " & grupo._familia.get_id() & ")"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
        grupo._id = tabla(0)(0)
    End Sub

    Public Shared Sub update(ByRef grupo As GrupoVO)
        ' DOC: Actualiza el grupo en la BD

        Dim sql_update As String
        sql_update = "UPDATE grupos"
        sql_update &= " SET "
        sql_update &= "nombre='" & grupo._nombre & "', idFamilia=" & grupo._familia.get_id()
        sql_update &= " WHERE idGrupo=" & grupo._id
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Shared Sub delete(ByRef grupo As GrupoVO)
        ' DOC: Elimina la marca de la BD

        Dim sql_delete = "DELETE FROM grupos" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idGrupo=" & grupo._id
        DataBase.getInstance().ejecuta_sql(sql_delete)
        grupo._id = 0
    End Sub

    Shared Function exists(ByRef grupo As GrupoVO) As Boolean
        ' DOC: determina si existe el grupo en la BD, según PK

        ' TODO: Validar que el ID es >= 1, sino no existe (no hace falta consulta en bd si no existe)
        Dim sql = "SELECT TOP 1 idGrupo FROM grupos WHERE idGrupo=" & grupo._id
        Dim response = DataBase.getInstance().consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Public Shared Function is_name_in_use(ByRef grupo As GrupoVO) As Boolean
        ' DOC: determina si existe el nombre de un grupo en la BD

        Dim sql = "SELECT TOP 1 nombre FROM grupos WHERE nombre='" & grupo._nombre & "'"
        Dim response = DataBase.getInstance().consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Public Function comboSource() As DataTable Implements ComboDataSource.comboSource
        Dim sql_select = "SELECT idGrupo, nombre FROM GRUPOS "
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function
End Class
