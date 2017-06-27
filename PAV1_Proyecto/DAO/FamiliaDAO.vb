Imports PAV1_Proyecto

Public Class FamiliaDAO
    Implements ObjetoDAO, ObjectFactory, ICanDAO

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim sql_select = "SELECT idFamilia as id, nombre FROM familias"
        Return dataTable_to_List(db.consulta_sql(sql_select))
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"id", "nombre"}
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
        Dim familia = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO familias (nombre)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & familia._nombre & "')"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = db.consulta_sql(sql_insertar)
        familia._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        ' DOC: Actualiza la marca en la BD
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim familia = cast(value)

        Dim sql_update As String
        sql_update = "UPDATE familias"
        sql_update &= " SET "
        sql_update &= "nombre='" & familia._nombre & "'"
        sql_update &= " WHERE idFamilia=" & familia._id
        db.ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        ' DOC: Elimina la marca de la BD
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim familia = cast(value)

        Dim sql_delete = "DELETE FROM familias" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idFamilia=" & familia._id
        db.ejecuta_sql(sql_delete)
        familia._id = 0
    End Sub

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        ' DOC: determina si existe la marca en la BD, según PK y UNIQUE
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim familia = cast(value)

        Dim sql = "SELECT TOP 1 idFamilia FROM familias WHERE idFamilia=" & familia._id
        sql &= " OR nombre='" & familia._nombre & "'"
        Dim response = db.consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Private Function cast(value As ObjetoVO) As FamiliaVO
        If TypeOf value Is FamiliaVO Then
            Return value
        Else
            Throw New System.Exception("Error: FamiliaDAO solo admite objetos FamiliaVO")
        End If
    End Function

    Public Function is_name_in_use(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean
        ' DOC: determina si existe el nombre de la marca en la BD
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim familia = cast(value)

        Dim sql = "SELECT TOP 1 nombre FROM familias WHERE nombre='" & familia._nombre & "'"
        Dim response = db.consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Public Function search_by_id(familia_id As Integer, Optional db As DataBase = Nothing) As ObjetoVO
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If

        Dim sql = "SELECT TOP 1 nombre FROM familias WHERE idFamilia=" & familia_id
        Dim response = db.consulta_sql(sql)

        Dim familia As FamiliaVO = Nothing
        If response.Rows.Count = 1 Then
            familia = New FamiliaVO With {
                ._id = familia_id,
                ._nombre = response(0)("nombre")}
        End If

        Return familia
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "nombre", ._name = "Nombre", ._required = True, ._max_lenght = 50})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "ID"})
        campos.Add(New Campo With {._id = "nombre", ._name = "Nombre"})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Return New FamiliaVO With {
            ._id = valores("id"),
            ._nombre = valores("nombre")
            }
    End Function

    Public Function can_insert(value As ObjetoVO) As String Implements ICanDAO.can_insert
        Dim familia = cast(value)
        Return IIf(exists(value), "Ya existe una familia con ese nombre.", Nothing)
    End Function

    Public Function can_update(value As ObjetoVO) As String Implements ICanDAO.can_update
        Dim familia = cast(value)
        Return IIf(is_name_in_use(familia), "Ya existe una familia con ese nombre.", Nothing)
    End Function

    Public Function can_delete(value As ObjetoVO) As String Implements ICanDAO.can_delete
        Dim familia = cast(value)
        Dim sql = "SELECT TOP 1 0 FROM familias WHERE idFamilia=" & familia._id

        Dim db = DataBase.getInstance()
        Dim response = db.consulta_sql(sql)
        Return IIf(response.Rows.Count = 1, "Hay al menos un grupo de esta familia. Imposible borrar familia.", Nothing)
    End Function
End Class
