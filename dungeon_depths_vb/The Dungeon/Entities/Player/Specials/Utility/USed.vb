Public Class USed
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Charm")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        MyBase.getTarget.isStunned = True
        MyBase.getTarget.stunct = 2
        Game.pushLstLog("Charm!")
        Game.pushLblCombatEvent("Charm!" & vbCrLf & "Stuns enemy for 3 turns.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Stuns its target for 3 turns."
    End Function
End Class
