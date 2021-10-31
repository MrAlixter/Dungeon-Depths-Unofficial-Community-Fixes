Public Class CdefenseCharm
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Defense_Charm​")
        id = 174
        tier = 4

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 750

        '|Description|
        setDesc("A charm that slightly boosts your defense.  There is a subtle red glow surrounding this charm.")

    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If Not p.perks(perk.coscale) > -1 And (Int(Rnd() * 2) <> 0 Or Game.noRNG) Then
            p.ongoingTFs.add(New BroodmotherTF(5, 15, 2.0, True))
            p.perks(perk.coscale) = 1
            TextEvent.pushLog("You use the " & getName() & ".  You've been afflicted wth the curse of scales!")
        Else
            p.defense += 5
            p.UIupdate()

            TextEvent.pushLog("You use the " & getName() & ". +5 base DEF!")
        End If

        p.perks(perk.dcharmsused) += 1

        count -= 1
    End Sub
End Class
