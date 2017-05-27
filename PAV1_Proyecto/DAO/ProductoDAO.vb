Imports PAV1_Proyecto

Public Class ProductoDAO
    Implements ObjetoDAO, ObjectFactory

    Private Function cast(value As ObjetoVO) As ProductoVO
        If TypeOf value Is ProductoVO Then
            Return value
        Else
            Throw New System.Exception("Error: ProductoVO solo admite objetos ProductoVO")
        End If
    End Function

    Public Sub insert(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.insert
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim producto = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO productos (codigoProducto, idGrupo, costo, nivelReposicion, ubicacion, stock, fechaLista)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & producto._codigo & "', "
        sql_insertar &= producto._grupo._id & ", "
        sql_insertar &= producto._costo.ToString.Replace(",", ".") & ", "
        sql_insertar &= producto._nivelReposicion & ", "
        sql_insertar &= "'" & producto._ubicacion & "', "
        sql_insertar &= producto._stock & ", "
        sql_insertar &= "convert(date, '" & producto._fechaLista & "', 103))"
        db.ejecuta_sql(sql_insertar)
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        update_in(DataBase.getInstance(), value)
    End Sub

    Public Sub update_in(db As DataBase, value As ObjetoVO)
        Dim producto = cast(value)

        Dim sql_update As String
        sql_update = "UPDATE productos"
        sql_update &= " SET "
        sql_update &= "idGrupo=" & producto._grupo._id & ", "
        sql_update &= "costo=" & producto._costo.ToString().Replace(",", ".") & ", "
        sql_update &= "nivelReposicion=" & producto._nivelReposicion & ", "
        sql_update &= "ubicacion='" & producto._ubicacion & "', "
        sql_update &= "stock=" & producto._stock & ", "
        sql_update &= "fechaLista=convert(date, '" & producto._fechaLista & "', 103))"
        sql_update &= " WHERE codigoProducto='" & producto._codigo & "'"
        db.ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim producto = cast(value)
        Dim sql_delete = "DELETE FROM productos" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE codigoProducto='" & producto._codigo & "'"
        db.ejecuta_sql(sql_delete)
        producto._grupo = Nothing
    End Sub

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim sql_select = ""
        sql_select &= "SELECT p.codigoProducto as codigo, p.costo, convert(char(10), p.fechaLista, 103) as fechaLista, "
        sql_select &= " p.nivelReposicion, p.ubicacion, p.stock, "
        sql_select &= " p.idGrupo as id_grupo, g.nombre as nombre_grupo, g.idFamilia as id_familia_grupo "
        sql_select &= " FROM productos p "
        sql_select &= "INNER JOIN grupos g on g.idGrupo = p.idGrupo"
        Dim tabla = db.consulta_sql(sql_select)
        Return dataTable_to_List(tabla)
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"codigo", "costo", "fechaLista", "nivelReposicion",
                      "ubicacion", "stock", "id_grupo", "nombre_grupo", "id_familia_grupo"}
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

    Public Function search_code(db As DataBase, codigo As String) As ObjetoVO
        Dim sql = "SELECT TOP 1 codigoProducto, idGrupo, costo, convert(char(10), fechaLista, 103) as fechaLista, "
        sql &= " nivelReposicion, ubicacion, stock FROM productos WHERE codigoProducto='" & codigo & "'"
        Dim response = db.consulta_sql(sql)
        If response.Rows.Count = 1 Then
            Return New ProductoVO With {
            ._codigo = response(0)("codigoProducto"),
            ._costo = response(0)("costo"),
            ._fechaLista = response(0)("fechaLista"),
            ._grupo = response(0)("idGrupo"),
            ._nivelReposicion = response(0)("nivelReposicion"),
            ._stock = response(0)("stock"),
            ._ubicacion = response(0)("ubicacion")}
        Else
            Return Nothing
        End If

    End Function

    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim producto = cast(value)
        ' DOC: determina si existe el producto en la BD, según PK
        If producto._codigo <> "" Then
            Dim sql = "SELECT TOP 1 codigoProducto FROM productos WHERE codigoProducto='" & producto._codigo & "'"
            Dim response = db.consulta_sql(sql)
            Return response.Rows.Count = 1
        Else
            Return False
        End If
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "codigo", ._name = "Código",
                                   ._max_lenght = 20, ._required = True})
        campos.Add(New Campo With {._id = "grupo", ._name = "Grupo",
                   ._maskType = Campo.MaskType.comboBox, ._objetoDAO = New GrupoDAO})
        campos.Add(New Campo With {._id = "costo", ._name = "Costo", ._numeric = True})
        campos.Add(New Campo With {._id = "fechaLista", ._name = "Fecha Actual",
                                   ._maskType = Campo.MaskType.fecha})
        campos.Add(New Campo With {._id = "nivelReposicion", ._name = "Nivel de Reposicion",
                                   ._numeric = True})
        campos.Add(New Campo With {._id = "ubicacion", ._name = "Ubicación"})
        campos.Add(New Campo With {._id = "stock", ._name = "Stock", ._numeric = True})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "codigo", ._name = "Código"})
        campos.Add(New Campo With {._id = "grupo", ._name = "Grupo"})
        campos.Add(New Campo With {._id = "costo", ._name = "Costo"})
        campos.Add(New Campo With {._id = "fechaLista", ._name = "Fecha Act"})
        campos.Add(New Campo With {._id = "nivelReposicion", ._name = "Nivel de Reposicion"})
        campos.Add(New Campo With {._id = "ubicacion", ._name = "Ubicación"})
        campos.Add(New Campo With {._id = "stock", ._name = "Stock"})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        ' Debe poder crear un ObjetoVO recibiendo datos con la estructura de una grilla o un control.
        Dim producto As New ProductoVO With {
            ._codigo = valores("codigo"),
            ._costo = valores("costo"),
            ._fechaLista = valores("fechaLista"),
            ._nivelReposicion = valores("nivelReposicion"),
            ._stock = valores("stock"),
            ._ubicacion = valores("ubicacion")
        }

        If valores.ContainsKey("grupo") Then
            producto._grupo = valores("grupo")
        Else
            producto._grupo = New GrupoVO With {
            ._id = valores("id_grupo"),
            ._nombre = valores("nombre_grupo")
            }
            If valores.ContainsKey("familia_grupo") Then
                producto._grupo._familia = valores("familia_grupo")
            Else
                With New FamiliaDAO
                    producto._grupo._familia = .search_by_id(valores("id_familia_grupo"))
                End With
            End If
        End If

        Return producto
    End Function
End Class
