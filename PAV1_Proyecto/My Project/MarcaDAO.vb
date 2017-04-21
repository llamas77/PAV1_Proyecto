Public Class MarcaDAO
    ' DOC: Esta clase se encarga de las consultas SQL a la tabla de Marcas.
    '      Como parametros de entrada/salida trabaja con MarcaVO.

    Public Function all() As ArrayList
        Dim marcas As ArrayList
        ' TODO: Hace un SELECT de la tabla entera y devuelve un conjunto de elementos.
        Return marcas
    End Function

    Public Sub insert(ByRef marca As MarcaVO)
        ' TODO: Insertar marca en la BD.

    End Sub

    Public Sub update(ByRef marca As MarcaVO)
        ' TODO: Update a marca en la BD.
    End Sub

    Public Sub save(ByRef marca As MarcaVO)
        If marca.has_id() Then
            Me.update(marca)
        Else
            Me.insert(marca)
        End If
    End Sub

    Public Sub delete(ByRef marca As MarcaVO)
        ' TODO: Validar que tenga un ID (esta en la BD) y eliminar la marca.
    End Sub






End Class
