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
        If Game.player.pClass.name.Equals("Soul-Lord") Then
            Game.pushLblEvent("You spike the health potion on the ground, shattering it all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & vbCrLf & vbCrLf & """Only someone who cares about their mortal vessel would bother to maintain it.")
            Game.player.UIupdate()
            Exit Sub
        End If
        Game.player.health += 100 / Game.player.getmaxHealth
        If Game.player.health > 1 Then Game.player.health = 1
        Game.player.hBuff += 25
        Game.player.UIupdate()
        Game.pushLblEvent("+100 Health," & vbCrLf & "+25 Max Health")
    End Sub
End Class
