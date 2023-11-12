Public Class BadRations
    Inherits Food

    Public Const ITEM_NAME As String = "Bad_Ration"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 424
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 12
        setCalories(-9)

        '|Description|
        setDesc("A pouch of- probably better not to eat this one..." & DDUtils.RNRN &
                "-9 Stamina")
    End Sub
End Class
