Imports PAV1_Proyecto

Public Class GananciaDAO
    Implements ObjetoDAO, ObjectFactory

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Throw New NotImplementedException()
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Throw New NotImplementedException()
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Throw New NotImplementedException()
    End Sub

    Public Function all() As DataTable Implements ObjetoDAO.all
        Dim sql_select = ""
        sql_select &= "SELECT ganancias.idGrupo as id_grupo, ganancias.idTipo as id_tipo_cliente, ganancias.ganancia, "
        sql_select &= "tipos_cliente.nombre as nombre_tipo_cliente, grupos.nombre as nombre_grupo FROM ganancias "
        sql_select &= "INNER JOIN tipos_cliente ON ganancias.idTipo=tipos_cliente.idTipo"
        sql_select &= "INNER JOIN grupos ON ganancias.idGrupo=grupos.idGrupo"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Throw New NotImplementedException()
    End Function

    Public Function get_IU_control() As ControlGenerico Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo("grupo", "Grupo", boxType:=Campo.BoxType.comboBox, combo_data_source:=New GrupoDAO))
        campos.Add(New Campo("tipo_cliente", "Tipo de Cliente", boxType:=Campo.BoxType.comboBox, combo_data_source:=New TipoClienteDAO))
        campos.Add(New Campo("porcentaje_ganancia", "Ganancia", maskType:=LabeledTextBox.MaskType.porcentaje))
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As GrillaGenerica Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo("id_grupo", "", visible:=False))
        campos.Add(New Campo("nombre_grupo", "Grupo"))
        campos.Add(New Campo("id_tipo_cliente", "", visible:=False))
        campos.Add(New Campo("nombre_tipo_cliente", "Tipo de Cliente"))
        campos.Add(New Campo("ganancia", "Proporcion de Ganancia"))
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Throw New NotImplementedException()
    End Function
End Class
