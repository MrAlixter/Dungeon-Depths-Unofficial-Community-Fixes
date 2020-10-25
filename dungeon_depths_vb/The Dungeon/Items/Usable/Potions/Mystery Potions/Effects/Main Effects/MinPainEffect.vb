Public Class MinPainEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.health -= 10 / p.getMaxHealth
        out += "-10 health."
        If p.getIntHealth < 1 Then p.setHealth(1 / p.getMaxHealth)

        Game.pushLblEvent(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Minor pain effect"
    End Function
End Class
