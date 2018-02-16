Public Class BSPotion
    Inherits MysteryPotion
    'BSPotions decrease breastsize by a cup
    Sub New()
        MyBase.setRealName("Breast_Shrinking_Potion")
        MyBase.setDesc("A bizzare looking potion")
        id = 60
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(60) = "Breast_Shrinking_Potion"
        Equipment.portraitUDate()
        If p.breastSize > 0 Then
            p.bs()
            If Not Game.player.perks(5) And Not Game.player.title.Equals("Magic Girl") Then
                Game.player.pState.save(Game.player)
            End If
            Game.pushLblEvent("You breasts squeeze painfully . . .")
        Else
            Game.pushLblEvent("Nothing happens")
        End If
    End Sub
End Class
