Public Class PotionOfPanties
    Inherits Item

    Public Const ITEM_NAME As String = "Potion_of_Panties"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 454
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 125

        '|Description|
        setDesc("A sparkly potion for testing the inanimate transformation system.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        p.inanimateTF(Nothing, PinkPantiesPLR.ITEM_NAME, False)

        TextEvent.pushAndLog("You drink the " & getName() & ", and collapse to the ground in a file of fabric.")

        p.die()
        count -= 1
    End Sub
End Class
