Imports PAV1_Proyecto

Public Class ClienteDAO
    Implements ObjetoDAO, ObjetoGrillable

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

    Public Function estructura_grilla(visibles As Boolean) As List(Of String) Implements ObjetoGrillable.estructura_grilla
        ' Nota: Lo ideal seria una lista del tipo (nombre, visible) pero no logro crear arrays con 2 clases de objetos.
        '       En este caso no haria falta el parametro visibles.

        If visibles Then ' Lista de columnas visibles
            Return New List(Of String) From {"nroCliente", "nombre", "apellido"}
        Else ' Lista de columnas ocultas
            Return New List(Of String) From {"telefono", "direccion", "idTipoCliente", "nombreIdTipoCliente"}
        End If
    End Function

    Public Function new_instance(row As DataGridViewCellCollection) As ObjetoVO Implements ObjetoGrillable.new_instance
        Return New ClienteVO(row("nroCliente").Value(),
                              row("nombre").Value(),
                              row("apellido").Value(),
                              row("telefono").Value(),
                              row("direccion").Value(),
                              row("idTipoCliente").Value(),
                              row("nombreIdTipoCliente").Value())

    End Function
End Class
