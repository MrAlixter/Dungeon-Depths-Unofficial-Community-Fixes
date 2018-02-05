Public Class Gold
    Inherits Item

    Sub New()
        MyBase.setName("Gold")
        MyBase.setDesc("TFng")
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 100
    End Sub
    Public Overrides Sub add(i As Integer)
        Game.player.gold += i
    End Sub
End Class
