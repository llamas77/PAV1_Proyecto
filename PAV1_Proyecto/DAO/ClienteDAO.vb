﻿Imports PAV1_Proyecto

Public Class ClienteDAO
    Implements ObjetoDAO, ObjectFactory

    Public Function all() As DataTable Implements ObjetoDAO.all
        Dim sql_select = "SELECT nroCliente, clientes.nombre, apellido, direccion, telefono, idTipoCliente , tipos_Cliente.nombre as nombreIdTipoCliente "
        sql_select &= "FROM clientes INNER JOIN tipos_Cliente ON idTipoCliente = idTipo"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function


    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Dim cliente = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO clientes (nombre, apellido, direccion, telefono, idTipoCliente)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & cliente._nombre & "', "
        sql_insertar &= "'" & cliente._apellido & "', "
        sql_insertar &= "'" & cliente._direccion & "', '"
        sql_insertar &= cliente._telefono & "', "
        sql_insertar &= cliente._idTipoCliente & ")"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
        cliente._nro = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Dim cliente = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE clientes"
        sql_update &= " SET "
        sql_update &= "nombre='" & cliente._nombre & "', "
        sql_update &= "apellido='" & cliente._apellido & "', "
        sql_update &= "direccion='" & cliente._direccion & "', "
        sql_update &= "telefono='" & cliente._telefono & "', "
        sql_update &= "idTipoCliente=" & cliente._idTipoCliente
        sql_update &= " WHERE nroCliente=" & cliente._nro
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Dim cliente = cast(value)
        Dim sql_delete = "DELETE FROM clientes" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE nroCliente=" & cliente._nro
        DataBase.getInstance().ejecuta_sql(sql_delete)
        cliente._nro = 0
    End Sub

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Dim cliente = cast(value)
        ' DOC: determina si existe la marca en la BD, según PK

        If cliente._nro > 0 Then
            Dim sql = "SELECT TOP 1 nroCliente FROM clientes WHERE nroCliente=" & cliente._nro
            Dim response = DataBase.getInstance().consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Private Function cast(value As ObjetoVO) As ClienteVO
        If TypeOf value Is ClienteVO Then
            Return value
        Else
            Throw New System.Exception("Error: clienteDAO solo admite objetos clienteVO")
        End If
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Return New ClienteVO(valores("nroCliente"),
                              valores("nombre"),
                              valores("apellido"),
                              valores("telefono"),
                              valores("direccion"),
                              valores("idTipoCliente"),
                              valores("nombreIdTipoCliente"))
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Return New ClienteControl()
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo("nroCliente", "Nro Cliente"))
        campos.Add(New Campo("nombre", "Nombre"))
        campos.Add(New Campo("apellido", "Apellido"))
        campos.Add(New Campo("telefono", "", visible:=False))
        campos.Add(New Campo("direccion", "", visible:=False))
        campos.Add(New Campo("idTipoCliente", "", visible:=False))
        campos.Add(New Campo("nombreIdTipoCliente", "", visible:=False))
        Return New GrillaGenerica(campos, Me)
    End Function


End Class