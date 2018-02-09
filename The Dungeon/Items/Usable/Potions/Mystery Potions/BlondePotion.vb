Public Class BlondePotion
    'BlondePotions give the player blonde hair
    Inherits MysteryPotion
    Sub New()
        MyBase.setRealName("Blonde_Potion")
        MyBase.setDesc("A weird looking potion")
        id = 25
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(25) = "Blonde_Potion"
        If p.iArrInd(1).Item1 < 5 Or (p.iArrInd(1).Item1 = 7 And p.sexBool) Then
            Game.pushLblEvent("You now have blonde hair!")
            p.haircolor = Color.FromArgb(p.haircolor.A, 255, 215, 0)
            p.createP()
            If Not Game.player.perks(5) And Not Game.player.title.Equals("Magic Girl") Then
                Game.player.pState.save(Game.player)
            End If
        Else
            Game.pushLblEvent("Your hair color doesn't change!")
        End If
    End Sub
End Class
