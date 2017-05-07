Public Class TipoClienteDAO
    Implements ObjetoDAO

    Public Function all() As DataTable Implements ObjetoDAO.all
        Return New DataTable
    End Function

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        ' TODO: Castear a Tipo Cliente y Operar.
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update

    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete

    End Sub

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists

    End Function

End Class
