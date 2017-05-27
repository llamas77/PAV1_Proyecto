
Public Class EquiposControl
    Implements ObjetoCtrl

    Dim equipos As New EquiposVO

    Public Property _objeto As ObjetoVO Implements ObjetoCtrl._objeto
        Get
            Return _equipos
        End Get
        Set(value As ObjetoVO)
            If TypeOf value Is EquiposVO Then
                _equipos = value
            Else
                Throw New Exception("clientesControl solo acepta objetos clienteVO")
            End If
        End Set
    End Property

    Public Property _equipos As EquiposVO
        Get
            equipos._modelo = _txt_modelo._value.Trim
            equipos._idMarca = cmb_idMarca.SelectedValue
            equipos._marca = cmb_idMarca.SelectedText
            Return equipos
        End Get
        Set(value As EquiposVO)
            equipos = value
            _txt_modelo._value = equipos._modelo
            cmb_idMarca.SelectedValue = equipos._idMarca
        End Set
    End Property

    Public Sub reset() Implements ObjetoCtrl.reset
        _equipos = New EquiposVO()
    End Sub

    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        ' El form de busqueda primero setea el objeto y despues muestra la ventana, 
        ' al recargar el combo cuando se muestra, pierdo el valor del objeto.
        cargarCombo()
    End Sub

    Public Function sql_leerTabla(ByVal nombreTabla As String) As DataTable
        Dim sql_select = "SELECT * FROM " & nombreTabla
        Return DataBase.getInstance().consulta_sql(sql_select)
    End Function

    Public Sub cargarCombo()
        cmb_idMarca.DataSource = sql_leerTabla("marcas")
        cmb_idMarca.DisplayMember = "nombre"
        cmb_idMarca.ValueMember = "idMarca"
        cmb_idMarca.SelectedIndex = -1
    End Sub

    Public Function is_valid() As Boolean Implements ObjetoCtrl.is_valid
        Return True ' TODO: Validar. Campos opcionales y obligatorios.
    End Function

    Public Overloads Sub Focus() Implements ObjetoCtrl.Focus
        MyBase.Focus()
    End Sub

End Class
