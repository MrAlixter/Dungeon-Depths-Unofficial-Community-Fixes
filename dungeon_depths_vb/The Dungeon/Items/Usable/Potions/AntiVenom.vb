Public Class AntiVenom
    Inherits Item

    Sub New()
        MyBase.setName("Anti_Venom")
        MyBase.setDesc("A concoction brewed to eliminate venom from one's system.")
        id = 92
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1000
    End Sub

    Overrides Sub use()
        Game.pushLstLog("You drink the " & getName())
        Dim av As AntiVenomEffect = New AntiVenomEffect
        av.apply(Game.player)
        Game.pushLblEvent("You drink the " & getName() & ".  All venom effects have been neutralized!")
        count -= 1
    End Sub
End Class
