Public Class Tulip
    Inherits Weapon

    Public Const ITEM_NAME As String = "Tulip"

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
        setDesc("A small purple flower with an iconic petal shape.  Pretty, but not much of a weapon...")
    End Sub
    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Return -1
    End Function
End Class
