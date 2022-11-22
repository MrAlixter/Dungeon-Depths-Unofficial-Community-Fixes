Public Class Orange
    Inherits Food

    Public Const ITEM_NAME As String = "Orange"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 385
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 30
        setCalories(15)

        '|Description|
        setDesc("An normal orange-colored... orange." & DDUtils.RNRN &
                "+15 Stamina")
    End Sub
End Class
