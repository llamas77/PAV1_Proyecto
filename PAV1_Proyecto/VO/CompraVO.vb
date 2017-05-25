Imports PAV1_Proyecto

Public Class CompraVO
    Implements ObjetoVO

    Private _id_proveedor As Integer
    Private _proveedor As ProveedorVO

    Public Property id As Integer

    Public Property fecha_compra As Date

    Public Property id_proveedor As Integer
        Get
            Return _id_proveedor
        End Get
        Set(value As Integer)
            _id_proveedor = value
            _proveedor = Nothing
        End Set
    End Property

    Public Property proveedor As ProveedorVO
        Get
            Return _proveedor
        End Get
        Set(value As ProveedorVO)
            id_proveedor = value._id
            _proveedor = value
        End Set
    End Property

    Public Property detalle As List(Of DetalleCompraVO)

    Public Function toDictionary() As Dictionary(Of String, Object) Implements ObjetoVO.toDictionary
        Dim diccionario As New Dictionary(Of String, Object)
        diccionario.Add("id", id)
        diccionario.Add("fecha_compra", fecha_compra)
        diccionario.Add("id_proveedor", id_proveedor)
        diccionario.Add("proveedor", proveedor)
        diccionario.Add("detalle", detalle)
        Return diccionario
    End Function

    Private Function ObjetoVO_toString() As String Implements ObjetoVO.toString
        Return "Compra del " & fecha_compra.ToString
    End Function
End Class
