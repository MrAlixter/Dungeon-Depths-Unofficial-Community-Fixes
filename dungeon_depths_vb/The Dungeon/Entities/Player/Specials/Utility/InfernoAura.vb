Public Class InfernoAura
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Inferno Aura")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        p.perks(perk.infernoa) = 5
        Game.pushLstLog("Inferno Aura!")
        Game.pushLblCombatEvent("Inferno Aura!" & vbCrLf & "+45% DEF, Reflect 30% of damage taken for 5 turns.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Boosts the user's DEF by 45% and reflects 30% of damage taken for 5 turns."
    End Function
End Class
