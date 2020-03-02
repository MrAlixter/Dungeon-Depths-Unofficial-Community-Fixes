Public Class PainEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & vbCrLf

        p.health -= 30 / p.getMaxHealth
        out += "-30 health."
        If p.getIntHealth < 1 Then p.setHealth(1 / p.getMaxHealth)

        Game.pushLblEvent(out)
    End Sub
End Class
