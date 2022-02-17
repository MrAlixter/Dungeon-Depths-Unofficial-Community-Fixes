Public Class GagTrap
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.gag
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        If Game.player1.inv.getCountAt("Ball_Gag") < 1 Then Game.player1.inv.add("Ball_Gag", 1)

        EquipmentDialogBackend.equipAcce(Game.player1, "Ball_Gag", False)

        Game.player1.drawPort()
        Game.player1.savePState()
        Game.player1.UIupdate()

        Game.player1.addLust(13)

        TextEvent.push("As your step depresses the tile in front of you, a torent of magical energy surrounds you.  As it fades, you find yourself wearing a ball gag!")
    End Sub
End Class
