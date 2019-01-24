Public Class RestEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & vbCrLf

        out += Game.player.revertToSState(Int(Rnd() * 5) + 3)

        Game.pushLblEvent(out)
    End Sub
End Class
