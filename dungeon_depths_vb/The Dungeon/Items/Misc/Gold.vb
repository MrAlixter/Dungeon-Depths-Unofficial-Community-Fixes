Public Class Gold
    Inherits Item

    Sub New()
        MyBase.setName("Gold")
        MyBase.setDesc("TFng")
        id = 43
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 2

        MyBase.isRandoTFAcceptable = False
    End Sub
    Overrides Sub use()
        Game.player.gold += MyBase.count
        MyBase.count = 0
    End Sub
    Public Overrides Sub add(i As Integer)
        Game.player.gold += i
    End Sub
End Class
