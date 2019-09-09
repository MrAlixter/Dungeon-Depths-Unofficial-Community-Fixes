Public Class Statue
    Public pos As Point
    Dim name, desc As String
    Sub New(ByRef m As NPC)
        pos = m.pos
        name = m.name.Split()(0)
        If m.GetType() Is GetType(Monster) Then
            desc = "This " & name & " has been turned to stone."
        ElseIf m.GetType() Is GetType(MiniBoss) Then
            If m.name = "Marissa the Enchantress" Then
                desc = "Marissa, once a powerful sorceress, is now little more than a lawn decoration."
            ElseIf m.name = "Targax the Brutal" Then
                desc = "Even Targax's ability to reflect spells was not enough to prevent him from his stony fate."
            End If
        ElseIf m.GetType().IsSubclassOf(GetType(ShopNPC)) Then
            desc = "The " & name & " has been turned to stone."
        ElseIf m.GetType() Is GetType(Boss) Then

        End If
    End Sub
    Sub New(ByRef p As Player)
        pos = p.pos
        name = p.name
        desc = "Your old body, turned to stone. Looking at it fills you with nostalgia."
    End Sub
    Sub New(ByVal s As String)
        Dim buffer = s.Split("*")

        pos = New Point(CInt(buffer(0)), CInt(buffer(1)))
        name = buffer(2)
        desc = buffer(3)
    End Sub

    Sub examine()
        Game.pushLstLog(desc)
        Game.pushLblEvent(desc)
    End Sub

    Overrides Function toString() As String
        Return pos.X & "*" & pos.Y & "*" & name & "*" & desc
    End Function
End Class
