Public Class Gold
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Gold")
        id = 43
        tier = 2

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 2

        '|Description|
        MyBase.setDesc("TFng")
    End Sub
    Overrides Sub use(ByRef p As Player)
        p.gold += MyBase.count
        MyBase.count = 0
    End Sub
    Public Overrides Sub add(i As Integer)
        Game.player1.gold += i
    End Sub
End Class
