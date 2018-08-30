Public Class HealthCharm
    Inherits Item

    Sub New()
        MyBase.setName("Health_Charm")
        MyBase.setDesc("A charm that slightly boosts your health.")
        id = 48
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You use the " & getName() & ". +10 base health!")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Game.player.hBuff += 10
        Game.player.health += 10 / Game.player.getmaxHealth()
        If Game.player.health > 1 Then Game.player.health = 1
        Game.player.UIupdate()
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
