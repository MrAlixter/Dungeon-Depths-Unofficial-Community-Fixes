Public Class SpeedCharm
    Inherits Item

    Sub New()
        MyBase.setName("Speed_Charm")
        MyBase.setDesc("A charm that slightly boosts your speed.")
        id = 52
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base SPD!")
        
        Game.player.speed += 5
        Game.player.UIupdate()
        count -= 1
    End Sub
End Class
