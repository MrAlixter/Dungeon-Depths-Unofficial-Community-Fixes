Public Class Crowsnest
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Crow's Nest")
        MyBase.setUOC(True)
        MyBase.setcost(9)
    End Sub
    Public Overrides Sub effect()
        Game.player1.perks(perk.lightsource) = 480
        Game.drawBoard()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Increases its user's range of vison for 480 turns."
    End Function
End Class
