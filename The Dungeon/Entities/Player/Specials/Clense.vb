Public Class Clense
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Clense")
        MyBase.setUOC(True)
        setcost(15)
    End Sub
    Public Overrides Sub effect()
        Game.pushLstLog("Clense!")
        Game.pushLblCombatEvent("Clense!" & vbCrLf & "Reverts between 3 and 5 changes.")
        Dim out = Game.player.revertToPState(Int(Rnd() * 3) + 3)
        out += Game.lblEvent.Text.Split(vbCrLf)(0)
        Game.pushLblCombatEvent(out)
    End Sub
End Class
