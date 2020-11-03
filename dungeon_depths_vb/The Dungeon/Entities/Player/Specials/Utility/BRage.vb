Public Class BRage
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Berserker Rage")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        MyBase.getUser.perks(perk.brage) = 2
        Game.pushLstLog("BERSERKER RAGE!")
        Game.pushLblCombatEvent("BERSERKER RAGE!" & vbCrLf & "+50% ATK, -25% DEF for 2 turns.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Signifigantly boosts its user's ATK while reducing DEF for 2 turns."
    End Function
End Class
