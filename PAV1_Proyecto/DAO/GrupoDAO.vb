Imports PAV1_Proyecto

Public Class GrupoDAO
    Implements ObjetoDAO

    ' DOC: (MarcaDataAccessObject) Esta clase se encarga de las consultas SQL a la tabla de Grupos.
    '      Como parametros de entrada/salida generalmente trabaja con GrupoVO.

    Public Shared Function all() As DataTable
        Dim sql_select = ""
        sql_select &= "SELECT idGrupo as id, grupos.nombre, familias.nombre as nombre_familia, familias.idFamilia as id_familia"
        sql_select &= " FROM grupos"
        sql_select &= " INNER JOIN FAMILIAS ON grupos.idFamilia=familias.idFamilia"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Shared Sub insert(ByRef grupo As GrupoVO)
        ' DOC: Inserta el grupo en la BD y actualiza el objeto asignandole su ID.

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO grupos (nombre, idFamilia)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & grupo._nombre & "', " & grupo._familia._id & ")"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
        grupo._id = tabla(0)(0)
    End Sub

    Public Shared Sub update(ByRef grupo As GrupoVO)
        ' DOC: Actualiza el grupo en la BD

        ' TODO BUG: Falla si estamos cambiando el nombre 
        '           y poniendo uno que ya existe para esta familia.
        Dim sql_update As String
        sql_update = "UPDATE grupos"
        sql_update &= " SET "
        sql_update &= "nombre='" & grupo._nombre & "', idFamilia=" & grupo._familia._id
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
        If grupo._id > 0 Then
            Dim sql = "SELECT TOP 1 idGrupo FROM grupos WHERE idGrupo=" & grupo._id
            Dim response = DataBase.getInstance().consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Private Function cast(value As ObjetoVO) As GrupoVO
        If TypeOf value Is GrupoVO Then
            Return value
        Else
            Throw New System.Exception("Error: GrupoDAO solo admite objetos GrupoVO")
        End If
    End Function

    Public Shared Function is_name_in_use(ByRef grupo As GrupoVO) As Boolean
        ' DOC: determina si existe el nombre de un grupo en la BD

        Dim sql = "SELECT TOP 1 nombre FROM grupos WHERE nombre='" & grupo._nombre & "'"
        sql &= " AND idFamilia=" & grupo._familia._id
        Dim response = DataBase.getInstance().consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Public Function search_by_id(grupo_id As Integer, Optional db As DataBase = Nothing) As ObjetoVO
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If

        Dim sql = "SELECT g.nombre as nombre_grupo, g.idFamilia, f.nombre as nombre_familia FROM grupos g "
        sql &= " JOIN familias f ON g.idFamilia = f.idFamilia"
        sql &= " WHERE idGrupo=" & grupo_id
        Dim registro = db.consulta_sql(sql)

        Dim grupo As GrupoVO = Nothing
        If registro.Rows.Count = 1 Then
            grupo = New GrupoVO With {
                ._id = grupo_id,
                ._nombre = registro(0)("nombre_grupo"),
                ._familia = New FamiliaVO With {
                    ._id = registro(0)("idFamilia"),
                    ._nombre = registro(0)("nombre_familia")
                }
            }
        End If

        Return grupo
    End Function

    Private Function ObjetoDAO_all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        Dim lista As New List(Of ObjetoVO)
        For Each row In all().Rows()
            lista.Add(New GrupoVO With {
                      ._id = row("id"),
                      ._nombre = row("nombre"),
                      ._familia = New FamiliaVO With {
                          ._id = row("id_familia"),
                          ._nombre = row("nombre_familia")}
                      })
        Next
        Return lista
    End Function

    Public Sub insert(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.insert
        insert(cast(value))
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        update(cast(value))
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        delete(cast(value))
    End Sub

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        Return exists(cast(value))
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Throw New NotImplementedException()
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Throw New NotImplementedException()
    End Function

    'Public Function comboSource() As DataTable Implements ComboDataSource.comboSource
    '    Dim tabla As New DataTable
    '    tabla.Columns.Add("grupo")
    '    tabla.Columns.Add("nombre_grupo")

    '    Dim tipo_cliente As TipoClienteVO
    '    For Each valor In all().Rows
    '        tipo_cliente = New TipoClienteVO With {
    '            ._id = valor("id"),
    '            ._nombre = valor("nombre"),
    '            ._descripcion = valor("descripcion")}

    '        Dim row = tabla.Rows.Add()
    '        row(0) = tipo_cliente
    '        row(1) = tipo_cliente._nombre
    '    Next
    '    Return tabla
    'End Function
End Class
