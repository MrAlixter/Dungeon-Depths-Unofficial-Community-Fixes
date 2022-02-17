Public Class PlatinumAxe
    Inherits Axe

    Public Const ITEM_NAME As String = "Platinum_Axe"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 255
        tier = Nothing

        '|Item Flags|
        usable = false
        droppable = False

        '|Stats|
        a_boost = 45
        s_boost = -2
        count = 0
        value = 5000

        '|Description|
        setDesc("A glistening, jeweled axe forged for superb slashers." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
