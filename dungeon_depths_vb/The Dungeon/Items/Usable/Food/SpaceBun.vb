'Credit: [request to remain uncredited]

Public Class SpaceBun
    Inherits Food

    Public Const ITEM_NAME As String = "Space_Bun"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 392
        tier = Nothing

        '|Item Flags|
        usable = True
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 250
        setCalories(50)

        '|Description|
        setDesc("A strange pink pastry. +50 Stamina")

    End Sub

    Public Overrides Sub effect(ByRef p As Player)
        TextEvent.fpush("You feel different...")
    
        SpaceBunTF.tf(p)

        p.drawPort()
    End Sub
End Class
