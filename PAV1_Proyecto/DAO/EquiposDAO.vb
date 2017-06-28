
Public Class EquiposDAO
    Implements ObjetoDAO, ObjectFactory

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim sql_select = "SELECT e.id, e.modelo, e.idMarca as id_marca, m.nombre as nombre_marca "
        sql_select &= " FROM equipos e INNER JOIN marcas m ON e.idMarca = m.idMarca "
        Return dataTable_to_List(db.consulta_sql(sql_select))
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"id", "id_marca", "nombre_marca", "modelo"}
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
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim equipos = cast(value)

        Dim sql_insertar As String
        sql_insertar = " INSERT INTO equipos (idMarca, modelo)"
        sql_insertar &= " VALUES ("
        sql_insertar &= equipos._marca._id & ", "
        sql_insertar &= "'" & equipos._modelo & "')"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = db.consulta_sql(sql_insertar)
        equipos._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim equipos = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE equipos"
        sql_update &= " SET "
        sql_update &= "idMarca= " & equipos._marca._id & ", "
        sql_update &= "modelo= '" & equipos._modelo & "' "
        sql_update &= " WHERE id = " & equipos._id
        db.ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim equipos = cast(value)
        Dim sql_delete = "DELETE FROM equipos" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE id =" & equipos._id
        db.ejecuta_sql(sql_delete)
        equipos._id = 0
    End Sub

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim equipos = cast(value)
        ' DOC: determina si existe la marca en la BD, según PK

        Dim sql = "SELECT TOP 1 id FROM equipos WHERE id=" & equipos._id
        sql &= " OR (idMarca=" & equipos._marca._id & " AND modelo='" & equipos._modelo & "')"
        Dim response = db.consulta_sql(sql)
        Return response.Rows.Count = 1

    End Function

    Public Function all_from_producto(codigo As String, Optional db As DataBase = Nothing) As List(Of ObjetoVO)
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim sql_select = "SELECT e.id, e.modelo, e.idMarca as id_marca, m.nombre as nombre_marca "
        sql_select &= " FROM equipos e INNER JOIN marcas m ON e.idMarca = m.idMarca "
        sql_select &= " INNER JOIN productosxequipos pe ON pe.idEquipo=e.id"
        sql_select &= " WHERE pe.codigoProducto='" & codigo & "'"
        Return dataTable_to_List(db.consulta_sql(sql_select))
    End Function

    Private Function cast(value As ObjetoVO) As EquiposVO
        If TypeOf value Is EquiposVO Then
            Return value
        Else
            Throw New System.Exception("Error: equiposDAO solo admite objetos equiposVO")
        End If
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "marca", ._name = "Marca", ._maskType = Campo.MaskType.comboBox,
                                   ._objetoDAO = New MarcaDAO, ._required = True})
        campos.Add(New Campo With {._id = "modelo", ._name = "Modelo", ._required = True, ._max_lenght = 50})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "ID"})
        campos.Add(New Campo With {._id = "marca", ._name = "Marca"})
        campos.Add(New Campo With {._id = "modelo", ._name = "Modelo"})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Dim equipo As EquiposVO
        If valores.ContainsKey("combo") Then
            equipo = valores("combo") ' Caso especial en que el control es utilizado en un ControlYGrilla
        Else
            equipo = New EquiposVO With {
            ._id = valores("id"),
            ._modelo = valores("modelo")}

            If valores.ContainsKey("marca") Then
                equipo._marca = valores("marca")
            Else
                equipo._marca = New MarcaVO With {
                    ._id = valores("id_marca"),
                    ._nombre = valores("nombre_marca")}
            End If
        End If

        Return equipo
    End Function

End Class
