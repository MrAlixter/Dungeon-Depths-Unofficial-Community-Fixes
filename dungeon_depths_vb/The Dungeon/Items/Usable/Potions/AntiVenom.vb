Public Class AntiVenom
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Anti_Venom")
        id = 92
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1000

        '|Description|
        setDesc("A concoction brewed to eliminate venom from one's system.")

    End Sub

    Overrides Sub use(ByRef p As Player)
        Game.pushLstLog("You drink the " & getName())
        Dim av As AntiVenomEffect = New AntiVenomEffect
        av.apply(p)
        Game.pushLblEvent("You drink the " & getName() & ".  All venom effects have been neutralized!")
        count -= 1
    End Sub
End Class
