
Public Class EquiposDAO
    Implements ObjetoDAO, ObjectFactory

    Public Function all() As DataTable Implements ObjetoDAO.all
        Dim sql_select = "SELECT id, equipos.idMarca, marcas.nombre as marca, modelo FROM equipos INNER JOIN marcas ON equipos.idMarca = marcas.idMarca "
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function


    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Dim equipos = cast(value)

        Dim sql_insertar As String
        sql_insertar = " INSERT INTO equipos (idMarca, modelo)"
        sql_insertar &= " VALUES ("
        sql_insertar &= equipos._idMarca & ", "
        sql_insertar &= "'" & equipos._modelo & "')"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
        equipos._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Dim equipos = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE equipos"
        sql_update &= " SET "
        sql_update &= "idMarca= " & equipos._idMarca & ", "
        sql_update &= "modelo= '" & equipos._modelo & "' "
        sql_update &= " WHERE id = " & equipos._id
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Dim equipos = cast(value)
        Dim sql_delete = "DELETE FROM equipos" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE id =" & equipos._id
        DataBase.getInstance().ejecuta_sql(sql_delete)
        equipos._id = 0
    End Sub

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Dim equipos = cast(value)
        ' DOC: determina si existe la marca en la BD, según PK

        If equipos._id > 0 Then
            Dim sql = "SELECT TOP 1 id FROM equipos WHERE id=" & equipos._id
            Dim response = DataBase.getInstance().consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Private Function cast(value As ObjetoVO) As EquiposVO
        If TypeOf value Is EquiposVO Then
            Return value
        Else
            Throw New System.Exception("Error: equiposDAO solo admite objetos equiposVO")
        End If
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Return New EquiposVO(valores("id"),
                           valores("idMarca"),
                           valores("marca"),
                           valores("modelo"))
    End Function
    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo("id", "Id"))
        campos.Add(New Campo("idMarca", "", visible:=False))
        campos.Add(New Campo("marca", "Marca"))
        campos.Add(New Campo("modelo", "Modelo"))
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Return New EquiposControl()
    End Function

End Class
