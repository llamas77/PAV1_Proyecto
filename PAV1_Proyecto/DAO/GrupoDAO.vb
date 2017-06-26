Imports PAV1_Proyecto

Public Class GrupoDAO
    Implements ObjetoDAO, ObjectFactory, ICanDAO


    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim sql_select = ""
        sql_select &= "SELECT g.idGrupo as id, g.nombre as nombre, g.idFamilia as id_familia, f.nombre as nombre_familia "
        sql_select &= " FROM grupos g"
        sql_select &= " INNER JOIN familias f ON g.idFamilia=f.idFamilia"

        Return dataTable_to_List(db.consulta_sql(sql_select))
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"id", "nombre", "nombre_familia", "id_familia"}
        Dim diccionario As New Dictionary(Of String, Object)
        For Each param In params
            diccionario.Add(param, Nothing)
        Next

        For Each row In tabla.Rows
            For Each param In params
                diccionario(param) = row(param)
            Next
            lista.Add(new_instance(diccionario))
        Next
        Return lista
    End Function

    Public Sub insert(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.insert
        ' DOC: Inserta la marca en la BD y actualiza el objeto asignandole su ID.

        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim grupo = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO grupos (nombre, idFamilia)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & grupo._nombre & "', " & grupo._familia._id & ")"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = db.consulta_sql(sql_insertar)
        grupo._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        ' DOC: Actualiza la marca en la BD
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim grupo = cast(value)

        Dim sql_update As String
        sql_update = "UPDATE grupos"
        sql_update &= " SET "
        sql_update &= "nombre='" & grupo._nombre & "', idFamilia=" & grupo._familia._id
        sql_update &= " WHERE idGrupo=" & grupo._id
        db.ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        ' DOC: Elimina la marca de la BD
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim grupo = cast(value)

        Dim sql_delete = "DELETE FROM grupos" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idGrupo=" & grupo._id
        db.ejecuta_sql(sql_delete)
        grupo._id = 0
        ' Nota: Las ganancias asociadas se borran en cascada.
    End Sub

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        ' DOC: determina si existe la marca en la BD, según PK
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim grupo = cast(value)

        If grupo._id > 0 Then
            Dim sql = "SELECT TOP 1 idGrupo FROM grupos WHERE idGrupo=" & grupo._id
            Dim response = DataBase.getInstance().consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return is_name_in_use(value)
        End If

    End Function

    Private Function cast(value As ObjetoVO) As GrupoVO
        If TypeOf value Is GrupoVO Then
            Return value
        Else
            Throw New System.Exception("Error: GrupoDAO solo admite objetos GrupoVO")
        End If
    End Function

    Public Function is_name_in_use(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean
        ' DOC: determina si existe el nombre de la marca en la BD
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim grupo = cast(value)

        Dim sql = "SELECT TOP 1 nombre FROM grupos WHERE nombre='" & grupo._nombre & "'"
        sql &= " AND idFamilia=" & grupo._familia._id
        Dim response = db.consulta_sql(sql)
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

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "nombre", ._name = "Nombre", ._required = True})
        campos.Add(New Campo With {._id = "familia", ._name = "Familia", ._maskType = Campo.MaskType.comboBox,
                                   ._objetoDAO = New FamiliaDAO, ._required = True})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "ID"})
        campos.Add(New Campo With {._id = "nombre", ._name = "Nombre"})
        campos.Add(New Campo With {._id = "familia", ._name = "Familia"})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Dim grupo = New GrupoVO With {
            ._id = valores("id"),
            ._nombre = valores("nombre")
            }

        If valores.ContainsKey("familia") Then
            grupo._familia = valores("familia")
        Else
            grupo._familia = New FamiliaVO With {
                ._id = valores("id_familia"),
                ._nombre = valores("nombre_familia")
            }
        End If

        Return grupo
    End Function

    Public Function can_insert(value As ObjetoVO) As String Implements ICanDAO.can_insert
        Dim grupo = cast(value)
        If Len(grupo._nombre) > 50 Then
            Return "El nombre del grupo es demasiado largo. (Máx. 50 caracteres)"
        End If
        If grupo._id <> 0 Then
            Return "Esta tratando de insertar un grupo ya almacenado. [id=" & grupo._id & "]"
        End If
        With New FamiliaDAO
            If Not .exists(grupo._familia) Then
                Return "La familia indicada no existe."
            End If
        End With
        Return IIf(is_name_in_use(value), "Ya existe un grupo con ese nombre para esa familia.", Nothing)
    End Function

    Public Function can_update(value As ObjetoVO) As String Implements ICanDAO.can_update
        Dim grupo = cast(value)
        If Len(grupo._nombre) > 50 Then
            Return "El nombre del grupo es demasiado largo. (Máx. 50 caracteres)"
        End If
        If grupo._id = 0 Then
            Return "Esta tratando de modificar un grupo no almacenado."
        End If
        With New FamiliaDAO
            If Not .exists(grupo._familia) Then
                Return "La familia indicada no existe."
            End If
        End With
        Return IIf(is_name_in_use(grupo), "Ya existe un grupo con ese nombre para esa familia.", Nothing)
    End Function

    Public Function can_delete(value As ObjetoVO) As String Implements ICanDAO.can_delete
        ' Nota: Las ganancias se borran en cascada. No se valida que existan.
        Dim grupo = cast(value)
        Dim sql = "SELECT TOP 1 0 FROM productos WHERE idGrupo=" & grupo._id

        Dim db = DataBase.getInstance()
        Dim response = db.consulta_sql(sql)
        Return IIf(response.Rows.Count = 1, "Hay al menos un producto de este grupo. " & Chr(13) & "Imposible borrar grupo.", Nothing)
    End Function
End Class
