Public Class WillCharm
    Inherits Item

    Sub New()
        MyBase.setName("Will_Charm")
        MyBase.setDesc("A charm that slightly boosts your speed.")
        id = 152
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base WIL!")

        Game.player.will += 5
        Game.player.UIupdate()
        count -= 1
    End Sub
    Overrides Sub discard()
        Game.pushLstLog("You drop the " & getName())

        count -= 1
    End Sub
End Class
