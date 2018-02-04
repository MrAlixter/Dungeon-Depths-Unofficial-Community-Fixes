Public Class MasculinePotion
    Inherits Potion
    Sub New()
        MyBase.setRealName("Masculine_Potion")
        MyBase.setDesc("A chancy looking potion")
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Form1.player
        p.inventorynames(59) = "Masculine_Potion"
        If p.sexBool Then
            p.tg2()
            Form1.pushLblEvent("You are now a Man!")
        Else
            Form1.pushLblEvent("Nothing happened!")
        End If
        If Not Form1.player.perks(5) Or Not Form1.player.title.Equals("Magic Girl") Then
            Form1.player.pState.save(Form1.player)
        End If
    End Sub
End Class
