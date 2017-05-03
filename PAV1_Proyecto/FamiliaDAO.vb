Public Class FamiliaDAO

    Public Shared Function all() As DataTable
        Dim sql_select = "SELECT idFamilia, nombre FROM familias"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Shared Sub insert(ByRef familia As FamiliaVO)
        ' DOC: Inserta la marca en la BD y actualiza el objeto asignandole su ID.

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO familias (nombre)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & familia.get_nombre() & "')"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
        familia.set_id(tabla(0)(0))
    End Sub

    Public Shared Sub update(ByRef familia As FamiliaVO)
        ' DOC: Actualiza la marca en la BD

        Dim sql_update As String
        sql_update = "UPDATE familias"
        sql_update &= " SET "
        sql_update &= "nombre='" & familia.get_nombre() & "'"
        sql_update &= " WHERE idFamilia=" & familia.get_id()
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Shared Sub delete(ByRef familia As FamiliaVO)
        ' DOC: Elimina la marca de la BD

        Dim sql_delete = "DELETE FROM familias" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idFamilia=" & familia.get_id()
        DataBase.getInstance().ejecuta_sql(sql_delete)
        familia.set_id(0)
    End Sub

    Shared Function exists(ByRef familia As FamiliaVO) As Boolean
        ' DOC: determina si existe la marca en la BD, según PK

        ' TODO: Validar que el ID es >= 1, sino no existe (no hace falta consulta en bd si no existe)
        Dim sql = "SELECT TOP 1 idFamilia FROM familias WHERE idFamilia=" & familia.get_id()
        Dim response = DataBase.getInstance().consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Public Shared Function is_name_in_use(ByRef familia As FamiliaVO) As Boolean
        ' DOC: determina si existe el nombre de la marca en la BD

        Dim sql = "SELECT TOP 1 nombre FROM familias WHERE nombre='" & familia.get_nombre() & "'"
        Dim response = DataBase.getInstance().consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

End Class
