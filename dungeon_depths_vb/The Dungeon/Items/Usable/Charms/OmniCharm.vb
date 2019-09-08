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

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.pushLblEvent("You use the " & getName() & ". +5 base ATK, DEF, SPD, WIL, Max Mana, +10 Max Health!")

        Game.player.attack += 5
        Game.player.defence += 5
        Game.player.speed += 5
        Game.player.maxMana += 5
        Game.player.will += 5
        Game.player.maxHealth += 10

        Game.player.UIupdate()
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
