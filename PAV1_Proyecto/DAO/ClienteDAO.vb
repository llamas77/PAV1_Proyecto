Imports PAV1_Proyecto

Public Class ClienteDAO
    Implements ObjetoDAO, ObjectFactory, ICanDAO

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim sql_select = "SELECT c.nroCliente as nro, c.nombre, c.apellido, c.direccion, c.telefono, "
        sql_select &= " c.idTipoCliente as id_tipo_cliente, t.nombre as nombre_tipo_cliente, t.descripcion as descripcion_tipo_cliente "
        sql_select &= "FROM clientes c INNER JOIN tipos_Cliente t ON c.idTipoCliente = t.idTipo"
        Dim datos = db.consulta_sql(sql_select)
        Return dataTable_to_List(datos)
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"nro", "nombre", "apellido", "direccion", "telefono",
                      "id_tipo_cliente", "nombre_tipo_cliente", "descripcion_tipo_cliente"}
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
        Dim cliente = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO clientes (nombre, apellido, direccion, telefono, idTipoCliente)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & cliente._nombre & "', "
        sql_insertar &= "'" & cliente._apellido & "', "
        sql_insertar &= "'" & cliente._direccion & "', "
        sql_insertar &= "'" & cliente._telefono & "', "
        sql_insertar &= cliente._tipo_cliente._id & ")"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = db.consulta_sql(sql_insertar)
        cliente._nro = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim cliente = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE clientes"
        sql_update &= " SET "
        sql_update &= "nombre='" & cliente._nombre & "', "
        sql_update &= "apellido='" & cliente._apellido & "', "
        sql_update &= "direccion='" & cliente._direccion & "', "
        sql_update &= "telefono='" & cliente._telefono & "', "
        sql_update &= "idTipoCliente=" & cliente._tipo_cliente._id
        sql_update &= " WHERE nroCliente=" & cliente._nro
        db.ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim cliente = cast(value)
        Dim sql_delete = "DELETE FROM clientes" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE nroCliente=" & cliente._nro
        db.ejecuta_sql(sql_delete)
        cliente._nro = 0
    End Sub

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim cliente = cast(value)
        ' DOC: determina si existe la marca en la BD, según PK

        If cliente._nro > 0 Then
            Dim sql = "SELECT TOP 1 nroCliente FROM clientes WHERE nroCliente=" & cliente._nro
            Dim response = db.consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Public Function search_by_id(nroCliente As Integer, Optional db As DataBase = Nothing) As ObjetoVO
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If

        Dim sql = "SELECT nombre, apellido, direccion, telefono, idTipoCliente"
        sql &= " FROM vendedores WHERE idVendedor=" & nroCliente
        Dim registro = db.consulta_sql(sql)

        Dim cliente As ClienteVO = Nothing
        If registro.Rows.Count = 1 Then
            cliente = New ClienteVO With {
                ._nro = nroCliente,
                ._apellido = registro(0)("apellido"),
                ._direccion = registro(0)("direccion"),
                ._tipo_cliente = registro(0)("idTipoCliente"),
                ._nombre = registro(0)("nombre"),
                ._telefono = registro(0)("telefono")
            }
        End If

        Return cliente

    End Function

    Private Function cast(value As ObjetoVO) As ClienteVO
        If TypeOf value Is ClienteVO Then
            Return value
        Else
            Throw New System.Exception("Error: clienteDAO solo admite objetos clienteVO")
        End If
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Dim cliente As New ClienteVO With {
            ._nro = valores("nro"),
            ._nombre = valores("nombre"),
            ._apellido = valores("apellido"),
            ._telefono = valores("telefono"),
            ._direccion = valores("direccion")
        }

        If valores.ContainsKey("tipo_cliente") Then
            cliente._tipo_cliente = valores("tipo_cliente")
        Else
            cliente._tipo_cliente = New TipoClienteVO With {
                ._id = valores("id_tipo_cliente"),
                ._nombre = valores("nombre_tipo_cliente"),
                ._descripcion = valores("descripcion_tipo_cliente")}
        End If

        Return cliente
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "nro", ._name = "Número", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "nombre", ._name = "Nombre", ._required = True, ._max_lenght = 50})
        campos.Add(New Campo With {._id = "apellido", ._name = "Apellido", ._max_lenght = 50})
        campos.Add(New Campo With {._id = "telefono", ._name = "Teléfono", ._maskType = Campo.MaskType.telefono,
                                   ._max_lenght = 50})
        campos.Add(New Campo With {._id = "direccion", ._name = "Dirección"})
        campos.Add(New Campo With {._id = "tipo_cliente", ._name = "Tipo", ._maskType = Campo.MaskType.comboBox,
                                   ._objetoDAO = New TipoClienteDAO, ._required = True})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "nro", ._name = "Número"})
        campos.Add(New Campo With {._id = "nombre", ._name = "Nombre"})
        campos.Add(New Campo With {._id = "apellido", ._name = "Apellido"})
        campos.Add(New Campo With {._id = "telefono", ._visible = False})
        campos.Add(New Campo With {._id = "direccion", ._visible = False})
        campos.Add(New Campo With {._id = "tipo_cliente", ._name = "Tipo"})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function can_insert(value As ObjetoVO) As String Implements ICanDAO.can_insert
        Return Nothing ' Validaciones primitivas en el control.
    End Function

    Public Function can_update(value As ObjetoVO) As String Implements ICanDAO.can_update
        Return Nothing ' Validaciones primitivas en el control.
    End Function

    Public Function can_delete(value As ObjetoVO) As String Implements ICanDAO.can_delete
        Dim cliente = cast(value)

        If cliente._nro <= 0 Then
            Return "No puede borrar un cliente que no existe. [Nro invalido]"
        End If

        Dim db = DataBase.getInstance()
        Dim sql = "SELECT COUNT(idVenta) FROM ventas WHERE nroCliente=" & cliente._nro
        Dim cant_ventas = (db.consulta_sql(sql))(0)(0)
        db.desconectar()
        If cant_ventas > 0 Then
            Return "Hay " & cant_ventas & " venta/s a este cliente. Imposible borrar."
        End If
        Return Nothing
    End Function
End Class
