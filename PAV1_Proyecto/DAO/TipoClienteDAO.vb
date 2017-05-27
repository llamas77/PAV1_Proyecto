﻿Imports PAV1_Proyecto

Public Class TipoClienteDAO
    Implements ObjetoDAO, ObjectFactory

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim sql_select = "SELECT idTipo as id, nombre, descripcion FROM tipos_cliente"
        Return dataTable_to_List(db.consulta_sql(sql_select))
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"id", "nombre", "descripcion"}
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
        Dim tipo_cliente = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO tipos_cliente (nombre, descripcion)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & tipo_cliente._nombre & "', "
        sql_insertar &= "'" & tipo_cliente._descripcion & "')"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = db.consulta_sql(sql_insertar)
        tipo_cliente._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim tipo_cliente = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE tipos_cliente"
        sql_update &= " SET "
        sql_update &= "nombre='" & tipo_cliente._nombre & "', "
        sql_update &= "descripcion='" & tipo_cliente._descripcion & "' "
        sql_update &= " WHERE "
        If tipo_cliente._id > 0 Then
            sql_update &= "idTipo=" & tipo_cliente._id
        Else
            sql_update &= "nombre='" & tipo_cliente._nombre & "'"
        End If

        db.ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim tipo_cliente = cast(value)
        Dim sql_delete = "DELETE FROM tipos_cliente" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idTipo=" & tipo_cliente._id
        db.ejecuta_sql(sql_delete)
        tipo_cliente._id = 0
    End Sub

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim tipo_cliente = cast(value)
        ' DOC: determina si existe la marca en la BD, según PK

        ' En este caso no alcanza sólo el ID sino que el nombre debe ser Unico
        Dim sql = "SELECT TOP 1 idTipo FROM tipos_cliente WHERE idTipo=" & tipo_cliente._id
        sql &= "OR nombre='" & tipo_cliente._nombre & "'"
        Dim response = db.consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Public Function search_by_id(tipo_id As Integer, Optional db As DataBase = Nothing) As ObjetoVO
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If

        Dim sql = "SELECT nombre, descripcion FROM tipos_cliente WHERE idTipo=" & tipo_id
        Dim registro = db.consulta_sql(sql)

        Dim tipo_cliente As TipoClienteVO = Nothing
        If registro.Rows.Count = 1 Then
            tipo_cliente = New TipoClienteVO With {
                ._id = tipo_id,
                ._nombre = registro(0)("nombre"),
                ._descripcion = registro(0)("descripcion")
            }
        End If

        Return tipo_cliente
    End Function

    Private Function cast(value As ObjetoVO) As TipoClienteVO
        If TypeOf value Is TipoClienteVO Then
            Return value
        Else
            Throw New System.Exception("Error: TipoClienteDAO solo admite objetos TipoClienteVO")
        End If
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo("id", "", visible:=False))
        campos.Add(New Campo("nombre", "Nombre", maxLenght:=50))
        campos.Add(New Campo("descripcion", "Descripcion", maxLenght:=50))
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Return New TipoClienteGrilla()
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Return New TipoClienteVO(valores("id"), valores("nombre"), valores("descripcion"))
    End Function
End Class
