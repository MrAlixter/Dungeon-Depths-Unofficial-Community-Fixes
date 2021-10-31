Public Class DefenseCharm
    Inherits Item

    Sub New()
        setName("Defense_Charm")
        setDesc("A charm that slightly boosts your defense.")
        id = 51
        tier = 3
        usable = true
        count = 0
        value = 1750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You use the " & getName() & ". +5 base DEF!")

        p.defense += 5
        p.UIupdate()
        p.perks(perk.dcharmsused) += 1
        count -= 1
    End Sub
End Class
