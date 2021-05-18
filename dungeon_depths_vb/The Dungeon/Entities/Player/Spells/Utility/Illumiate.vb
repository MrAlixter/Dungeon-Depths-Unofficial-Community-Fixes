Public Class Illumiate
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Illuminate")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(3)
    End Sub
    Public Overrides Sub effect()
        Game.player1.perks(perk.lightsource) = 480
        Game.drawBoard()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 utility spell that causes its user to glow for 480 turns."
    End Function
End Class
