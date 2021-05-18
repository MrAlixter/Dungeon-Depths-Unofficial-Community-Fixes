Public Class MBurst
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Mana Burst")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        MyBase.getUser.perks(perk.mburst) = 14
        Game.pushLstLog("MANA BURST!")
        Game.pushLblCombatEvent("MANA BURST!" & vbCrLf & "Regen Health and Mana at the cost of stamina for 60 turns.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Regen HP and MP at the cost of stamina for 60 turns."
    End Function
End Class
