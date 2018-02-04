Public Class Statue
    Public pos As Point
    Dim name, desc As String
    Sub New(ByRef m As Monster)
        pos = m.pos
        name = m.name.Split()(0)
        If m.GetType() Is GetType(Monster) Then
            desc = "This " & name & " has been turned to stone."
        ElseIf m.GetType() Is GetType(MiniBoss) Then
            If m.name = "Marissa the Enchantress" Then
                desc = "Marissa, once a powerful sorceress, is now little more than a lawn decoration."
            End If
        ElseIf m.GetType() Is GetType(Boss) Then

        End If
    End Sub
    Sub New(ByRef p As Player)
        pos = p.pos
        name = p.name
        desc = "Your old body, turned to stone. Looking at it fills you with nostalgia."
    End Sub

    Sub examine()
        Form1.lstLog.Items.Add(desc)
        Form1.lstLog.TopIndex = Form1.lstLog.Items.Count - 1
    End Sub
End Class
