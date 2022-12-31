Public Class EveryNewItem
    Inherits Item

    Public Const ITEM_NAME As String = "Every_New_Item"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 143
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Description|
        setDesc("This item is for obtaining every new item in the game, and should not be in the base game")

    End Sub
    Public Overrides Sub use(ByRef p As Player)
        For i = 331 To (p.inv.count - 1)
            p.inv.add(i, 1)
        Next

        TextEvent.push("Added one of every new item in v12.X.X!")

        count -= 1
    End Sub
End Class
