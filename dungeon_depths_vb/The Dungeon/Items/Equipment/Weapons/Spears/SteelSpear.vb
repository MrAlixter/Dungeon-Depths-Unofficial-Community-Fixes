Public Class SteelSpear
    Inherits Spear

    Public Const ITEM_NAME As String = "Steel_Spear"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 156
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        MyBase.a_boost = 22
        MyBase.s_boost = -5
        count = 0
        value = 1540
        MyBase.weight = 9

        '|Description|
        setDesc("A hearty spear forged from steel.  It's more likely to hit critically than a sword, but also more likely to miss altogether." & DDUtils.RNRN &
                "Can be thrown using the ""Use"" button." & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
