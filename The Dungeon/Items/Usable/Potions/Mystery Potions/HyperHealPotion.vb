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
        Game.player.health += 100
        If Game.player.health > Game.player.getmaxHealth Then Game.player.health = Game.player.getmaxHealth
        Game.player.hBuff += 25
        Game.player.UIupdate()
        Game.pushLblEvent("+100 Health," & vbCrLf & "+25 Max Health")
    End Sub
End Class
