Imports System.IO

Public Class Controls
    Dim keys As List(Of TextBox) = New List(Of TextBox)
    Dim defKeys = "".ToCharArray
    Private Sub Controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DDUtils.resizeForm(Me)
        Me.CenterToParent()

        Dim sr As StreamReader
        sr = IO.File.OpenText("configs.ave")
        keys.Clear()

        'scale to the screen size
        For i = 0 To Me.Controls.Count - 1
            If Me.Controls(i).GetType Is GetType(TextBox) And Not Me.Controls(i).Name.Contains("Selection") Then
                AddHandler Me.Controls(i).KeyDown, AddressOf txtChanged
                AddHandler Me.Controls(i).Click, AddressOf txt_Click
                keys.Add(Me.Controls(i))
                Me.Controls(i).Text = sr.ReadLine
            End If
        Next

        sr.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sw As StreamWriter
        sw = File.CreateText("configs.ave")
        Dim used As New List(Of String)
        For i = 0 To keys.Count - 1
            If keys(i).Text.Equals("Invalid") Or keys(i).Text.Equals("") Then
                DDError.invalidControlKeyError()
                sw.Close()
                Exit Sub
                Exit For
            ElseIf used.Contains(keys(i).Text) Then
                DDError.controlKeyInUseError(keys(i).Text)
                sw.Close()
                Exit Sub
                Exit For
            Else
                sw.WriteLine(keys(i).Text)
                used.Add(keys(i).Text)
            End If
        Next
        sw.Close()
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Function parseKey(ByVal k As String) As String
        Select Case k
            Case "Oem1"
                Return "OemSemicolon"
            Case "OemSemicolon"
                Return "OemSemicolon"
                '----------------------------------------'
            Case "Oem5"
                Return "OemBackslash"
            Case "OemBackslash"
                Return "OemBackslash"
                '----------------------------------------'
            Case "Oem6"
                Return "OemCloseBrackets"
            Case "OemCloseBrackets"
                Return "OemCloseBrackets"
                '----------------------------------------'
            Case "Oem7"
                Return "OemQuotes"
            Case "OemQuotes"
                Return "OemQuotes"
                '----------------------------------------'
            Case "OemMinus"
                Return "OemMinus"
                '----------------------------------------'
            Case "Oemplus"
                Return "Oemplus"
                '----------------------------------------'
            Case "OemOpenBrackets"
                Return "OemOpenBrackets"
                '----------------------------------------'
            Case "Oemcomma"
                Return "Oemcomma"
                '----------------------------------------'
            Case "OemPeriod"
                Return "OemPeriod"
                '----------------------------------------'
            Case "OemQuestion"
                Return "OemQuestion"
                '----------------------------------------'
            Case "NumPad1"
                Return "NumPad1"
                '----------------------------------------'
            Case "NumPad2"
                Return "NumPad2"
                '----------------------------------------'
            Case "NumPad3"
                Return "NumPad3"
                '----------------------------------------'
            Case "NumPad4"
                Return "NumPad4"
                '----------------------------------------'
            Case "NumPad5"
                Return "NumPad5"
                '----------------------------------------'
            Case "NumPad6"
                Return "NumPad6"
                '----------------------------------------'
            Case "NumPad7"
                Return "NumPad7"
                '----------------------------------------'
            Case "NumPad8"
                Return "NumPad8"
                '----------------------------------------'
            Case "NumPad9"
                Return "NumPad9"
                '----------------------------------------'
            Case "NumPad0"
                Return "NumPad0"
                '----------------------------------------'
            Case "Back"
                Return "Back"
                '----------------------------------------'
            Case "D1"
                Return "D1"
                '----------------------------------------'
            Case "D2"
                Return "D2"
                '----------------------------------------'
            Case "D3"
                Return "D3"
                '----------------------------------------'
            Case "D4"
                Return "D4"
                '----------------------------------------'
            Case "D5"
                Return "D5"
                '----------------------------------------'
            Case "D6"
                Return "D6"
                '----------------------------------------'
            Case "D7"
                Return "D7"
                '----------------------------------------'
            Case "D8"
                Return "D8"
                '----------------------------------------'
            Case "D9"
                Return "D9"
                '----------------------------------------'
            Case "D0"
                Return "D0"
                '----------------------------------------'
            Case "Back"
                Return "Back"
            Case Else
                If "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray.Contains(k.ToString.ToUpper) And k.Length = 1 Then Return k.ToString.ToUpper
                Return "Invalid"
        End Select
    End Function
    Private Sub txtChanged(sender As TextBox, e As KeyEventArgs)
        If e.KeyData.ToString.Equals("Tab") Then
            sender.Text = "Invalid"
        End If
        sender.Text = parseKey(e.KeyData.ToString)
        e.SuppressKeyPress = True
        Label2.Select()
    End Sub
    Private Sub txt_Click(sender As TextBox, e As EventArgs)
        sender.Text = ""
    End Sub
End Class