Public Class BEPotion
    Inherits Potion
    'BEPotions increase breastsize by a cup
    Sub New()
        MyBase.setRealName("Breast_Enlarging_Potion")
        MyBase.setDesc("A off looking potion")
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Form1.player
        p.inventorynames(29) = "Breast_Enlarging_Potion"
        p.be()
        If Not Form1.player.perks(5) Or Not Form1.player.title.Equals("Magic Girl") Then
            Form1.player.pState.save(Form1.player)
        End If
        Form1.pushLblEvent("You breasts tingle plesently . . .")
    End Sub
End Class
