Public Class MinLustReducedEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.addLust(-25)
        out += "-25 lust."

        Game.pushLblEvent(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Minor lust reduction effect"
    End Function
End Class
