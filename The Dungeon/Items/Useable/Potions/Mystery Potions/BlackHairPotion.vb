Public Class BlackHairPotion
    Inherits Potion
    'BlackHairPotions change hair color to black
    Sub New()
        MyBase.setRealName("Black_Hair_Potion")
        MyBase.setDesc("A strange looking potion")
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(26) = "Black_Hair_Potion"
        If p.iArrInd(1).Item1 < 5 Or (p.iArrInd(1).Item1 = 7 And p.sexBool) Then
            Game.pushLblEvent("You now have black hair!")
            p.haircolor = Color.FromArgb(p.haircolor.A, 20, 20, 20)
            p.createP()
            If Not Game.player.perks(5) Or Not Game.player.title.Equals("Magic Girl") Then
                Game.player.pState.save(Game.player)
            End If
        Else
            Game.pushLblEvent("Your hair color doesn't change!")
        End If
    End Sub
End Class
