Public Class CAttackCharm
    Inherits Item

    Sub New()
        MyBase.setName("Attack_Charm​")
        MyBase.setDesc("A charm that slightly boosts your attack.  There is a subtle red glow surrounding this charm.")
        id = 200
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 500
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base ATK!")

        p.attack += 5
        p.UIupdate()

        If Not p.pForm.name.Equals("Minotaur Bull") And Not p.perks(perk.cowbell) > -1 And (Int(Rnd() * 2) = 0 Or Game.noRNG) Then
            p.ongoingTFs.Add(New MinoMTF())
            Game.pushLstLog("You've been afflicted wth the curse of the bull!")
        End If

        count -= 1
    End Sub
End Class
