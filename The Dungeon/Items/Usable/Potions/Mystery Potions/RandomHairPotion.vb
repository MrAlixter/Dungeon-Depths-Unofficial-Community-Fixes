Public Class RandomHairPotion
    Inherits MysteryPotion
    'BlackHairPotions change hair color to black
    Sub New()
        MyBase.setRealName("Random_Hair_Dye")
        MyBase.setDesc("A strange looking potion")
        id = 26
        tier = 2
        MyBase.value = 300
    End Sub
    Public Overrides Sub effect()
        Dim p As Player = Game.player
        p.inventorynames(26) = "Random_Hair_Dye"
        Game.pushLblEvent("You now have randomly colored hair!")

        p.haircolor = Color.FromArgb(255, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100)
        p.createP()
        If transformation.canbeTFed(Game.player) Then
            Game.player.pState.save(Game.player)
        End If
    End Sub
End Class
