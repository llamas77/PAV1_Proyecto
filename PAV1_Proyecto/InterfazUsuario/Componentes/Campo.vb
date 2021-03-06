﻿Public Class Campo
    Implements Validable

    Enum MaskType
        texto
        telefono
        celular
        porcentaje
        fecha
        cuit
        email
        comboBox
        campo ' Por lo general este tipo de mascaras trabaja con un diccionario de datos.
        controlYGrilla
        comboYGrilla
    End Enum

    ' Propiedades obligatorias.
    Public Property _id As String
    Public Property _name As String

    ' Propiedades opcionales.
    Public Property _visible As Boolean
    Public Property _unique As Boolean ' Usado en Listas/Grillas. Si es True el objeto no se puede repetir en otra fila.
    Public Property _maskType As MaskType
    Public Property _campo As ObjetoCampo ' Cuando se quiere definir un campo especifico.
    Public Property _objetoDAO As ObjetoDAO ' El objeto que sera pasado a un ComboBox.

    ' Propiedades de interfaz Validable
    Public Property _required As Boolean Implements Validable._required
    Public Property _min_lenght As Integer Implements Validable._min_lenght
    Public Property _max_lenght As Integer Implements Validable._max_lenght
    Public Property _numeric As Boolean Implements Validable._numeric

    <Obsolete("Este método no debe seguirse usando. En su lugar cargar las propiedades con With al crear el objeto.")>
    Public Sub New(id As String, name As String,
        Optional visible As Boolean = True,
        Optional maskType As MaskType = MaskType.texto,
        Optional required As Boolean = False,
        Optional min_lenght As Integer = 0,
        Optional maxLenght As Integer = 0,
        Optional numeric As Boolean = False)
        _id = id
        _name = name
        _visible = visible
        _maskType = maskType
        _required = required
        _min_lenght = min_lenght
        _max_lenght = maxLenght
        _numeric = numeric
    End Sub

    Public Sub New()
        ' Al usar este constructor se setean todas las propiedades con With.
        ' TODO: Setear valores por defecto.
        _id = Nothing
        _name = Nothing
        _visible = True
        _maskType = MaskType.texto
        _required = False
        _min_lenght = 0
        _max_lenght = 0
        _numeric = False
    End Sub

    Public Function is_valid() As Boolean Implements Validable.is_valid
        ' La clase Campo es una abstraccion. Solo almacena datos, no valida.
        Throw New NotImplementedException()
    End Function

    Public Function get_UserControl() As UserControl
        Dim control As ObjetoCampo

        If _visible Then
            Select Case _maskType
                Case MaskType.comboBox
                    control = New LabeledComboBox(_id, _name, _objetoDAO)
                Case MaskType.controlYGrilla
                    control = New ControlYGrilla(_objetoDAO.get_IU_control(), _objetoDAO.get_IU_grilla()) _
                                                With {._id = _id, ._label = _name}
                Case MaskType.comboYGrilla
                    Dim campos_aux As New List(Of Campo)
                    campos_aux.Add(New Campo With {._id = "combo", ._maskType = Campo.MaskType.comboBox,
                                               ._objetoDAO = _objetoDAO, ._required = True})
                    Dim combo = New ControlGenerico(campos_aux, _objetoDAO)
                    control = New ControlYGrilla(combo, _objetoDAO.get_IU_grilla()) _
                                                With {._id = _id, ._label = _name}
                Case MaskType.texto
                    control = New LabeledTextBox With {._id = _id, ._label = _name}
                Case MaskType.campo
                    _campo._id = _id
                    _campo._label = _name
                    control = _campo
                Case Else
                    control = New LabeledMaskedTextBox With {
                        ._id = _id,
                        ._label = _name,
                        ._mask = _maskType}
            End Select
        Else
            control = New InvisibleControl(_id, Nothing)
        End If

        If TypeOf control Is Validable Then
            With DirectCast(control, Validable) ' Evita guardar el Cast en una variable.
                ._max_lenght = _max_lenght
                ._min_lenght = _min_lenght
                ._numeric = _numeric
                ._required = _required
            End With
        End If

        Return control
    End Function
End Class
