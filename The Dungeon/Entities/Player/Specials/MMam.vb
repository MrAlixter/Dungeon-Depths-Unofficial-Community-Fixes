Public Class MMam
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Massive Mammaries")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        MyBase.getUser.perks("mmammaries") = 1
        Game.pushLstLog("Massive Mammaries!")
        Game.pushLblCombatEvent("Massive Mammaries!" & vbCrLf & "+80% DEF for 1 turn.")
    End Sub
End Class
