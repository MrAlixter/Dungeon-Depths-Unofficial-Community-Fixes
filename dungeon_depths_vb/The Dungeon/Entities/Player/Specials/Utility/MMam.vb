Public Class MMam
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Massive Mammaries")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        MyBase.getUser.perks(perk.mmammaries) = 1
        TextEvent.pushLog("Massive Mammaries!")
        TextEvent.pushCombat("Massive Mammaries!" & vbCrLf & "+80% DEF for 1 turn.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Boosts the user's DEF by 80% for 1 turns."
    End Function
End Class
