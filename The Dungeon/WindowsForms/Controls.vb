Imports System.IO

Public Class Controls
    Dim keys As List(Of TextBox) = New List(Of TextBox)
    Dim defKeys = "".ToCharArray
    Dim allKeysRaw As List(Of Char) = "1234567890-=qwertyuiop[]\asdfghjkl;'zxcvbnm,./".ToUpper.ToCharArray.ToList
    Dim allKeys As List(Of String) = New List(Of String)
    Private Sub Controls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sr As StreamReader
        sr = IO.File.OpenText("configs.ave")
        allKeys.Clear()
        For i = 0 To allKeysRaw.Count - 1
            allKeys.Add(parseKey(allKeysRaw(i)))
        Next
        keys.Clear()
        Dim newFont As Font = New System.Drawing.Font("Consolas", CInt(8 * Me.Size.Width / 227))
        For i = 0 To Me.Controls.Count - 1
            Me.Controls(i).Font = newFont
            If Me.Controls(i).GetType Is GetType(TextBox) Then
                AddHandler Me.Controls(i).KeyPress, AddressOf txtChanged
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
        Dim useable = allKeys
        For i = 0 To keys.Count - 1
            If keys(i).Text.Equals("Invalid") Then
                sw.WriteLine(useable(0))
                used.Add(useable(0))
                useable.RemoveAt(0)
            ElseIf used.Contains(keys(i).Text) Then
                sw.WriteLine(useable(0))
                used.Add(useable(0))
                useable.RemoveAt(0)
            Else
                sw.WriteLine(keys(i).Text)
                used.Add(keys(i).Text)
                useable.RemoveAt(useable.IndexOf(keys(i).Text))
            End If
        Next
        sw.Close()
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Function parseKey(ByVal k As Char) As String
        Select Case k
            Case "-"
                Return "OemMinus"
            Case "="
                Return "OemPlus"
            Case "["
                Return "OemOpenBrackets"
            Case "]"
                Return "OemCloseBrackets"
            Case "\"
                Return "OemBackslash"
            Case ";"
                Return "OemSemicolon"
            Case "'"
                Return "OemQuotes"
            Case ","
                Return "OemComma"
            Case "."
                Return "OemPeriod"
            Case "/"
                Return "OemQuestion"
            Case Else
                If "1234567890".ToCharArray.Contains(k) Then Return "Oem" + k.ToString
                If "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray.Contains(k.ToString.ToUpper) Then Return k.ToString.ToUpper
                Return "Invalid"
        End Select
    End Function
    Private Sub txtChanged(sender As TextBox, e As KeyPressEventArgs)
        sender.Text = parseKey(e.KeyChar)
        Label1.Focus()
    End Sub
    Private Sub txt_Click(sender As TextBox, e As EventArgs)
        sender.Text = ""
    End Sub
End Class