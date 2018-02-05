Public Class MasculinePotion
    Inherits Potion
    Sub New()
        MyBase.setRealName("Masculine_Potion")
        MyBase.setDesc("A chancy looking potion")
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(59) = "Masculine_Potion"
        If p.sexBool Then
            p.FtM()
            Game.pushLblEvent("You are now a Man!")
        Else
            Game.pushLblEvent("Nothing happened!")
        End If
        If Not Game.player.perks(5) Or Not Game.player.title.Equals("Magic Girl") Then
            Game.player.pState.save(Game.player)
        End If
    End Sub
End Class
