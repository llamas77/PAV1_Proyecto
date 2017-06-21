Public Class frm_abm_generico
    '
    ' Formulario capaz de obtener los controles necesarios a partir de un ObjetoDAO.
    ' El formulario permite ejecutar acciones de Consulta, Inserción, Modificacion y Borrado.
    '

    Dim ctrl_objeto As ObjetoCtrl
    Dim grilla_objeto As ObjetoGrilla
    Dim DAO_objeto As ObjetoDAO

    Public Sub New(objetoDAO As ObjetoDAO)
        ' Toma un control y una grilla de objetoDAO y la utiliza para generar el formulario.
        Me.New(objetoDAO.get_IU_control, objetoDAO.get_IU_grilla, objetoDAO)
    End Sub

    Public Sub New(ctrl_objeto As ObjetoCtrl, grilla_objeto As ObjetoGrilla, objetoDAO As ObjetoDAO)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        KeyPreview = True ' Para poder capturar las teclas presionadas.
        ' TODO: Refactor a esta funcion. Reacomodar.
        Me.ctrl_objeto = ctrl_objeto
        Me.grilla_objeto = grilla_objeto
        Me.DAO_objeto = objetoDAO

        Dim control As Control
        ' Define la ubicacion y el TabIndex del control y lo agrega a los controles del formulario,
        ' al agregarlo aparece en pantalla.
        control = ctrl_objeto
        control.Location = New Point(Me.Padding.Left, Me.Padding.Top) ' Esquina superior izquierda.
        control.TabIndex = 1
        Me.Controls.Add(control)
        control.Focus() ' Para que empiece con el foco en el control.
        ' Ubica el boton actualizar de forma relativa al control.
        btn_actualizar.Location = New Point(control.Location.X + control.Size.Width + 15,
                                            control.Location.Y + control.Size.Height - btn_actualizar.Size.Height - 5)

        ' Ubicar grilla del objeto.
        control = grilla_objeto
        Dim min_width As Integer = btn_actualizar.Location.X + btn_actualizar.Size.Width + 15
        min_width = IIf(min_width < 360, 360, min_width) ' Controla que el ancho minimo alcance para acomodar los botones.
        ' AVISO HARDCODING: 380 es el resultado de sumar el ancho de cada boton + un margen de 20 px a la izquierda para cada boton.
        ' excepto el primero. Si se cambia el ancho de los botones, recalcular.
        control.MinimumSize = New Size(min_width, 150)
        control.Location = New Point(Me.Padding.Left, btn_actualizar.Location.Y + btn_actualizar.Size.Height + 15)
        control.TabIndex = 3
        Me.Controls.Add(control)

        ' Posiciona los otros botones de forma relativa a la grilla y entre ellos.
        Dim point = New Point(control.Location.X, control.Location.Y + control.Size.Height + 15)
        btn_modificar.Location = point
        point.X += btn_modificar.Size.Width + 20
        btn_eliminar.Location = point
        point.X = control.Location.X + control.Width - btn_salir.Width
        btn_salir.Location = point
        point.X -= btn_cancelar.Size.Width + 20
        btn_cancelar.Location = point

    End Sub

    Private Sub frm_abm_generico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar el formulario se carga la grilla con todos los objetos.
        grilla_objeto.recargar(DAO_objeto.all())
    End Sub

    Private Sub btn_actualizar_Click(sender As Object, e As EventArgs) Handles btn_actualizar.Click
        actualizar()
    End Sub

    Private Sub actualizar()
        ' Ejecuta la validacion en el control, si el objeto es valido consulta si ya esta almacenado
        ' (exists) y decide si inserta o modifica.
        If ctrl_objeto.is_valid() Then
            Dim objeto = ctrl_objeto._objeto

            If DAO_objeto.exists(objeto) Then
                DAO_objeto.update(objeto)
            Else
                DAO_objeto.insert(objeto)
            End If
            ctrl_objeto.reset()
            btn_actualizar.Text = "Agregar"
            ' Recarga la grilla para que se vea el objeto modificado.
            grilla_objeto.recargar(DAO_objeto.all())
            ctrl_objeto.Focus()
        Else
            MsgBox("Alguno/s de los valores ingresados no es/son válido/s.", MsgBoxStyle.Exclamation, "Aviso")
        End If
    End Sub

    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        modificar()
    End Sub

    Private Sub modificar()
        ' Obtiene el Objeto seleccionado en la grilla y se lo pasa al control para que lo muestre.
        Dim objeto As ObjetoVO = grilla_objeto.get_selected()
        If IsNothing(objeto) Then
            MsgBox("No hay nada seleccionado en la tabla.", MsgBoxStyle.MsgBoxHelp, "Aviso")
        Else
            ctrl_objeto._objeto = objeto
            btn_actualizar.Text = "Actualizar"
            ctrl_objeto.Focus()
        End If
    End Sub

    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        eliminar()
    End Sub

    Private Sub eliminar()
        ' Obtiene el control seleccionado en la grilla, pide confirmacion y lo borra.
        Dim objeto = grilla_objeto.get_selected()
        If IsNothing(objeto) Then
            MsgBox("No hay nada seleccionado en la tabla.", MsgBoxStyle.MsgBoxHelp, "Aviso")
        Else
            If MessageBox.Show("Esta seguro de borrar: " + objeto.toString(),
                               "Importante", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                DAO_objeto.delete(objeto)
                grilla_objeto.recargar(DAO_objeto.all())
                grilla_objeto.Focus()
            End If
        End If
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        ' Limpia el control y mueve el foco para agregar un nuevo objeto.
        ctrl_objeto.reset()
        ctrl_objeto.Focus()
        btn_actualizar.Text = "Agregar"
    End Sub

    Private Sub btn_salir_Click(sender As Object, e As EventArgs) Handles btn_salir.Click
        Me.Close()
    End Sub

    Private Sub frm_abm_generico_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
            Case Keys.Enter
                Dim control As Control
                control = grilla_objeto
                If control.Focused Then
                    modificar()
                    ' Lo dejo comentado porque puede producir comportamiento inesperado.
                    'Else
                    '    control = ctrl_objeto
                    '    If control.Focused Then
                    '        actualizar()
                    '    End If
                End If
            Case Keys.Delete
                Dim control As Control
                control = grilla_objeto
                If control.Focused Then
                    eliminar()
                End If
        End Select
    End Sub

End Class