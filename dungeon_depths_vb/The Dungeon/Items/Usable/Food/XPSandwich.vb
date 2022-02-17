Public Class XPSandwich
    Inherits Food

    Public Const ITEM_NAME As String = "XP_Sandwich"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 228
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 150
        setCalories(25)

        '|Description|
        setDesc("Mmmmm, sandwich..." & DDUtils.RNRN &
                "+25 Stamina")
    End Sub

    Public Overrides Sub Effect(ByRef p As Player)
        p.addXP(500)
    End Sub
End Class
