Public Class MarcaDAO
    ' DOC: (MarcaDataAccessObject) Esta clase se encarga de las consultas SQL a la tabla de Marcas.
    '      Como parametros de entrada/salida generalmente trabaja con MarcaVO.

    Public Shared Function all() As DataTable
        Dim sql_select = "SELECT idMarca, nombre FROM marcas"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Shared Sub insert(ByRef marca As MarcaVO)
        ' DOC: Inserta la marca en la BD y actualiza el objeto asignandole su ID.

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO marcas (nombre)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & marca.get_nombre() & "')"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
        'FRANCO: lo de abajo es redundante creo, xq el objeto marca se pierde.
        'JUANI: Pero si el frm no lo perdiera deberia tenerlo con su correcto ID, 
        '       calculo que cuando lleguemos a transacciones lo vamos a necesitar.
        marca.set_id(tabla(0)(0))
    End Sub

    Public Shared Sub update(ByRef marca As MarcaVO)
        ' DOC: Actualiza la marca en la BD

        Dim sql_update As String
        sql_update = "UPDATE marcas"
        sql_update &= " SET "
        sql_update &= "nombre='" & marca.get_nombre() & "'"
        sql_update &= " WHERE idMarca=" & marca.get_id()
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Shared Sub delete(ByRef marca As MarcaVO)
        ' DOC: Elimina la marca de la BD

        Dim sql_delete = "DELETE FROM marcas" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idMarca=" & marca.get_id()
        DataBase.getInstance().ejecuta_sql(sql_delete)
        marca.set_id(0)
    End Sub

    Shared Function exists(ByRef marca As MarcaVO) As Boolean
        ' DOC: determina si existe la marca en la BD, según PK

        ' TODO: Validar que el ID es >= 1, sino no existe (no hace falta consulta en bd si no existe)
        Dim sql = "SELECT TOP 1 idMarca FROM marcas WHERE idMarca=" & marca.get_id()
        Dim response = DataBase.getInstance().consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Public Shared Function is_name_in_use(ByRef marca As MarcaVO) As Boolean
        ' DOC: determina si existe el nombre de la marca en la BD

        Dim sql = "SELECT TOP 1 nombre FROM marcas WHERE nombre='" & marca.get_nombre() & "'"
        Dim response = DataBase.getInstance().consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function


End Class
