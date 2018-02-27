Public Class RedHairPotion
    Inherits MysteryPotion
    Sub New()
        MyBase.setRealName("Red_Hair_Dye")
        MyBase.setDesc("A curious looking potion")
        id = 27
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(27) = "Red_Hair_Dye"
        Game.pushLblEvent("You now have red hair!")
        Dim r As Integer = Int(Rnd() * 100) + 155
        p.haircolor = Color.FromArgb(p.haircolor.A, r, 69, 0)
            p.createP()
        If Not Game.player.perks("polymorphed") > -1 And Not Game.player.title.Equals("Magic Girl") Then
            Game.player.pState.save(Game.player)
        End If
    End Sub
End Class
