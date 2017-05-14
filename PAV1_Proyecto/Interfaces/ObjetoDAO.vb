﻿Public Interface ObjetoDAO

    Function all() As DataTable

    Sub insert(value As ObjetoVO)

    Sub update(value As ObjetoVO)

    Sub delete(value As ObjetoVO)

    Function exists(value As ObjetoVO) As Boolean

    Function get_IU_control() As ObjetoCtrl

    Function get_IU_grilla() As ObjetoGrilla

End Interface
