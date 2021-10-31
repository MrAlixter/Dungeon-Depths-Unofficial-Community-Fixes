Public Class VialOfFire
    Inherits Item
    Sub New()
        '|ID Info|
        setName("Vial_of_Fire")
        id = 205
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = True

        '|Stats|
        count = 0
        value = 154

        '|Description|
        setDesc("A glass bottle somehow filled with an eternally burning flame.  It hurts to hold...")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        TextEvent.pushLog("You apply the " & getName())
        TextEvent.push("You crack open the bottle of flames, and pour its content all over yourself.  Somewhat unsuprisingly, you immediately catch fire...")

        p.perks(perk.burn) = 6

        count -= 1
    End Sub
End Class
