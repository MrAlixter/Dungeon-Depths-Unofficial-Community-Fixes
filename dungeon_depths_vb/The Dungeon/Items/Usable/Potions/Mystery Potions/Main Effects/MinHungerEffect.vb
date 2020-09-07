Public Class MinStaminaEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.stamina += 5
        If p.stamina < 0 Then p.stamina = 0

        out += "+5 Stamina."
        Game.pushLblEvent(out)
    End Sub
End Class
