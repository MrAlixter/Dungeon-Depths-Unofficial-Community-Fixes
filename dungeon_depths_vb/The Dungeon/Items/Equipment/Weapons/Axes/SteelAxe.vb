Public Class SteelAxe
    Inherits Axe

    Public Const ITEM_NAME As String = "Steel_Battle_Axe"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 430
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        a_boost = 18
        count = 0
        value = 235

        '|Description|
        setDesc("A simple axe forged from steel." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
