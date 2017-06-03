Imports PAV1_Proyecto

Public Class VendedorDAO
    Implements ObjetoDAO, ObjectFactory

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim sql_select = "SELECT idVendedor as id, nombre, apellido, direccion, telefono, comision as proporcion_comision"
        sql_select &= " FROM vendedores"
        Return dataTable_to_List(db.consulta_sql(sql_select))
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"id", "nombre", "apellido", "direccion", "telefono", "proporcion_comision"}
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
        Dim vendedor = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO vendedores (nombre, apellido, direccion, telefono, comision)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & vendedor._nombre & "', "
        sql_insertar &= "'" & vendedor._apellido & "', "
        sql_insertar &= "'" & vendedor._direccion & "', "
        sql_insertar &= "'" & vendedor._telefono & "', "
        sql_insertar &= vendedor._proporcion_comision.ToString.Replace(",", ".") & ")" ' Nota: Hay que sacar todas las "," que separan decimal.
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = db.consulta_sql(sql_insertar)
        vendedor._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim vendedor = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE vendedores"
        sql_update &= " SET "
        sql_update &= "nombre='" & vendedor._nombre & "', "
        sql_update &= "apellido='" & vendedor._apellido & "', "
        sql_update &= "direccion='" & vendedor._direccion & "', "
        sql_update &= "telefono='" & vendedor._telefono & "', "
        sql_update &= "comision=" & vendedor._proporcion_comision.ToString.Replace(",", ".")
        sql_update &= " WHERE idVendedor=" & vendedor._id
        db.ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim vendedor = cast(value)
        Dim sql_delete = "DELETE FROM vendedores" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idVendedor=" & vendedor._id
        db.ejecuta_sql(sql_delete)
        vendedor._id = 0
    End Sub

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim vendedor = cast(value)
        ' DOC: determina si existe el vendedor en la BD, según PK

        If vendedor._id > 0 Then
            Dim sql = "SELECT TOP 1 idVendedor FROM vendedores WHERE idVendedor=" & vendedor._id
            Dim response = db.consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function


    Public Function search_by_id(id_vendedor As Integer, Optional db As DataBase = Nothing) As ObjetoVO
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If

        Dim sql = "SELECT nombre, apellido, direccion, telefono, comision"
        sql &= " FROM vendedores WHERE idVendedor=" & id_vendedor
        Dim registro = db.consulta_sql(sql)

        Dim vendedor As VendedorVO = Nothing
        If registro.Rows.Count = 1 Then
            vendedor = New VendedorVO With {
                ._id = id_vendedor,
                ._apellido = registro(0)("apellido"),
                ._direccion = registro(0)("direccion"),
                ._porcentaje_comision = registro(0)("comision"),
                ._nombre = registro(0)("nombre"),
                ._telefono = registro(0)("telefono")
            }
        End If

        Return vendedor

    End Function

    Private Function cast(value As ObjetoVO) As VendedorVO
        If TypeOf value Is VendedorVO Then
            Return value
        Else
            Throw New System.Exception("Error: VendedorDAO solo admite objetos VendedorVO")
        End If
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._visible = False})
        campos.Add(New Campo With {._id = "nombre", ._name = "Nombre", ._max_lenght = 50, ._required = True})
        campos.Add(New Campo With {._id = "apellido", ._name = "Apellido", ._max_lenght = 50})
        campos.Add(New Campo With {._id = "telefono", ._name = "Teléfono", ._maskType = Campo.MaskType.telefono})
        campos.Add(New Campo With {._id = "direccion", ._name = "Dirección", ._max_lenght = 50})
        campos.Add(New Campo With {._id = "porcentaje_comision", ._name = "Comisión", ._maskType = Campo.MaskType.porcentaje, ._required = True})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._visible = False})
        campos.Add(New Campo With {._id = "nombre", ._name = "Nombre"})
        campos.Add(New Campo With {._id = "apellido", ._name = "Apellido"})
        campos.Add(New Campo With {._id = "telefono", ._name = "Teléfono"})
        campos.Add(New Campo With {._id = "direccion", ._visible = False})
        campos.Add(New Campo With {._id = "porcentaje_comision", ._name = "Comisión"})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Dim vendedor As New VendedorVO With {
            ._id = valores("id"),
            ._nombre = valores("nombre"),
            ._apellido = valores("nombre"),
            ._telefono = valores("telefono"),
            ._direccion = valores("direccion")
        }

        If valores.ContainsKey("proporcion_comision") Then
            vendedor._proporcion_comision = valores("proporcion_comision")
        Else
            vendedor._porcentaje_comision = valores("porcentaje_comision")
        End If

        Return vendedor
    End Function
End Class
