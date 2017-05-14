Imports PAV1_Proyecto

Public Class ClienteControl
    Implements ObjetoCtrl

    Dim cliente As New ClienteVO

    Public Property _objeto As ObjetoVO Implements ObjetoCtrl._objeto
        Get
            Return _cliente
        End Get
        Set(value As ObjetoVO)
            If TypeOf value Is ClienteVO Then
                _cliente = value
            Else
                Throw New Exception("clientesControl solo acepta objetos clienteVO")
            End If
        End Set
    End Property

    Public Property _cliente As ClienteVO
        Get
            cliente._nombre = txt_nombre._text.Trim
            cliente._apellido = txt_apellido._text.Trim
            cliente._direccion = txt_direccion._text.Trim
            cliente._telefono = txt_telefono._text.Trim
            cliente._idTipoCliente = cmb_idTipoCliente.SelectedValue
            cliente._nombreIdTipoCliente = cmb_idTipoCliente.SelectedText
            Return cliente
        End Get
        Set(value As ClienteVO)
            cliente = value
            txt_nombre._text = cliente._nombre
            txt_apellido._text = cliente._apellido
            txt_direccion._text = cliente._direccion
            txt_telefono._text = cliente._telefono
            cmb_idTipoCliente.Text = cliente._idTipoCliente
            cmb_idTipoCliente.Text = cliente._nombreIdTipoCliente
        End Set
    End Property

    Public Sub reset() Implements ObjetoCtrl.reset
        _cliente = New ClienteVO()
    End Sub



    Public Function sql_leerTabla(ByVal nombreTabla As String) As DataTable
        Dim sql_select = "SELECT * FROM " & nombreTabla
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Sub cargarCombo()
        cmb_idTipoCliente.DataSource = sql_leerTabla("tipos_cliente")
        cmb_idTipoCliente.DisplayMember = "nombre"
        cmb_idTipoCliente.ValueMember = "idTipo"
        cmb_idTipoCliente.SelectedIndex = -1
    End Sub

    Public Function is_valid() As Boolean Implements ObjetoCtrl.is_valid
        Return True ' TODO: Validar. Campos opcionales y obligatorios.
    End Function

    Private Sub ClienteControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarCombo()
    End Sub


End Class
