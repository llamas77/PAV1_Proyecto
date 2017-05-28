Imports PAV1_Proyecto

Public Class GrillaGenerica
    Inherits DataGridView
    Implements ObjetoGrilla

    '
    ' La GrillaGenerica lee una lista de campos y cambia su estructura para poder
    ' mostrarlos. El usuario solo puede seleccionar un objeto (y no mas). 
    ' Esta grilla no permite la modificacion de los objetos.
    '

    Dim fabrica As ObjectFactory
    Dim column_ids As New List(Of String)
    Dim visible_col_name As String

    Public Sub New(columnas As List(Of Campo), fabrica As ObjectFactory)
        ' - - - Configuracion por defecto - - -
        AllowUserToAddRows = False
        AllowUserToDeleteRows = False
        AllowUserToResizeRows = False
        AllowUserToResizeColumns = False
        ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        MultiSelect = False
        AutoSize = False
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Me.ReadOnly = True
        SelectionMode = DataGridViewSelectionMode.FullRowSelect
        RowHeadersVisible = False
        BackgroundColor = System.Drawing.Color.White
        StandardTab = True ' Indica que la tecla TABULADOR mueve el foco al siguiente elemento.
        MinimumSize = New Size(10, 10)
        Size = New Size(10, 10)
        ScrollBars = ScrollBars.Vertical
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

    Public Sub recargar(valores As List(Of ObjetoVO)) Implements ObjetoGrilla.recargar
        ' Vacia toda la grilla y la carga de nuevo con los elementos indicados.
        ' Guarda el indice del elemento seleccionado y lo reestablece despues.
        Dim index = vaciar()
        For Each valor As ObjetoVO In valores
            add_row(valor.toDictionary())
        Next
        set_index(index)
        execute_resize()
    End Sub

    Private Sub add_row(datos As Dictionary(Of String, Object))
        Dim i = Me.Rows.Add()
        For Each nombre In column_ids
            If datos.ContainsKey(nombre) Then ' Si el diccionario tiene un formato incorrecto cargara en blanco.
                Me.Rows(i).Cells(nombre).Value = datos(nombre)
            End If
        Next
    End Sub

    Private Sub add_column(campo As Campo)
        ' Añade una columna formateada segun lo que especifica el campo.
        column_ids.Add(campo._id)
        Dim col As New DataGridViewTextBoxColumn
        col.Name = campo._id
        col.DataPropertyName = campo._id
        col.HeaderText = campo._name
        col.Visible = campo._visible
        Me.Columns.Add(col)
    End Sub

    Public Function get_selected() As ObjetoVO Implements ObjetoGrilla.get_selected
        ' Obtiene el objeto seleccionado. Retorna Nothing si no hay seleccion.
        Dim sRow = Me.CurrentRow()
        If IsNothing(sRow) Then
            Return Nothing
        Else
            ' Para obtener el objeto se lo pide a la fabrica.
            Return fabrica.new_instance(toDictionary(sRow))
        End If
    End Function

    Private Function toDictionary(row As DataGridViewRow) As Dictionary(Of String, Object)
        ' Lee una fila pasada por parametro y la transforma a un diccionario en el que las
        ' claves son los id de cada columna.
        Dim diccionario As New Dictionary(Of String, Object)
        Dim cells = row.Cells()
        For Each nombre In Me.column_ids
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



    Private Sub GrillaGenerica_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        '
        ' Uso este evento porque no hay un evento MinimumSizeChanged.
        ' Esta para arreglar el problema del tamaño. El form generico establece el ancho minimo y despues
        ' lo ubica en la ventana causando la ejecucion del resize().
        '
        execute_resize()
    End Sub

    Public Overloads Sub Focus() Implements ObjetoGrilla.Focus
        MyBase.Focus()
    End Sub

    Public Sub add_objeto(value As ObjetoVO) Implements ObjetoGrilla.add_objeto
        Dim datos = value.toDictionary()
        Me.Rows.Add()
        Dim n_row = Me.Rows.Count - 1
        For Each nombre In column_ids
            Me.Rows(n_row).Cells(nombre).Value = datos(nombre)
        Next
        execute_resize()
    End Sub

    Public Sub delete_selected() Implements ObjetoGrilla.delete_selected
        Dim sRow = Me.CurrentRow()
        If Not IsNothing(sRow) Then
            Me.Rows.Remove(sRow)
            execute_resize()
        End If
    End Sub

    Public Function get_all() As List(Of ObjetoVO) Implements ObjetoGrilla.get_all
        ' Obtiene el objeto seleccionado. Retorna Nothing si no hay seleccion.
        Dim objetos As New List(Of ObjetoVO)

        If Me.RowCount > 0 Then
            For Each sRow In Me.Rows
                objetos.Add(fabrica.new_instance(toDictionary(sRow)))
            Next
        End If

        Return objetos
    End Function

    Private Sub execute_resize()
        '
        ' AutoSize Manual para corregir el bug del espacio en blanco a la derecha.
        ' Cambia el ancho del objeto para mostrar lo necesario. Si es menos que el mínimo
        ' permitido, alarga la ultima columna.
        '

        Dim width As Integer = 0
        For Each columna In Me.column_ids
            If Columns(columna).Visible Then
                Columns(columna).Width = Columns(columna).GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, True)
                width += Columns(columna).Width
            End If
        Next
        Me.Width = width + 3
        If width < MinimumSize.Width Then
            If visible_col_name IsNot Nothing Then ' Todavia no hay ninguna columna visible
                Columns(visible_col_name).Width += MinimumSize.Width - width - 3
            End If
        End If
        If VerticalScrollBar.Visible And visible_col_name IsNot Nothing Then
            Columns(visible_col_name).Width -= VerticalScrollBar.Size.Width
        End If
    End Sub

End Class
