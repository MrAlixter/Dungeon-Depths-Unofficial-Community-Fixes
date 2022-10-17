Public Class MesmerizingSpores
    Inherits Trap

    Sub New(ByVal p As Point)
        MyBase.New(p)
        iD = tInd.gag
    End Sub

    Overrides Sub activate()
        MyBase.activate()

        Game.player1.perks(perk.mesmerized) = 75

        TextEvent.push("A puff of spores erupts from the floor around you, leaving you in a trance!")
    End Sub
End Class
