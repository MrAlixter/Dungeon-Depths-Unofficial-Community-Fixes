Public Class Cleanse
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        MyBase.setName("Cleanse")
        MyBase.setUOC(True)
        setcost(15)
    End Sub
    Public Overrides Sub effect()
        Game.pushLstLog("Cleanse!")
        Game.pushLblEvent("Cleanse!" & vbCrLf & "Reverts between 3 and 5 changes.")
        Dim out = Game.player1.revertToPState(Int(Rnd() * 3) + 3)
        out += Game.lblEvent.Text.Split(vbCrLf)(0)
        Game.pushLblCombatEvent(out)
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Reverts 3 to 5 of its users transformations."
    End Function
End Class
