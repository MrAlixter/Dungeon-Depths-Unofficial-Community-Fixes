Public Class RestorationPotion
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Restore_Potion")
        id = 14
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 275

        '|Description|
        setDesc("""Restores ye to ye original form"" says the bottle.")

    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub
        TextEvent.pushLog("You drink the " & getName())

        Dim rEffect = New RestEffect
        rEffect.apply(p)

        count -= 1
    End Sub
End Class
