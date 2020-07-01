Public Class GemOfProg
    Inherits Item
    Sub New()
        MyBase.setName("Vial_of_Fire")
        MyBase.setDesc("A glass bottle filled with actual, magically fueled fire.  It hurts to hold...")
        id = 205
        tier = Nothing
        isMonsterDrop = True
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 154
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        Game.pushLstLog("You apply the " & getName())
        Game.pushLblEvent("You crack open the bottle of flames, and pour its content all over yourself.  Somewhat unsuprisingly, you immediately catch fire...")

        p.perks(perk.burn) = 6

        count -= 1
    End Sub
End Class
