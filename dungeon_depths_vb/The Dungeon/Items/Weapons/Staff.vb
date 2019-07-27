Public Class Staff
    Inherits Weapon

    Sub New()
        MyBase.setName("Staff")
        MyBase.setDesc("A simple staff.")
        id = 21
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.aBoost = 0
        count = 0
        value = 100
    End Sub

    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())
        
        count -= 1
    End Sub

    Public Overrides Sub onUnequip()
        MyBase.onUnequip()
        If Game.player.mana > Game.player.getMaxMana Then Game.player.mana = Game.player.getMaxMana
    End Sub
End Class
