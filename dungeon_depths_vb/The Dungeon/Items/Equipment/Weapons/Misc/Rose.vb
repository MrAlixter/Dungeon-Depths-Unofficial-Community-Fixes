Public Class Rose
    Inherits Weapon

    Public Const ITEM_NAME As String = "Rose"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 381
        tier = 2

        '|Item Flags|
        usable = False
        npc_drop_only = True

        '|Stats|
        a_boost = 0
        count = 0
        value = 340

        '|Description|
        setDesc("A small red flower with an iconic thorny stem.  Pretty, but not much of a weapon...")
    End Sub
    Overrides Function attack(ByRef p As Player, ByRef m As Entity) As Integer
        Return -1
    End Function
End Class
