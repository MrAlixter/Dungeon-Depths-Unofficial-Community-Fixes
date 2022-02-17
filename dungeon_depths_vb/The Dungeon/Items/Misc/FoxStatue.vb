Public Class FoxStatue
    Inherits Item

    Public Const ITEM_NAME As String = "Fox_Statue"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 224
        tier = Nothing

        '|Item Flags|
        usable = false
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Description|
        setDesc("A life-like statue of a fox that contains the sealed essense of Seven-Tails.")
    End Sub
End Class
