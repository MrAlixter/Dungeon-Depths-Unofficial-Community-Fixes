Public Class SpeedCharm
    Inherits Item

    Sub New()
        MyBase.setName("Speed_Charm")
        MyBase.setDesc("A charm that slightly boosts your speed.")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.lstLog.Items.Add("You use the " & getName() & ". +5 Speed!")
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        Game.player.sBuff += 5
        Game.player.UIupdate()
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
