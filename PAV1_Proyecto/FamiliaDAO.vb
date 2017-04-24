Public Class FamiliaDAO

    Shared Sub all(ByRef tabla As DataTable)
        ' TODO: Implementar
    End Sub

    Shared Sub insert(ByRef familia As FamiliaVO)
        ' TODO: Implementar
    End Sub

    Shared Sub update(ByRef familia As FamiliaVO)
        ' TODO: Implementar
    End Sub

    Shared Sub save(ByRef familia As FamiliaVO)
        ' DOC: Si la familia existe en la bd invoca a update, sino a insert
        ' TODO: Implementar
    End Sub

    Shared Sub delete(ByRef familia As FamiliaVO)
        ' TODO: Implementar
    End Sub

    Shared Function exists(ByRef familia As FamiliaVO) As Boolean
        ' TODO: Implementar
        Return True 'Juani: Lo pongo para sacar la maldita advertencia por ahora.
    End Function

End Class
