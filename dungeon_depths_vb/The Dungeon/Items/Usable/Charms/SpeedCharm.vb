Public Class SpeedCharm
    Inherits Item

    Sub New()
        setName("Speed_Charm")
        setDesc("A charm that slightly boosts your speed.")
        id = 52
        tier = 3
        usable = true
        count = 0
        value = 1750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You use the " & getName() & ". +5 base SPD!")

        p.speed += 5
        p.perks(perk.scharmsused) += 1
        p.UIupdate()
        count -= 1
    End Sub
End Class
