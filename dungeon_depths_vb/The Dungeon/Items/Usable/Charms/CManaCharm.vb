Public Class CManaCharm
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Mana_Charm​")
        id = 198
        tier = 4

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 500

        '|Description|
        setDesc("A charm that slightly boosts your maximum mana.  There is a subtle red glow surrounding this charm.")

    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You use the " & getName() & ". +5 MAX MANA!")

        p.maxMana += 5
        p.mana += 5
        p.UIupdate()
        p.perks(perk.mcharmsused) += 1

        If Not p.perks(perk.coscale) > -1 And (Int(Rnd() * 2) = 0 Or Settings.active(setting.norng)) Then
            p.ongoingTFs.add(New BroodmotherTF(5, 15, 2.0, True))
            p.perks(perk.coscale) = 1
            TextEvent.pushLog("You've been afflicted wth the curse of scales!")
        End If

        count -= 1
    End Sub
End Class
