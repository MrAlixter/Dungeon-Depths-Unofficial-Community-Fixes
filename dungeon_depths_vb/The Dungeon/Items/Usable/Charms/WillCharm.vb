Public Class WillCharm
    Inherits Item

    Sub New()
        MyBase.setName("Will_Charm")
        MyBase.setDesc("A charm that slightly boosts your speed.")
        id = 152
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base WIL!")

        p.will += 5
        p.UIupdate()
        count -= 1
    End Sub
End Class
