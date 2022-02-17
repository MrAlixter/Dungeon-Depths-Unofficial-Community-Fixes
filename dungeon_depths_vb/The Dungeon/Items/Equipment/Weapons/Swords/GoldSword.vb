Public Class GoldSword
    Inherits Sword

    Public Const ITEM_NAME As String = "Gold_Sword"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 40
        tier = Nothing

        '|Item Flags|
        usable = false

        '|Stats|
        MyBase.a_boost = 35
        count = 0
        value = 3200

        '|Description|
        setDesc("A shiny sword forged from a gold alloy." & DDUtils.RNRN &
                       getStatInformation())
    End Sub
End Class
