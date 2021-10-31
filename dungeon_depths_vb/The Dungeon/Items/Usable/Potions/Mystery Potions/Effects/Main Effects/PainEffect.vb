Public Class PainEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.health -= 30 / p.getMaxHealth
        out += "-30 health."
        If p.getIntHealth < 1 Then p.setHealth(1 / p.getMaxHealth)

        TextEvent.push(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Pain effect"
    End Function
End Class
