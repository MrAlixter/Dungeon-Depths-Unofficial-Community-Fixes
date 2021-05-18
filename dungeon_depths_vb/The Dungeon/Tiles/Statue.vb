Public Class Statue
    Public pos As Point
    Public name, desc As String
    Public isRuby As Boolean = False
    Sub New(ByVal p As Point, ByVal n As String, ByVal d As String)
        pos = p
        name = n
        desc = d
    End Sub
    Sub New(ByRef m As NPC)
        pos = m.pos
        name = m.name.Split()(0)
        If m.GetType() Is GetType(Monster) Then
            desc = "This " & name & " has been turned to stone."
        ElseIf m.GetType().IsSubclassOf(GetType(MiniBoss)) Then
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
    Sub New(ByRef p As Player, Optional ByVal r As Boolean = False)
        pos = p.pos
        name = p.name
        desc = "Your old body, turned to stone. Looking at it fills you with nostalgia."


        isRuby = r
    End Sub
    Sub New(ByVal s As String)
        Dim buffer = s.Split("*")

        pos = New Point(CInt(buffer(0)), CInt(buffer(1)))
        name = buffer(2)
        desc = buffer(3)
        isRuby = buffer(4)
    End Sub

    Sub examine()
        If name = "seventailsstatue" Then
            Dim m As SevenTails = MiniBoss.miniBossFactory(7)

            'adds the miniboss to combat queues
            Monster.targetRoute(m)
            Game.toCombat(m)

            Game.pushLblCombatEvent(("The golden statue comes to life, and " & m.getName() & " attacks!"))
            Game.pushLstLog(("The golden statue comes to life, and " & m.getName() & " attacks!"))

            Game.player1.perks(perk.seventailsstage) = 1

            pos = New Point(-1, -1)
            Game.drawBoard()
        Else
            Game.pushLstLog(desc)
            Game.pushLblEvent(desc)
        End If
    End Sub

    Overrides Function toString() As String
        Return pos.X & "*" & pos.Y & "*" & name & "*" & desc & "*" & isRuby
    End Function
End Class
