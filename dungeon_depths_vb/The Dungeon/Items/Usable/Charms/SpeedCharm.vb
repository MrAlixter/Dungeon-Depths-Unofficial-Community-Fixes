Public Class SpeedCharm
    Inherits Item

    Sub New()
        MyBase.setName("Speed_Charm")
        MyBase.setDesc("A charm that slightly boosts your speed.")
        id = 52
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1750
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You use the " & getName() & ". +5 base SPD!")

        p.speed += 5
        p.perks(perk.scharmsused) += 1
        p.UIupdate()
        count -= 1
    End Sub
End Class
