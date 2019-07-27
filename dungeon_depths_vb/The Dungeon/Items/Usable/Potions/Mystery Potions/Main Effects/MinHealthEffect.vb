Public Class MinHealthEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & vbCrLf

        p.health += 45 / p.getMaxHealth
        If p.health > 1 Then p.health = 1
        out += "+45 health."

        Game.pushLblEvent(out)
    End Sub
End Class
