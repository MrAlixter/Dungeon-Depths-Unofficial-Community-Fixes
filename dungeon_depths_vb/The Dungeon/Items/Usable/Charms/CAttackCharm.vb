Public Class CAttackCharm
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Attack_Charm​")
        id = 200
        tier = 4

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 750

        '|Description|

        setDesc("A charm that slightly boosts your attack.  There is a subtle red glow surrounding this charm.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If Not p.formName.Equals("Minotaur Bull") And Not p.perks(perk.cowbell) > -1 And (Int(Rnd() * 2) <> 0 Or Settings.active(setting.norng)) Then
            p.ongoingTFs.add(New MinoMTF())
            TextEvent.pushLog("You use the " & getName() & ".  You've been afflicted wth the curse of the bull!")
        Else
            p.attack += 5
            p.UIupdate()
            p.perks(perk.acharmsused) += 1

            TextEvent.pushLog("You use the " & getName() & ". +5 base ATK!")
        End If

        count -= 1
    End Sub
End Class
