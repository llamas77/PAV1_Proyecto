﻿Imports PAV1_Proyecto

Public Class GananciaDAO
    Implements ObjetoDAO, ObjectFactory

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Dim ganancia = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO ganancias (idGrupo, idTipo, ganancia)"
        sql_insertar &= " VALUES ("
        sql_insertar &= ganancia._grupo._id & ", "
        sql_insertar &= ganancia._tipo_cliente._id & ", "
        sql_insertar &= ganancia._proporcion_ganancia.ToString.Replace(",", ".") & ")"
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
        sql_update &= "ganancia=" & ganancia._proporcion_ganancia.ToString.Replace(",", ".")
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
    End Sub

    Public Function all() As List(Of ObjetoVO) Implements ObjetoDAO.all
        Dim sql_select = ""
        sql_select &= "SELECT ganancias.idGrupo as id_grupo, ganancias.idTipo as id_tipo_cliente, ganancias.ganancia, "
        sql_select &= "tipos_cliente.nombre as nombre_tipo_cliente, grupos.nombre as nombre_grupo FROM ganancias "
        sql_select &= " INNER JOIN tipos_cliente ON ganancias.idTipo=tipos_cliente.idTipo"
        sql_select &= " INNER JOIN grupos ON ganancias.idGrupo=grupos.idGrupo"
        Return dataTable_to_List(DataBase.getInstance().consulta_sql(sql_select))
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"id_grupo", "id_tipo_cliente", "ganancia", "nombre_tipo_cliente",
                      "nombre_grupo"}
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
        campos.Add(New Campo With {._id = "grupo", ._name = "Grupo",
                                   ._maskType = Campo.MaskType.comboBox,
                                   ._combo_data_source = New GrupoDAO})
        campos.Add(New Campo With {._id = "tipo_cliente", ._name = "Tipo de Cliente",
                                   ._maskType = Campo.MaskType.comboBox,
                                   ._combo_data_source = New TipoClienteDAO})
        campos.Add(New Campo With {._id = "porcentaje_ganancia", ._name = "Ganancia",
                                   ._maskType = Campo.MaskType.porcentaje})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id_grupo", ._visible = False})
        campos.Add(New Campo With {._id = "grupo", ._name = "Grupo"})
        campos.Add(New Campo With {._id = "tipo_cliente", ._name = "Tipo de Cliente"})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        ' Debe poder crear un ObjetoVO recibiendo datos con la estructura de una grilla o un control.
        Dim objetoVO As New GananciaVO()

        If valores.ContainsKey("proporcion_ganancia") Then
            objetoVO._proporcion_ganancia = valores("proporcion_ganancia")
        Else
            objetoVO._porcentaje_ganancia = valores("porcentaje_ganancia")
        End If

        If valores.ContainsKey("grupo") Then
            objetoVO._grupo = valores("grupo")
        Else
            objetoVO._grupo = New GrupoVO With {
                ._id = valores("id_grupo"),
                ._nombre = valores("nombre_grupo"),
                ._familia = valores("familia_grupo")}
        End If

        If valores.ContainsKey("tipo_cliente") Then
            objetoVO._tipo_cliente = valores("tipo_cliente")
        Else
            objetoVO._tipo_cliente = New TipoClienteVO With {
                ._id = valores("id_tipo_cliente"),
                ._nombre = valores("nombre_tipo_cliente"),
                ._descripcion = valores("descripcion_tipo_cliente")}
        End If

        Return objetoVO
    End Function
End Class
