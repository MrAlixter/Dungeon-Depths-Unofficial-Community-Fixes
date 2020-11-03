Public Class Heal
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Heal")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(3)
    End Sub
    Public Overrides Sub effect()
        Dim hdif = 50 / Game.player1.getmaxHealth
        If Game.player1.health + hdif >= Game.player1.getmaxHealth Then hdif = 1 - Game.player1.health

        Game.player1.health += hdif

        Game.pushLstLog("You heal yourself for " & hdif * Game.player1.getmaxHealth & " health!")
        Game.pushLblEvent("You heal yourself for " & hdif * Game.player1.getmaxHealth & " health!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that heals its caster for approximately 50 HP."
    End Function
End Class
