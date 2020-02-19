Public Class PProt
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Pillowy Protect")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        MyBase.getUser.perks("pprot") = 1
        Game.pushLstLog("Pillowy Protect!")
        Game.pushLblCombatEvent("Pillowy Protect!" & vbCrLf & "+999% DEF for 1 turn.")
    End Sub
End Class
