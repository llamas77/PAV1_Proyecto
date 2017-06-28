Imports PAV1_Proyecto

Public Class ProveedorDAO
    Implements ObjetoDAO, ObjectFactory, ICanDAO


    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim sql_select = "SELECT idProveedor, razonSocial, cuit, domicilio, telefono, email"
        sql_select &= " FROM proveedores"
        Return dataTable_to_List(db.consulta_sql(sql_select))
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"idProveedor", "razonSocial", "cuit", "domicilio", "telefono", "email"}
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
        Dim proveedor = cast(value)

        Dim sql_insertar = "INSERT INTO proveedores (razonSocial, cuit, domicilio, telefono, email)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & proveedor._razonSocial & "', "
        sql_insertar &= "'" & proveedor._cuit & "', "
        sql_insertar &= "'" & proveedor._domicilio & "', "
        sql_insertar &= "'" & proveedor._telefono & "', "
        sql_insertar &= "'" & proveedor._email & "')"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = db.consulta_sql(sql_insertar)
        proveedor._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim proveedor = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE proveedores"
        sql_update &= " SET "
        sql_update &= "razonSocial='" & proveedor._razonSocial & "', "
        sql_update &= "domicilio='" & proveedor._domicilio & "', "
        sql_update &= "telefono='" & proveedor._telefono & "', "
        sql_update &= "email='" & proveedor._email & "'"
        sql_update &= " WHERE idProveedor=" & proveedor._id
        db.ejecuta_sql(sql_update)
    End Sub


    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim proveedor = cast(value)
        Dim sql_delete = "DELETE FROM proveedores"
        sql_delete &= " WHERE idProveedor=" & proveedor._id
        db.ejecuta_sql(sql_delete)
        proveedor._id = 0
    End Sub


    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim proveedor = cast(value)

        Dim sql As String = ""
        If proveedor._id > 0 Then
            sql = "SELECT TOP 1 idProveedor FROM proveedores WHERE idProveedor=" & proveedor._id & " OR"
        Else
            sql = "SELECT TOP 1 idProveedor FROM proveedores WHERE "
        End If
        sql &= " cuit='" & proveedor._cuit & "'"
        Dim response = db.consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Public Function search_by_id(id_proveedor As Integer, Optional db As DataBase = Nothing) As ObjetoVO
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If

        Dim sql = "SELECT razonSocial, cuit, domicilio, telefono, email"
        sql &= " FROM proveedores WHERE idProveedor=" & id_proveedor
        Dim registro = db.consulta_sql(sql)

        Dim proveedor As ProveedorVO = Nothing
        If registro.Rows.Count = 1 Then
            proveedor = New ProveedorVO With {
                ._id = id_proveedor,
                ._cuit = registro(0)("cuit"),
                ._domicilio = registro(0)("domicilio"),
                ._email = registro(0)("email"),
                ._razonSocial = registro(0)("razonSocial"),
                ._telefono = registro(0)("telefono")
            }
        End If

        Return proveedor
    End Function

    Private Function cast(value As ObjetoVO) As ProveedorVO
        If TypeOf value Is ProveedorVO Then
            Return value
        Else
            Throw New System.Exception("Error: proveedorDAO solo admite objetos proveedorVO")
        End If
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Return New ProveedorVO With {
            ._id = valores("idProveedor"),
            ._razonSocial = valores("razonSocial"),
            ._cuit = valores("cuit"),
            ._domicilio = valores("domicilio"),
            ._telefono = valores("telefono"),
            ._email = valores("email")
        }
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "idProveedor", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "razonSocial", ._name = "Razón Social", ._required = True, ._max_lenght = 50})
        campos.Add(New Campo With {._id = "cuit", ._name = "CUIT", ._maskType = Campo.MaskType.cuit, ._required = True})
        campos.Add(New Campo With {._id = "domicilio", ._name = "Domicilio", ._max_lenght = 50})
        campos.Add(New Campo With {._id = "telefono", ._name = "Teléfono", ._maskType = Campo.MaskType.telefono})
        campos.Add(New Campo With {._id = "email", ._name = "Email", ._maskType = Campo.MaskType.email, ._max_lenght = 50})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "idProveedor", ._visible = False})
        campos.Add(New Campo With {._id = "razonSocial", ._name = "Razón Social"})
        campos.Add(New Campo With {._id = "cuit", ._name = "CUIT", ._maskType = Campo.MaskType.cuit})
        campos.Add(New Campo With {._id = "domicilio", ._name = "Domicilio"})
        campos.Add(New Campo With {._id = "telefono", ._name = "Teléfono", ._maskType = Campo.MaskType.telefono})
        campos.Add(New Campo With {._id = "email", ._name = "Email", ._maskType = Campo.MaskType.email})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function can_insert(value As ObjetoVO) As String Implements ICanDAO.can_insert
        Return IIf(exists(value), "Ya hay un proveedor con este CUIT.", Nothing)
    End Function

    Public Function can_update(value As ObjetoVO) As String Implements ICanDAO.can_update
        Dim proveedor = cast(value)

        Dim db = DataBase.getInstance()
        Dim sql = "SELECT TOP 1 0 FROM proveedores WHERE cuit='" & proveedor._cuit & "'"
        sql &= " AND idProveedor<>" & proveedor._id
        Dim response = db.consulta_sql(sql)
        If response.Rows.Count = 1 Then
            Return "Ya existe otro proveedor con ese CUIT."
        End If

        If proveedor._id <= 0 Then
            Return "No puede modificar un proveedor que no existe. [ID invalido]"
        End If

        Return Nothing
    End Function

    Public Function can_delete(value As ObjetoVO) As String Implements ICanDAO.can_delete
        Dim proveedor = cast(value)

        If proveedor._id <= 0 Then
            Return "No puede borrar un proveedor que no existe. [ID invalido]"
        End If

        Dim db = DataBase.getInstance()
        Dim sql = "SELECT COUNT(idCompra) FROM compras WHERE idProveedor=" & proveedor._id
        Dim cant_compras = (db.consulta_sql(sql))(0)(0)
        If cant_compras > 0 Then
            Return "Hay " & cant_compras & " compra/s a este proveedor. Imposible borrar."
        End If
        Return Nothing
    End Function
End Class
