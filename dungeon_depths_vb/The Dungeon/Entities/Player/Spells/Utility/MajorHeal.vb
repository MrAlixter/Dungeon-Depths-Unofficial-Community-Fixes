Public Class MajorHeal
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        MyBase.setName("Major Heal")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(5)
    End Sub
    Public Overrides Sub effect()
        Dim hdif = 100 / Game.player1.getMaxHealth
        If Game.player1.health + hdif >= Game.player1.getmaxHealth Then hdif = 1 - Game.player1.health

        Game.player1.health += hdif

        Game.pushLogAndEvent("You heal yourself for " & hdif * Game.player1.getMaxHealth & " health!")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "A tier 1 spell that heals its caster for approximately 100 HP."
    End Function
End Class
