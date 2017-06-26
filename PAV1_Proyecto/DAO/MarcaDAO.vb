Imports PAV1_Proyecto

Public Class MarcaDAO
    Implements ObjetoDAO, ObjectFactory, ICanDAO

    ' DOC: (MarcaDataAccessObject) Esta clase se encarga de las consultas SQL a la tabla de Marcas.
    '      Como parametros de entrada/salida generalmente trabaja con MarcaVO.

    Public Function all(Optional db As DataBase = Nothing) As List(Of ObjetoVO) Implements ObjetoDAO.all
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim sql_select = "SELECT idMarca as id, nombre FROM marcas"
        Return dataTable_to_List(db.consulta_sql(sql_select))
    End Function

    Private Function dataTable_to_List(tabla As DataTable) As List(Of ObjetoVO)
        Dim lista As New List(Of ObjetoVO)
        Dim params = {"id", "nombre"}
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
        ' DOC: Inserta la marca en la BD y actualiza el objeto asignandole su ID.

        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim marca = cast(value)

        Dim sql_insertar As String
        sql_insertar = "INSERT INTO marcas (nombre)"
        sql_insertar &= " VALUES ("
        sql_insertar &= "'" & marca._nombre & "')"
        sql_insertar &= "; SELECT SCOPE_IDENTITY()" ' Retorna el ID de la fila insertada.
        Dim tabla = db.consulta_sql(sql_insertar)
        marca._id = tabla(0)(0)
    End Sub

    Public Sub update(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.update
        ' DOC: Actualiza la marca en la BD
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim marca = cast(value)

        Dim sql_update As String
        sql_update = "UPDATE marcas"
        sql_update &= " SET "
        sql_update &= "nombre='" & marca._nombre & "'"
        sql_update &= " WHERE idMarca=" & marca._id
        db.ejecuta_sql(sql_update)
    End Sub

    Public Sub delete(value As ObjetoVO, Optional db As DataBase = Nothing) Implements ObjetoDAO.delete
        ' DOC: Elimina la marca de la BD
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim marca = cast(value)

        Dim sql_delete = "DELETE FROM marcas" ' Si no existe en la BD el comando no falla.
        sql_delete &= " WHERE idMarca=" & marca._id
        db.ejecuta_sql(sql_delete)
        marca._id = 0
    End Sub


    Public Function exists(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean Implements ObjetoDAO.exists
        ' DOC: determina si existe la marca en la BD, según PK
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim marca = cast(value)

        Dim sql = "SELECT TOP 1 idMarca FROM marcas WHERE idMarca=" & marca._id
        sql &= " OR nombre='" & marca._nombre & "'"
            Dim response = db.consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Private Function cast(value As ObjetoVO) As MarcaVO
        If TypeOf value Is MarcaVO Then
            Return value
        Else
            Throw New System.Exception("Error: MarcaDAO solo admite objetos MarcaVO")
        End If
    End Function

    Public Function is_name_in_use(value As ObjetoVO, Optional db As DataBase = Nothing) As Boolean
        ' DOC: determina si existe el nombre de la marca en la BD
        If db Is Nothing Then
            db = DataBase.getInstance()
        End If
        Dim marca = cast(value)

        Dim sql = "SELECT TOP 1 nombre FROM marcas WHERE nombre='" & marca._nombre & "'"
        Dim response = db.consulta_sql(sql)
        Return response.Rows.Count = 1
    End Function

    Public Function get_IU_control() As ObjetoCtrl Implements ObjetoDAO.get_IU_control
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "", ._visible = False, ._numeric = True})
        campos.Add(New Campo With {._id = "nombre", ._name = "Nombre", ._required = True})
        Return New ControlGenerico(campos, Me)
    End Function

    Public Function get_IU_grilla() As ObjetoGrilla Implements ObjetoDAO.get_IU_grilla
        Dim campos As New List(Of Campo)
        campos.Add(New Campo With {._id = "id", ._name = "ID"})
        campos.Add(New Campo With {._id = "nombre", ._name = "Nombre"})
        Return New GrillaGenerica(campos, Me)
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Return New MarcaVO With {
            ._id = valores("id"),
            ._nombre = valores("nombre")
            }
    End Function

    Public Function can_insert(value As ObjetoVO) As String Implements ICanDAO.can_insert
        Return IIf(exists(value), "La marca ya existe.", Nothing)
    End Function

    Public Function can_update(value As ObjetoVO) As String Implements ICanDAO.can_update
        Return IIf(exists(value), "La marca ya existe.", Nothing)
    End Function

    Public Function can_delete(value As ObjetoVO) As String Implements ICanDAO.can_delete
        Dim marca = cast(value)
        Dim sql = "SELECT TOP 1 0 FROM equipos WHERE idMarca=" & marca._id

        Dim db = DataBase.getInstance()
        Dim response = db.consulta_sql(sql)
        Return IIf(response.Rows.Count = 1, "Hay al menos un equipo de esta marca. Imposible borrar marca.", Nothing)
    End Function
End Class
