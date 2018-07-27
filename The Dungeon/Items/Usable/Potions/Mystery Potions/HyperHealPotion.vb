Public Class HyperHealPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setRealName("HyperHeal_Potion")
        MyBase.setDesc("A vexing looking potion")
        id = 61
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Game.player.health += 100 / Game.player.getmaxHealth
        If Game.player.health > 1 Then Game.player.health = 1
        Game.player.hBuff += 25
        Game.player.UIupdate()
        Game.pushLblEvent("+100 Health," & vbCrLf & "+25 Max Health")
    End Sub
End Class
