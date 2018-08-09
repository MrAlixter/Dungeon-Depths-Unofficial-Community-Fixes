Public Class BEPotion
    Inherits MysteryPotion
    'BEPotions increase breastsize by a cup
    Sub New()
        MyBase.setRealName("Breast_Enlarging_Potion")
        MyBase.setDesc("A off looking potion")
        id = 29
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(29) = "Breast_Enlarging_Potion"
        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If
        p.be()
        If Not Polymorph.canBeTFed(Game.player) Then
            Game.player.pState.save(Game.player)
        End If
        Game.pushLblEvent("You breasts tingle plesently . . .")
        Equipment.portraitUDate()
    End Sub
End Class
