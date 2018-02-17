Public Class RedHairPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setRealName("Red_Hair_Potion")
        MyBase.setDesc("A curious looking potion")
        id = 27
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(27) = "Red_Hair_Potion"
        If p.iArrInd(1).Item1 < 5 Or (p.iArrInd(1).Item1 = 7 And p.sexBool) Then
            Game.pushLblEvent("You now have red hair!")
            p.haircolor = Color.FromArgb(p.haircolor.A, 255, 69, 0)
            p.createP()
            If Not Game.player.perks("polymorphed") And Not Game.player.title.Equals("Magic Girl") Then
                Game.player.pState.save(Game.player)
            End If
        Else
            Game.pushLblEvent("Your hair color doesn't change!")
        End If
    End Sub
End Class
