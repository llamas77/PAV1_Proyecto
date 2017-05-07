Public Interface ObjetoGrillable
    '
    ' estructura_grilla() le indica a un ObjetoGrilla las columnas a mostrar y como leer un DataTable de DAO.
    ' Ver ejemplo de implementacion en VendedoresDAO
    '
    Function estructura_grilla(visibles As Boolean) As List(Of String)

    '
    ' Conociendo la estructura de la grilla instancia un objetoVO y lo retorna.
    ' Es necesario para que funcione la GrillaGenerica, sino no puede devolver un ObjetoVO.
    '
    Function new_instance(row As DataGridViewCellCollection) As ObjetoVO

End Interface
