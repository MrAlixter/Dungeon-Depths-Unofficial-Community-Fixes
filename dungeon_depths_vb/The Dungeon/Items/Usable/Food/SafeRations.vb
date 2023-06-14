Public Class SafeRations
    Inherits Food

    Public Const ITEM_NAME As String = "Safe_Ration"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 407
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 120
        setCalories(18)

        '|Description|
        setDesc("A pouch of dried meat and roasted nuts.  It is safe to eat." & DDUtils.RNRN &
                "+18 Stamina")
    End Sub
End Class
