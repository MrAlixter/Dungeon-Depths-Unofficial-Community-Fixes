Public Class AntiFreeze
    Inherits Food

    Sub New()
        MyBase.setName("Antifreeze")
        MyBase.setDesc("The forbidden sport's drink.  If you drink it, you will die. -100 stamina")
        id = 178
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 226
        MyBase.isRandoTFAcceptable = False
        setCalories(100)
    End Sub
    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You drink the " & getName())
        p.stamina += getCalories()
        If p.stamina > 100 Then p.stamina = 100
        Effect()

        count -= 1
    End Sub
    Public Overrides Sub Effect()
        Game.player1.die(Nothing)
    End Sub
End Class
