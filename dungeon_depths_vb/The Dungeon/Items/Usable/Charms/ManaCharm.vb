Public Class ManaCharm
    Inherits Item

    Sub New()
        MyBase.setName("Mana_Charm")
        MyBase.setDesc("A charm that slightly boosts your mana.")
        id = 49
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base mana!")

        p.maxMana += 5
        p.mana += 5
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
        p.perks(perk.mcharmsused) += 1
        p.UIupdate()
        count -= 1
    End Sub
End Class
