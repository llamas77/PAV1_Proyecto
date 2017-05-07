Imports PAV1_Proyecto

Public Class GrillaGenerica
    Inherits DataGridView
    Implements ObjetoGrilla

    Dim objeto As ObjetoGrillable
    Dim column_names As New List(Of String)

    Public Sub New()
        AllowUserToAddRows = False
        AllowUserToDeleteRows = False
        AllowUserToResizeRows = False
        'AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        MultiSelect = False
        AutoSize = True
        Me.ReadOnly = True
        SelectionMode = DataGridViewSelectionMode.FullRowSelect
        BackgroundColor = System.Drawing.Color.White
        RowHeadersVisible = False


    End Sub

    Public Sub New(objeto As ObjetoGrillable)
        Me.New()
        _objeto = objeto
    End Sub

    Public WriteOnly Property _objeto As ObjetoGrillable
        Set(value As ObjetoGrillable)
            objeto = value
            ' Carga la estructura
            delete_columns()
            For Each mostrar In {True, False} ' Trae las visibles y despues las ocultas.
                For Each nombre_col In value.estructura_grilla(mostrar)
                    add_column(nombre_col, mostrar)
                Next
            Next
        End Set
    End Property

    Public Sub recargar(valores As DataTable) Implements ObjetoGrilla.recargar
        Dim index = vaciar()
        ' TODO: Validar que el DataTable tiene un formato aceptable (minimo de columnas)
        cargar(valores)
        set_index(index)
    End Sub

    Private Sub delete_columns()
        column_names.Clear()
        Me.Columns.Clear()
    End Sub

    Private Sub add_column(nombre As String, mostrar As Boolean)
        column_names.Add(nombre)
        Dim col As New DataGridViewTextBoxColumn
        col.Name = nombre
        col.DataPropertyName = nombre
        col.HeaderText = nombre.ToUpper
        col.Visible = mostrar
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Me.Columns.Add(col)
    End Sub

    Public Function get_selected() As ObjetoVO Implements ObjetoGrilla.get_selected
        Dim sRow = Me.CurrentRow()
        If IsNothing(sRow) Then
            Return Nothing
        Else
            Return objeto.new_instance(sRow.Cells())
        End If
    End Function

    Private Function vaciar() As Integer
        Dim index = 0
        If Me.Rows.Count > 0 Then
            index = Me.CurrentRow().Index
            Me.Rows.Clear()
        End If
        Return index
    End Function

    Private Sub set_index(index As Integer)
        ' Si no hay datos no setea. 
        If Me.Rows.Count > 0 Then
            If Me.Rows.Count() <= index Then ' Si el indice esta fuera de rango, pongo al ultimo.
                index = Me.Rows.Count - 1
            End If
            Me.CurrentCell = Me.Rows(index).Cells(0)
        End If
    End Sub

    Private Sub cargar(datos As DataTable)
        ' Requiere que el DataTable traiga la misma estructura que indica ObjetoVO.
        For i = 0 To datos.Rows.Count() - 1
            Me.Rows.Add()
            For Each nombre In column_names
                Me.Rows(i).Cells(nombre).Value = datos(i)(nombre)
            Next
        Next
    End Sub

End Class
