Public Class BSPotion
    Inherits Potion
    'BSPotions decrease breastsize by a cup
    Sub New()
        MyBase.setRealName("Breast_Shrinking_Potion")
        MyBase.setDesc("A bizzare looking potion")
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(60) = "Breast_Shrinking_Potion"
        p.bs()
        If Not Game.player.perks(5) Or Not Game.player.title.Equals("Magic Girl") Then
            Game.player.pState.save(Game.player)
        End If
        Game.pushLblEvent("You breasts squeeze painfully . . .")
    End Sub
End Class
