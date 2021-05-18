Public Class FoxStatue
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Fox_Statue")
        id = 224
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Description|
        setDesc("A life-like statue of a fox that contains the sealed essense of Seven-Tails.")
    End Sub
End Class
