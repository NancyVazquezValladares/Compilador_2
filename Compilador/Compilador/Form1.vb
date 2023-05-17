Imports System.IO

Public Class Proyecto
    Dim matriz(10, 13) As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
    Public Sub New()
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        leerMatrizEstados("MatrizVB.csv") 'Lee la matriz desde el Debug
        leerPalabrasReservadas("Palabras_R_VisualBasic.csv") 'Ingresa las Palabras Reservadas desde el Debug
        For i = 0 To vectorPalabrasReservadas.Length - 1
            ListBox3.Items.Add(vectorPalabrasReservadas(i) + "")
        Next
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
    End Sub
    Dim vectorPalabrasReservadas(29)
    Private Sub leerPalabrasReservadas(archivo As String)
        ' MyBase.Load()
        'MATRIZ
        Dim renglon As String
        Dim lector As StreamReader = New StreamReader(archivo)
        renglon = lector.ReadLine()
        vectorPalabrasReservadas = renglon.Split(",")
        lector.Close()
    End Sub
    Private Sub leerMatrizEstados(archivo As String)
        ' MyBase.Load()
        'MATRIZ
        Dim renglon As String
        Dim datosrenglon As String()
        Dim r As Integer = 0
        Dim lector As StreamReader = New StreamReader("matriz.csv")
        While Not lector.EndOfStream
            renglon = lector.ReadLine()
            datosrenglon = renglon.Split(",")
            For c = 0 To datosrenglon.Length - 1
                matriz(r, c) = datosrenglon(c)
            Next
            r += 1
        End While
        lector.Close()
    End Sub
    Private Sub Cargar_Click(sender As Object, e As EventArgs) Handles Cargar.Click
        OpenFileDialog1.ShowDialog()
        Dim archivo
        archivo = OpenFileDialog1.FileName
        Dim fileReader As System.IO.StreamReader
        fileReader = My.Computer.FileSystem.OpenTextFileReader(archivo)
        Dim stringReader As String
        While Not (fileReader.EndOfStream)
            stringReader = fileReader.ReadLine()
            ListBox1.Items.Add(stringReader)
        End While
    End Sub
    '******************
    Dim renglon
    Dim token, PalabraSalida
    Dim Lineaz, direccion
    '******************
    Private Sub Compilar_Click(sender As Object, e As EventArgs) Handles Compilar.Click
        renglon = 0
        While (renglon < ListBox1.Items.Count) 'mientras que renglon =0 sea menor que la cantidad del listbox1 entra
            ListBox1.SelectedIndex = renglon 'al indice va inicializar en el 0
            Lineaz = ListBox1.Text 'se le agregregara a la linez
            BuscaToken()
            renglon = renglon + 1
        End While
    End Sub
    Private Sub BuscaId()
        Dim encontro = False
        Dim renglon2 = 0
        While ((encontro = False) And (renglon2 < ListBox4.Items.Count))
            If (UCase(token) = UCase(ListBox4.Text)) Then
                encontro = True
                direccion = renglon2
            End If
            renglon2 = renglon2 + 1
        End While
        If (encontro = False) Then
            ListBox4.Items.Add(token)
            direccion = ListBox4.Items.Count - 1
        End If
    End Sub
    Private Sub CntesEnteras()
        Dim encontro
        Dim renglon2
        encontro = False
        renglon2 = 0
        While ((encontro = False) And (renglon2 < ListBox6.Items.Count))
            ListBox6.SelectedIndex = renglon2
            If (UCase(token) = UCase(ListBox6.Text)) Then
                encontro = True
                direccion = renglon2
            End If
            renglon2 = renglon2 + 1
        End While
        If ((encontro = False)) Then
            ListBox6.Items.Add(token)
            direccion = ListBox6.Items.Count - 1
        End If
    End Sub
    Private Sub CntesReales()
        Dim encontro
        Dim renglon2
        encontro = False
        renglon2 = 0
        While ((encontro = False) And (renglon2 < ListBox7.Items.Count))
            ListBox7.SelectedIndex = renglon2
            If (UCase(token) = UCase(ListBox7.Text)) Then
                encontro = True
                direccion = renglon2
            End If
            renglon2 = renglon2 + 1
        End While
        If ((encontro = False)) Then
            ListBox7.Items.Add(token)
            direccion = ListBox7.Items.Count - 1
        End If
    End Sub
    Private Sub Strings()
        Dim encontro
        Dim renglon2
        encontro = False
        renglon2 = 0
        While ((encontro = False) And (renglon2 < ListBox5.Items.Count))
            ListBox5.SelectedIndex = renglon2
            If (UCase(token) = UCase(ListBox5.Text)) Then
                encontro = True
                direccion = renglon2
            End If
            renglon2 = renglon2 + 1
        End While
        If ((encontro = False)) Then
            ListBox5.Items.Add(token)
            direccion = ListBox5.Items.Count - 1
        End If
    End Sub

    '**************
    Dim ColumnaN
    Dim Posicion
    Dim Caracter
    '**************
    Public Sub BuscaToken()
        Estado = 0
        token = ""
        Posicion = 1
        While (Posicion <= Len(Lineaz)) ' mientras que la pocicsion sea menor que la longitud de linea Z 
            Caracter = Mid(Lineaz, Posicion, 1) 'extrae de una cadena el caracter indicado en la posicion indicada 
            ColumnaX()
            Estado = matriz(Estado, ColumnaN) 'caracter= cadena,inicio,#caracteres a sacar

            If (Estado >= 100) Then
                If (Len(token) > 0) Then
                    ReconocimientoToken()
                ElseIf (Len(token) = 0) Then
                    token = token + Caracter 'solo lee un caracter 
                    ReconocimientoToken()
                End If
                Estado = 0
                token = ""
            Else
                If (Estado <> 0) Then
                    token = token + Caracter 'añadir a token el caracter (h)
                End If
            End If
            Posicion = Posicion + 1
        End While
        If (Len(token) > 0) Then 'el token hola es mayor si hola=4
            Caracter = " "
            ColumnaX()
            Estado = matriz(Estado, ColumnaN)
            ReconocimientoToken()
        End If
    End Sub

    Public Sub ColumnaX()
        If Caracter >= "A" And Caracter <= "Z" Or Caracter >= "a" And Caracter <= "z" Then
            ColumnaN = 0
        ElseIf (Caracter = " " Or Caracter = "") Then
            ColumnaN = 2
            'Constantes enteras
        ElseIf (Caracter >= "0" And Caracter <= "9") Then
            ColumnaN = 1
            'Delimitadores 

        ElseIf (Caracter = "_") Then
            ColumnaN = 3
        ElseIf (Caracter = ".") Then
            ColumnaN = 4
            'Strings
        ElseIf (Caracter = ChrW(34)) Then 'Identifica el caracter especial (Comillas) asckii
            ColumnaN = 5
        ElseIf (Caracter = "#") Then
            ColumnaN = 6
        ElseIf (Caracter = "+") Then
            ColumnaN = 7
        ElseIf (Caracter = "-") Then
            ColumnaN = 8
        ElseIf (Caracter = "*") Then
            ColumnaN = 9
        ElseIf (Caracter = "/") Then
            ColumnaN = 10
        ElseIf (Caracter = ">") Then
            ColumnaN = 11
        ElseIf (Caracter = "<") Then
            ColumnaN = 12
        ElseIf (Caracter = "=") Then
            ColumnaN = 13


        End If

    End Sub
    '************************
    Dim Estado, Pr

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        ListBox7.Items.Clear()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        'Solo Exporta un solo dato del Archivo de Salida :C
        Dim dialogoGuardar As New SaveFileDialog

        If dialogoGuardar.ShowDialog = DialogResult.Cancel Then
            Return
        End If
        Dim archivo As String = dialogoGuardar.FileName
        Dim sw As StreamWriter = New StreamWriter(archivo)
        For Each item In ListBox2.Items
            If item.ToString <> "" Then
                sw.WriteLine(item.ToString()) 'Error en la linea 
            End If
            sw.Close()
        Next
    End Sub
    '************************
    Public Sub ReconocimientoToken()
        If Estado = 100 Then
            Pr = False
            BuscapalReservada()
            If Pr Then
                PalabraSalida = token + "   Pr   " + Str(direccion)
                Posicion = Posicion - 1
                token = token + Caracter
            Else
                Buscaidentificadores()
                PalabraSalida = token + " Id  " + Str(direccion)
                Posicion = Posicion - 1
            End If
        End If
        If Estado = 101 Then
            CntesEnteras()
            PalabraSalida = token + " Cnte. Entera" + Str(direccion)
            Posicion = Posicion - 1 'retrocede para volver a identificar el ultimo caracter 
        ElseIf Estado = 102 Then
            CntesReales()
            PalabraSalida = token + " Cnte. Real" + Str(direccion)
            Posicion = Posicion - 1
        End If
        If Estado = 103 Then
            token = token + Caracter 'almacena las ultimas comillas 
            Strings()
            PalabraSalida = token + " String" + Str(direccion)
        End If
        If Estado = 105 Then
            PalabraSalida = token + " C.Esp"
        ElseIf Estado = 106 Then
            PalabraSalida = token + " C.Esp"
        ElseIf Estado = 107 Then
            PalabraSalida = token + " C.Esp"
        ElseIf Estado = 108 Then
            PalabraSalida = token + " C.Esp"
            'operadores X
        ElseIf Estado = 109 Then
            PalabraSalida = token + " C.Esp"
            Posicion = Posicion - 1
        ElseIf Estado = 110 Then
            token = token + Caracter 'vacio = vacio+ ultimo caracter
            PalabraSalida = token + " C.Esp"
        ElseIf Estado = 111 Then
            token = token + Caracter
            PalabraSalida = token + " C.Esp"
        ElseIf Estado = 112 Then
            PalabraSalida = token + " C.Esp"
            Posicion = Posicion - 1
        ElseIf Estado = 113 Then
            token = token + Caracter
            PalabraSalida = token + " C.Esp"
        ElseIf Estado = 114 Then
            token = token + Caracter
            PalabraSalida = token + " C.Esp"
        End If
        ListBox2.Items.Add(PalabraSalida)
    End Sub
    Public Sub Buscaidentificadores()
        Dim encontro
        Dim renglon2
        encontro = False
        renglon2 = 0
        While ((encontro = False) And (renglon2 < ListBox4.Items.Count))
            ListBox4.SelectedIndex = renglon2
            If (UCase(token) = UCase(ListBox4.Text)) Then
                encontro = True
                direccion = renglon2
            End If
            renglon2 = renglon2 + 1
        End While
        If ((encontro = False)) Then
            ListBox4.Items.Add(token)
            direccion = ListBox4.Items.Count - 1
        End If
    End Sub
    Public Sub BuscapalReservada()
        Dim Posicion
        Posicion = 0
        direccion = -1
        While ((Pr = False) And (Posicion < vectorPalabrasReservadas.Length))
            ' p_reservada.selectindex = Posicion
            If (UCase(token) = UCase(vectorPalabrasReservadas(Posicion))) Then
                Pr = True
                direccion = Posicion 'guarda la direccion de renglon2
            End If
            Posicion += 1
        End While
    End Sub
End Class
