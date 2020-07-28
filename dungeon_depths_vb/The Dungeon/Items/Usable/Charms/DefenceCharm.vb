Public Class defenseCharm
    Inherits Item

    Sub New()
        MyBase.setName("defense_Charm")
        MyBase.setDesc("A charm that slightly boosts your defense.")
        id = 51
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base DEF!")

        p.defense += 5
        p.UIupdate()
        count -= 1
    End Sub
End Class
