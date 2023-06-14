Public Class StickWand
    Inherits Wand

    Public Const ITEM_NAME As String = "Small_Stick"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 365
        tier = Nothing

        '|Item Flags|
        usable = False
        droppable = False

        '|Stats|
        count = 0
        value = 20

        '|Description|
        setDesc("A tiny twig.  It doesn't seem like a very good weapon.")
    End Sub
    Public Overrides Sub spell(ByRef p As Player, ByRef m As Entity)
        Dim dmg As Integer = 1
        Dim d31 = Int(Rnd() * 3)
        Dim d32 = Int(Rnd() * 3)

        p.hit(dmg + d31 + d32, m)
    End Sub
End Class
