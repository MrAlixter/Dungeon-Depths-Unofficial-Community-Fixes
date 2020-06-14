Public Class CManaCharm
    Inherits Item

    Sub New()
        MyBase.setName("Mana_Charm​")
        MyBase.setDesc("A charm that slightly boosts your maximum mana.  There is a subtle red glow surrounding this charm.")
        id = 198
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 500
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 MAX MANA!")

        p.maxMana += 5
        p.mana += 5
        p.UIupdate()

        If Not p.perks("coscale") > -1 And (Int(Rnd() * 2) = 0 Or Game.noRNG) Then
            p.ongoingTFs.Add(New BroodmotherTF(5, 15, 2.0, True))
            p.perks("coscale") = 1
            Game.pushLstLog("You've been afflicted wth the curse of scales!")
        End If

        count -= 1
    End Sub
End Class
