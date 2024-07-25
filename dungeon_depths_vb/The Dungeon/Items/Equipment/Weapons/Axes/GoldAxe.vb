Public Class GoldAxe
    Inherits Axe

    Public Const ITEM_NAME As String = "Gold_Battle_Axe"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 431
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 36
        count = 0
        value = 3200

        '|Description|
        setDesc("A shiny axe forged from a gold alloy." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
