Public Class MinRestEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.player.revertToSState(Int(Rnd() * 4) + 1)
        out += Game.lblEvent.Text.Split(vbCrLf)(0)
        Game.pushLblEvent(out)
    End Sub
End Class
