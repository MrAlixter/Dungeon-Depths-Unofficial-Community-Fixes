Public Class ManaCharm
    Inherits Item

    Sub New()
        MyBase.setName("Mana_Charm")
        MyBase.setDesc("A charm that slightly boosts your mana.")
        id = 49
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base mana!")
        
        Game.player.maxMana += 5
        Game.player.mana += 5
        If Game.player.mana > Game.player.getMaxMana Then Game.player.mana = Game.player.getMaxMana
        Game.player.UIupdate()
        count -= 1
    End Sub
End Class
