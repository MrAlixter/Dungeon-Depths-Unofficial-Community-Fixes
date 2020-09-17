Public Class AttackCharm
    Inherits Item
    'AttackCharms are useable items that permenantly boost player attack by 2
    Sub New()
        MyBase.setName("Attack_Charm")
        MyBase.setDesc("A charm that slightly boosts your attack.")
        id = 50
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base ATK!")

        p.attack += 5
        p.UIupdate()
        p.perks(perk.acharmsused) += 1
        count -= 1
    End Sub
End Class
