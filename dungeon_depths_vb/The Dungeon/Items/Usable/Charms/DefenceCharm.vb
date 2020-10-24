Public Class defenseCharm
    Inherits Item

    Sub New()
        MyBase.setName("Defense_Charm")
        MyBase.setDesc("A charm that slightly boosts your defense.")
        id = 51
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base DEF!")

        p.defense += 5
        p.UIupdate()
        p.perks(perk.dcharmsused) += 1
        count -= 1
    End Sub
End Class
