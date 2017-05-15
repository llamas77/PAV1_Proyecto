Imports PAV1_Proyecto

Public Class GrillaGenerica
    Inherits DataGridView
    Implements ObjetoGrilla

    Dim fabrica As ObjectFactory
    Dim column_names As New List(Of String)
    Dim visible_col_name As String

    Public Sub New(columnas As List(Of Campo), fabrica As ObjectFactory)
        ' - - - Configuracion por defecto - - -
        AllowUserToAddRows = False
        AllowUserToDeleteRows = False
        AllowUserToResizeRows = False
        AllowUserToResizeColumns = False
        ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        'ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        MultiSelect = False
        AutoSize = False
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Me.ReadOnly = True
        SelectionMode = DataGridViewSelectionMode.FullRowSelect
        RowHeadersVisible = False
        BackgroundColor = System.Drawing.Color.White
        StandardTab = True ' Indica si la tecla TABULADOR mueve el foco al siguiente elemento.
        ' - - - Fin - - - 

        Me.fabrica = fabrica

        For Each campo In columnas
            If campo._visible Then
                ' Guardo una columna visible para poder seleccionar la fila
                ' porque si se trata de seleccionar una celda invisible ocurre una excepcion.
                visible_col_name = campo._id
            End If
            add_column(campo)
        Next
        execute_resize()
    End Sub

    Private Sub execute_resize()
        '
        ' AutoSize Manual para corregir el bug del espacio en blanco a la derecha.
        '
        Dim width As Integer = 0
        For Each columna In Me.column_names
            If Columns(columna).Visible Then
                Columns(columna).Width = Columns(columna).GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, True)
                width += Columns(columna).Width
            End If
        Next
        Me.Width = width + 3
        If width < MinimumSize.Width Then
            Columns(visible_col_name).Width = Columns(visible_col_name).Width + MinimumSize.Width - width - 3
        End If
    End Sub

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

    Private Sub add_column(campo As Campo)
        column_names.Add(campo._id)
        Dim col As New DataGridViewTextBoxColumn
        col.Name = campo._id
        col.DataPropertyName = campo._id
        col.HeaderText = campo._name
        col.Visible = campo._visible
        Me.Columns.Add(col)
    End Sub

    Public Function get_selected() As ObjetoVO Implements ObjetoGrilla.get_selected
        Dim sRow = Me.CurrentRow()
        If IsNothing(sRow) Then
            Return Nothing
        Else
            Return fabrica.new_instance(toDictionary(sRow))
        End If
    End Function

    Private Function toDictionary(row As DataGridViewRow) As Dictionary(Of String, Object)
        Dim diccionario As New Dictionary(Of String, Object)
        Dim cells = row.Cells()
        For Each nombre In Me.column_names
            diccionario.Add(nombre, cells(nombre).Value())
        Next
        Return diccionario
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
            Me.CurrentCell = Me.Rows(index).Cells(visible_col_name)
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

    Private Sub GrillaGenerica_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        '
        ' Uso este evento porque no hay un evento MinimumSizeChanged.
        '
        execute_resize()
    End Sub
End Class
