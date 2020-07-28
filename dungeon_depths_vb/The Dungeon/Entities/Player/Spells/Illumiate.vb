Public Class Illumiate
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Illuminate")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(3)
    End Sub
    Public Overrides Sub effect()
        Game.player1.perks(perk.lightsource) = 120
        Game.drawBoard()
    End Sub
End Class
