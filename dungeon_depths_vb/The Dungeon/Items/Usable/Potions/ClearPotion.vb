Public Class ClearPotion
    Inherits Item

    Public Const ITEM_NAME As String = "Clear_Potion"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 76
        tier = 1

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 280

        '|Description|
        setDesc("Something tells you that this might just be water.  A quick sip confirms this, though you can also taste the tell-tale flavor of filtering.")

    End Sub

    Overrides Sub use(ByRef p As Player)
        TextEvent.pushLog("You drink the " & getName())
        TextEvent.push("You drink the " & getName() & ".  -5 stamina, -15 lust!")
        Dim mseffect As MinstaminaEffect = New MinstaminaEffect
        mseffect.apply(p)
        p.addLust(-15)
        count -= 1
    End Sub
End Class
