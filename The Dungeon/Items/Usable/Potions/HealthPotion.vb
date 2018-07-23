Public Class HealthPotion
    Inherits Item

    Sub New()
        MyBase.setName("Health_Potion")
        MyBase.setDesc("A normal, everyday health potion. +75 Health")
        id = 2
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You drink the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Game.player.health += 75 / Game.player.getmaxHealth
        If Game.player.health > 1 Then Game.player.health = 1
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
