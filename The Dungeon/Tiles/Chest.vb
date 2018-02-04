Public Class Chest
    Dim contents(59) As Integer
    Public pos As Point
    Dim tier1() As Integer = {0, 1, 2, 3, 4, 13, 14, 30, 31, 37}
    Dim tier2() As Integer = {25, 26, 27, 28, 29, 33, 34, 36, 43, 46, 48, 49, 50, 51, 52, 59}
    Dim tier3() As Integer = {11, 16, 17, 19, 22, 23, 32, 35, 44, 45, 47, 57}
    Sub New(ByVal x As Integer, ByVal y As Integer)
        pos = New Point(x, y)
        Randomize()
        Dim numC As Integer = CInt(Int(Rnd() * 5) + 1)
        For i = 0 To numC
            Dim r As Integer = Int(Rnd() * 10)
            Dim tier() As Integer = tier1
            Select Case r
                Case 0
                    tier = tier1
                Case 1
                    tier = tier1
                Case 2
                    tier = tier1
                Case 3
                    tier = tier1
                Case 4
                    tier = tier1
                Case 9
                    tier = tier3
                Case Else
                    tier = tier2
            End Select
            Dim itemID As Integer = tier(Int(Rnd() * tier.Length))
            contents(itemID) += 1
            If itemID = 43 Then contents(itemID) += Int(Rnd() * 150)
        Next
    End Sub
    Sub New(ByVal i() As Integer, ByVal p As Point)
        For ind = 0 To UBound(i)
            contents(ind) += i(ind)
        Next
        contents(43) = Int(Rnd() * 250)
        pos = p
    End Sub
    Sub New(ByVal s As String)
        Dim cArray() As String = s.Split("*")
        pos = New Point(cArray(0), cArray(1))
        For i = 2 To UBound(contents)
            contents(i) = cArray(i)
        Next
    End Sub
    Sub open()
        If Form1.player.pos <> pos Then Exit Sub
        If Not Form1.combatmode And Form1.floor >= 3 Then
            Dim mOdds As Integer
            If Form1.floor = 3 Then
                mOdds = Int(Rnd() * 2)
            Else
                mOdds = Int(Rnd() * 10)
            End If
            If mOdds = 0 Then
                Monster.createMimic(contents)
                Exit Sub
            End If
        End If
        Dim c As String = "Chest Contents: " & vbCrLf
        For i = 0 To UBound(contents)
            Form1.player.inventory.Item(i).add(contents(i))
            If contents(i) > 0 Then
                c += " " & vbCrLf & "+" & contents(i) & " " & Form1.player.inventorynames(i) & " "
            End If
        Next

        c += " " & vbCrLf & " " & vbCrLf & "Press ';' to continue."
        Form1.lblEvent.Text = c
        Form1.lblEvent.BringToFront()
        Form1.lblEvent.Location = New Point((250 * Form1.Size.Width / 688) - (Form1.lblEvent.Size.Width / 2), 65 * Form1.Size.Width / 688)
        Form1.lblEvent.Visible = True
        Form1.player.invNeedsUDate = True
        Form1.player.UIupdate()
        Form1.lstLog.Items.Add("You open a chest!")
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
    Public Overrides Function ToString() As String
        Dim output As String = ""
        output += CStr(pos.X & "*")
        output += CStr(pos.Y & "*")
        For i = 0 To UBound(contents)
            output += (contents(i) & "*")
        Next
        Return output
    End Function
    Public Sub add(ByVal i As Integer, ByVal c As Integer)
        contents(i) += c
    End Sub
End Class
