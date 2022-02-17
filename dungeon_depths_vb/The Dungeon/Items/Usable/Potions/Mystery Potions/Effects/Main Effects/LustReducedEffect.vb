Public Class LustReducedEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.addLust(-50)
        out += "-50 lust."

        TextEvent.push(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Lust reduction effect"
    End Function
End Class
