Public Class AttackCharm
    Inherits Item
    'AttackCharms are useable items that permenantly boost player attack by 2
    Sub New()
        setName("Attack_Charm")
        setDesc("A charm that slightly boosts your attack.")
        id = 50
        tier = 2
        usable = true
        count = 0
        value = 1750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You use the " & getName() & ". +5 base ATK!")

        p.attack += 5
        p.UIupdate()
        p.perks(perk.acharmsused) += 1
        count -= 1
    End Sub
End Class
