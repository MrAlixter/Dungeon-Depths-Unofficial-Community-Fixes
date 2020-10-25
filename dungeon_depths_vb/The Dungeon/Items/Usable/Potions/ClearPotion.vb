Public Class ClearPotion
    Inherits Item

    Sub New()
        MyBase.setName("Clear_Potion")
        MyBase.setDesc("Something tells you that this might just be water.  A quick sip confirms this, though you can also taste the tell-tale flavor of filtering.")
        id = 76
        tier = 1
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
    End Sub

    Overrides Sub use(ByRef p As Player)
        Game.pushLstLog("You drink the " & getName())
        Game.pushLblEvent("You drink the " & getName() & ".  -5 stamina, -15 lust!")
        Dim mseffect As MinstaminaEffect = New MinstaminaEffect
        mseffect.apply(p)
        p.addLust(-15)
        count -= 1
    End Sub
End Class
