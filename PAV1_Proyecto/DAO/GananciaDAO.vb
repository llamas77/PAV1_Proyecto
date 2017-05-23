Imports PAV1_Proyecto

Public Class GananciaDAO
    Implements ObjetoDAO, ObjectFactory

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Dim ganancia = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO ganancias (idGrupo, idTipo, ganancia)"
        sql_insertar &= " VALUES ("
        sql_insertar &= ganancia._grupo._id & ", "
        sql_insertar &= ganancia._tipo_cliente._id & ", "
        sql_insertar &= ganancia._ganancia.ToString.Replace(",", ".") & ")"
        ' Nota: No es necesario retornar el ID porque ya lo estamos especificando, no lo asigna la BD.
        DataBase.getInstance().ejecuta_sql(sql_insertar)
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Dim ganancia = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE ganancias"
        sql_update &= " SET "
        sql_update &= "idGrupo=" & ganancia._grupo._id & ", "
        sql_update &= "idTipo=" & ganancia._tipo_cliente._id & ", "
        sql_update &= "ganancia=" & ganancia._ganancia.ToString.Replace(",", ".") 
        sql_update &= " WHERE idTipo=" & ganancia._tipo_cliente._id
        sql_update &= " AND idGrupo=" & ganancia._grupo._id
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Dim ganancia = cast(value)
        Dim sql_delete = "DELETE FROM ganancias" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idTipo=" & ganancia._tipo_cliente._id
        sql_delete &= " AND idGrupo=" & ganancia._grupo._id
        DataBase.getInstance().ejecuta_sql(sql_delete)
        ganancia._grupo = Nothing 'DUDA: Para que vacias esto? no se podría destruir la GananciaVO directamente?
        ganancia._tipo_cliente = Nothing
    End Sub

    Public Function all() As DataTable Implements ObjetoDAO.all
        Dim sql_select = ""
        sql_select &= "SELECT ganancias.idGrupo as id_grupo, ganancias.idTipo as id_tipo_cliente, ganancias.ganancia, "
        sql_select &= "tipos_cliente.nombre as nombre_tipo_cliente, grupos.nombre as nombre_grupo FROM ganancias "
        sql_select &= " INNER JOIN tipos_cliente ON ganancias.idTipo=tipos_cliente.idTipo"
        sql_select &= " INNER JOIN grupos ON ganancias.idGrupo=grupos.idGrupo"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Dim ganancia = cast(value)
        ' DOC: determina si existe la ganancia en la BD, según PK
        If ganancia._grupo._id > 0 And ganancia._tipo_cliente._id > 0 Then
            Dim sql = "SELECT TOP 1 idTipo FROM ganancias WHERE idTipo=" & ganancia._tipo_cliente._id
            sql &= " AND idGrupo=" & ganancia._grupo._id
            Dim response = DataBase.getInstance().consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Private Function cast(value As ObjetoVO) As GananciaVO
        If TypeOf value Is GananciaVO Then
            Return value
        Else
            Throw New System.Exception("Error: GananciaDAO solo admite objetos GananciaVO")
        End If
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo("id_grupo", "Grupo", maskType:=Campo.MaskType.comboBox, combo_data_source:=New GrupoDAO))
        campos.Add(New Campo("id_tipo_cliente", "Tipo de Cliente", maskType:=Campo.MaskType.comboBox, combo_data_source:=New TipoClienteDAO))
        campos.Add(New Campo("porcentaje_ganancia", "Ganancia", maskType:=Campo.MaskType.porcentaje))
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo("id_grupo", "", visible:=False))
        campos.Add(New Campo("nombre_grupo", "Grupo"))
        campos.Add(New Campo("id_tipo_cliente", "", visible:=False))
        campos.Add(New Campo("nombre_tipo_cliente", "Tipo de Cliente"))
        campos.Add(New Campo("ganancia", "Proporcion de Ganancia"))
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        ' Debe poder crear un ObjetoVO recibiendo datos con la estructura de una grilla o un control.

        Dim ganancia As Double
        If valores.ContainsKey("ganancia") Then
            ganancia = valores("ganancia")
        Else
            ganancia = valores("porcentaje_ganancia").Replace("%", "") / 100
        End If

        Dim grupo As New GrupoVO(valores("id_grupo"))
        If valores.ContainsKey("nombre_grupo") Then
            grupo._nombre = valores("nombre_grupo")
        End If

        Dim tipo_cliente As New TipoClienteVO(valores("id_tipo_cliente"))
        If valores.ContainsKey("nombre_tipo_cliente") Then
            tipo_cliente._nombre = valores("nombre_tipo_cliente")
        End If

        Return New GananciaVO(grupo, tipo_cliente, ganancia)
    End Function
End Class
