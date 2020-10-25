Public Class AntiFreeze
    Inherits Food

    Sub New()
        '|ID Info|
        MyBase.setName("Antifreeze")
        id = 178
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 226
        setCalories(100)

        '|Description|
        MyBase.setDesc("The forbidden sport's drink.  If you drink it, you will die. " & DDUtils.RNRN & "+100 Stamina")
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
