Public Class OmniCharm
    Inherits Item
    'AttackCharms are useable items that permenantly boost player attack by 2
    Sub New()
        MyBase.setName("Omni_Charm")
        MyBase.setDesc("A charm that slightly boosts all base stats.")
        id = 126
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 3700
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLblEvent("You use the " & getName() & ". +5 base ATK, DEF, SPD, WIL, Max Mana, +10 Max Health!")

        p.attack += 5
        p.defense += 5
        p.speed += 5
        p.maxMana += 5
        p.will += 5
        p.maxHealth += 10

        p.UIupdate()
        count -= 1
    End Sub
End Class
