Public Class BlondePotion
    'BlondePotions give the player blonde hair
    Inherits MysteryPotion
    Sub New()
        MyBase.setRealName("Blonde_Dye")
        MyBase.setDesc("A weird looking potion")
        id = 25
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(25) = "Blonde_Dye"
        Game.pushLblEvent("You now have blonde hair!")
        Dim c As Integer = Int(Rnd() * 155) + 100
        p.haircolor = Color.FromArgb(p.haircolor.A, c, c - 35, 0)
            p.createP()
            If Not Game.player.perks("polymorphed") > -1 And Not Game.player.title.Equals("Magic Girl") Then
                Game.player.pState.save(Game.player)
            End If
    End Sub
End Class
