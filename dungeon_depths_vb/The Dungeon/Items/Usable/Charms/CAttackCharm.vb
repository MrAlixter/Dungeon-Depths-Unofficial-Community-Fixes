Public Class CAttackCharm
    Inherits Item

    Sub New()
        MyBase.setName("Attack_Charm​")
        MyBase.setDesc("A charm that slightly boosts your attack.  There is a subtle red glow surrounding this charm.")
        id = 200
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If Not p.formName.Equals("Minotaur Bull") And Not p.perks(perk.cowbell) > -1 And (Int(Rnd() * 2) <> 0 Or Game.noRNG) Then
            p.ongoingTFs.add(New MinoMTF())
            Game.pushLstLog("You use the " & getName() & ".  You've been afflicted wth the curse of the bull!")
        Else
            p.attack += 5
            p.UIupdate()
            p.perks(perk.acharmsused) += 1

            Game.pushLstLog("You use the " & getName() & ". +5 base ATK!")
        End If

        count -= 1
    End Sub
End Class
