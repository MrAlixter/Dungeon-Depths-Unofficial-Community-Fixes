Public Class PProt
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Pillowy Protect")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()
        MyBase.getUser.perks(perk.pprot) = 1
        Game.pushLstLog("Pillowy Protect!")
        Game.pushLblCombatEvent("Pillowy Protect!" & vbCrLf & "+999% DEF for 1 turn.")
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Boosts the user's DEF by 999% for 1 turns."
    End Function
End Class
