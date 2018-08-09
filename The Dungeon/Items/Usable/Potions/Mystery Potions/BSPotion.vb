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
        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If
        If p.breastSize > 0 Then
            p.bs()
            If Not Polymorph.canBeTFed(Game.player) Then
                Game.player.pState.save(Game.player)
            End If
            Game.pushLblEvent("You breasts squeeze painfully . . .")
        Else
            Game.pushLblEvent("Nothing happens")
        End If
        Equipment.portraitUDate()
    End Sub
End Class
