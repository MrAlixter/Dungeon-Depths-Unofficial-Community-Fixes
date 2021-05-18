Public Class WillCharm
    Inherits Item

    Sub New()
        setName("Will_Charm")
        setDesc("A charm that slightly boosts your speed.")
        id = 152
        tier = 3
        usable = true
        count = 0
        value = 1750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base WILL!")

        p.will += 5
        p.perks(perk.wcharmsused) += 1
        p.UIupdate()
        count -= 1
    End Sub
End Class
