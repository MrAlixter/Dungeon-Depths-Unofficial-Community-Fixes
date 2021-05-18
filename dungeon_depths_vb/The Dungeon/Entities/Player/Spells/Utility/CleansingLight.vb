Public Class CleansingLight
    Inherits Spell
    Sub New(ByRef c As Player, ByRef t As NPC)
        MyBase.New(c, t)
        setName("Cleansing Light")
        MyBase.setUOC(True)
        MyBase.settier(1)
        MyBase.setcost(4)
    End Sub
    Public Overrides Sub effect()
        'Game.pushLstLog("You cast Cleansing Light!")

        Dim out = Game.player1.revertToSState(Int(Rnd() * 9) + 4)
        out += Game.lblEvent.Text.Split(vbCrLf)(0)
        Game.pushLblEvent(out)

        Game.player1.drawPort()
    End Sub

    Public Overrides Function getDesc(ByRef c As Player, ByRef t As NPC) As Object
        Return "Reverts between 4 and 12 changes at random, parially restoring one to their original form."
    End Function
End Class
