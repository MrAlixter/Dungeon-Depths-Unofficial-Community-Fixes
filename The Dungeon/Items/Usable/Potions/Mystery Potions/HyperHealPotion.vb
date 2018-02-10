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
        Game.player.hBuff += 50
        Game.player.health += 50
        Game.player.UIupdate()
        Game.pushLblEvent("+150 Health," & vbCrLf & "+50 Max Health")
    End Sub
End Class
