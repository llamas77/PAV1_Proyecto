Imports PAV1_Proyecto

Public Class VendedorDAO
    Implements ObjetoDAO, ObjetoGrillable, ObjectFactory

    Public Function all() As DataTable Implements ObjetoDAO.all
        Dim sql_select = "SELECT idVendedor as id, nombre, apellido, direccion, telefono, comision FROM vendedores"
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Dim vendedor = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO vendedores (nombre, apellido, direccion, telefono, comision)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & vendedor._nombre & "', "
        sql_insertar &= "'" & vendedor._apellido & "', "
        sql_insertar &= "'" & vendedor._direccion & "', "
        sql_insertar &= "'" & vendedor._telefono & "', "
        sql_insertar &= vendedor._comision.ToString.Replace(",", ".") & ")" ' Nota: Hay que sacar todas las "," que separan decimal.
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = DataBase.getInstance().consulta_sql(sql_insertar)
        vendedor._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Dim vendedor = cast(value)
        Dim sql_update As String
        sql_update = "UPDATE vendedores"
        sql_update &= " SET "
        sql_update &= "nombre='" & vendedor._nombre & "', "
        sql_update &= "apellido='" & vendedor._apellido & "', "
        sql_update &= "direccion='" & vendedor._direccion & "', "
        sql_update &= "telefono='" & vendedor._telefono & "', "
        sql_update &= "comision=" & vendedor._comision.ToString.Replace(",", ".")
        sql_update &= " WHERE idVendedor=" & vendedor._id
        DataBase.getInstance().ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Dim vendedor = cast(value)
        Dim sql_delete = "DELETE FROM vendedores" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idVendedor=" & vendedor._id
        DataBase.getInstance().ejecuta_sql(sql_delete)
        vendedor._id = 0
    End Sub

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Dim vendedor = cast(value)
        ' DOC: determina si existe la marca en la BD, según PK

        If vendedor._id > 0 Then
            Dim sql = "SELECT TOP 1 idVendedor FROM vendedores WHERE idVendedor=" & vendedor._id
            Dim response = DataBase.getInstance().consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Private Function cast(value As ObjetoVO) As VendedorVO
        If TypeOf value Is VendedorVO Then
            Return value
        Else
            Throw New System.Exception("Error: VendedorDAO solo admite objetos VendedorVO")
        End If
    End Function

    Public Function estructura_grilla(visibles As Boolean) As List(Of String) Implements ObjetoGrillable.estructura_grilla
        ' Nota: Lo ideal seria una lista del tipo (nombre, visible) pero no logro crear arrays con 2 clases de objetos.
        '       En este caso no haria falta el parametro visibles.

        If visibles Then ' Lista de columnas visibles
            Return New List(Of String) From {"id", "nombre", "apellido", "comision", "telefono"}
        Else ' Lista de columnas ocultas
            Return New List(Of String) From {"telefono", "direccion"}
        End If
    End Function

    Public Function new_instance(row As DataGridViewCellCollection) As ObjetoVO Implements ObjetoGrillable.new_instance
        Return New VendedorVO(row("id").Value(),
                              row("nombre").Value(),
                              row("apellido").Value(),
                              row("telefono").Value(),
                              row("direccion").Value(),
                              row("comision").Value())
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Dim comision As Double
        If valores.ContainsKey("comision") Then
            comision = valores("comision")
        Else
            valores("porcentaje") = valores("porcentaje").Replace("%", "")
            valores("porcentaje") = valores("porcentaje").Replace("_", "")
            comision = valores("porcentaje") / 100
        End If

        Return New VendedorVO(valores("id"),
                              valores("nombre"),
                              valores("apellido"),
                              valores("telefono"),
                              valores("direccion"),
                              comision)
    End Function

    Public Function get_IU_control() As ControlGenerico Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo("id", "id", False))
        campos.Add(New Campo("nombre", "Nombre", True, maxLenght:=50))
        campos.Add(New Campo("apellido", "Apellido", True, 50))
        campos.Add(New Campo("telefono", "Teléfono", True, maskType:=LabeledTextBox.MaskType.telefono))
        campos.Add(New Campo("direccion", "Dirección", True, 50))
        campos.Add(New Campo("porcentaje", "Comisión", True, maskType:=LabeledTextBox.MaskType.porcentaje))
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As GrillaGenerica Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo("id", "id", False))
        campos.Add(New Campo("nombre", "Nombre", True))
        campos.Add(New Campo("apellido", "Apellido", True))
        campos.Add(New Campo("telefono", "Teléfono", True))
        campos.Add(New Campo("direccion", "Dirección", True))
        campos.Add(New Campo("porcentaje", "Comisión", True))
        Return New GrillaGenerica(campos, Me)
    End Function

End Class
