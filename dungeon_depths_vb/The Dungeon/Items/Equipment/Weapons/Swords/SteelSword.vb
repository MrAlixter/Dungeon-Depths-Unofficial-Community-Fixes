Public Class SteelSword
    Inherits Sword

    Public Const ITEM_NAME As String = "Steel_Sword"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 6
        tier = Nothing

        '|Item Flags|
        usable = false

        '|Stats|
        MyBase.a_boost = 17
        count = 0
        value = 235

        '|Description|
        setDesc("A simple sword forged from steel." & DDUtils.RNRN &
                       getStatInformation())
    End Sub
End Class
