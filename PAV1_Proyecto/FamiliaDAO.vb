Public Class FamiliaDAO

    Shared Function all() As DataTable
        ' TODO: Implementar

    End Function

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
    End Function

    Shared Function is_name_in_use(ByRef familia As FamiliaVO)
        ' TODO: Implementar
    End Function

End Class
