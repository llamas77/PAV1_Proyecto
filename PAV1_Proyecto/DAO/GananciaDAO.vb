Imports PAV1_Proyecto

Public Class GananciaDAO
    Implements ObjetoDAO, ObjectFactory

    Public Sub insert(value As ObjetoVO) Implements ObjetoDAO.insert
        Throw New NotImplementedException()
    End Sub

    Public Sub update(value As ObjetoVO) Implements ObjetoDAO.update
        Throw New NotImplementedException()
    End Sub

    Public Sub delete(value As ObjetoVO) Implements ObjetoDAO.delete
        Throw New NotImplementedException()
    End Sub

    Public Function all() As DataTable Implements ObjetoDAO.all
        Throw New NotImplementedException()
    End Function

    Public Function exists(value As ObjetoVO) As Boolean Implements ObjetoDAO.exists
        Throw New NotImplementedException()
    End Function

    Public Function get_IU_control() As ControlGenerico Implements ObjetoDAO.get_IU_control
        Throw New NotImplementedException()
    End Function

    Public Function get_IU_grilla() As GrillaGenerica Implements ObjetoDAO.get_IU_grilla
        Throw New NotImplementedException()
    End Function

    Public Function new_instance(valores As Dictionary(Of String, Object)) As ObjetoVO Implements ObjectFactory.new_instance
        Throw New NotImplementedException()
    End Function
End Class
