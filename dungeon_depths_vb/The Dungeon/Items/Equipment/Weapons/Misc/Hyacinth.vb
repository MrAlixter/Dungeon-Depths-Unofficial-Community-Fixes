Public Class Hyacinth
    Inherits Weapon

    Public Const ITEM_NAME As String = "Hyacinth"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 348
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False

        '|Stats|
        a_boost = 0
        count = 0
        value = 340

        '|Description|
        setDesc("A rosy pink flower with an iconic column of petals.  Pretty, but not much of a weapon...")
    End Sub
    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Return -1
    End Function
End Class
