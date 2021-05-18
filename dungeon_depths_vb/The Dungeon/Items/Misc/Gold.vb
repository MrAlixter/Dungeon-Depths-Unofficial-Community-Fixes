Public Class Gold
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Gold")
        id = 43
        tier = 2

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 2

        '|Description|
        setDesc("TFng")
    End Sub
    Overrides Sub use(ByRef p As Player)
        p.gold += count
        count = 0
    End Sub
    Public Overrides Sub add(i As Integer)
        Game.player1.gold += i
    End Sub
End Class
