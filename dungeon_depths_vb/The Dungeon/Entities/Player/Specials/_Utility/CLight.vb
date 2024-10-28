Public Class CLight
    Inherits Special
    Sub New(ByRef u As Player, ByRef t As NPC)
        MyBase.New(u, t)
        setName("Cleansing Light")
        MyBase.setUOC(False)
        MyBase.setcost(-1)
    End Sub
    Public Overrides Sub effect()

        Dim out = "Cleansing Light!  " & Game.player1.revertToSState(Int(Rnd() * 9) + 4)
        out += Game.lblEvent.Text.Split(vbCrLf)(0)
        TextEvent.push(out)

        Game.player1.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Reverts between 4 and 12 changes at random, partially restoring one to their original form."
    End Function
End Class
