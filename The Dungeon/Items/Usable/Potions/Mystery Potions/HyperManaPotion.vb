Public Class HyperManaPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setRealName("HyperMana_Potion")
        MyBase.setDesc("A puzzling looking potion")
        id = 62
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Game.player.mana += 25
        If Game.player.mana > Game.player.getmaxMana Then Game.player.mana = Game.player.getmaxMana
        Game.player.mBuff += 25
        Game.player.mana += 25
        Game.player.UIupdate()
        Game.pushLblEvent("+50 Mana," & vbCrLf & "+25 Max Mana")
    End Sub
End Class
