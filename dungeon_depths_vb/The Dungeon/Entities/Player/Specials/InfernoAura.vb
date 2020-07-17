Public Class InfernoAura
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Inferno Aura")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        Dim p = MyBase.getUser

        p.perks(perk.infernoa) = 5
        Game.pushLstLog("Inferno Aura!")
        Game.pushLblCombatEvent("Inferno Aura!" & vbCrLf & "+45% DEF, Reflect 30% of damage taken for 5 turns.")
    End Sub
End Class
