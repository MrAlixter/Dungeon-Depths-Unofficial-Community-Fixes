Public Class WeakRestEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.player1.revertToPState(Int(Rnd() * 5) + 3)
        out += Game.lblEvent.Text.Split(vbCrLf)(0)
        TextEvent.push(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Weak minor restoration effect"
    End Function
End Class
