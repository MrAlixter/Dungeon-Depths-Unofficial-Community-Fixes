Public Class AntiFreeze
    Inherits Food

    Sub New()
        MyBase.setName("Antifreeze")
        MyBase.setDesc("The forbidden sport's drink.  If you drink it, you will die. -100 Hunger")
        id = 178
        tier = Nothing
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 226
        MyBase.isRandoTFAcceptable = False
        setCalories(100)
    End Sub
    Overrides Sub use()
        If Me.getUsable() = False Then Exit Sub
        Game.pushLstLog("You drink the " & getName())
        Game.player.hunger -= getCalories()
        If Game.player.hunger < 0 Then Game.player.hunger = 0
        Effect()

        count -= 1
    End Sub
    Public Overrides Sub Effect()
        Game.player.die(Nothing)
    End Sub
End Class
