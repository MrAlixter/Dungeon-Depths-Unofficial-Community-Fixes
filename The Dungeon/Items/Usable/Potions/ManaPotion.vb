Public Class ManaPotion
    Inherits Item

    Sub New()
        MyBase.setName("Mana_Potion")
        MyBase.setDesc("A normal, everyday mana potion.")
        id = 13
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 150
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You drink the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Game.player.mana += 25
        If Game.player.mana > Game.player.getmaxMana Then Game.player.mana = Game.player.getmaxMana
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
