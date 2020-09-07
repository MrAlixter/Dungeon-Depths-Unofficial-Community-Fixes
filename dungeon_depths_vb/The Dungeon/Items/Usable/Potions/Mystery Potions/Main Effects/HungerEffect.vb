Public Class StaminaEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.stamina += 25
        If p.stamina < 0 Then p.stamina = 0

        out += "+25 stamina."
        Game.pushLblEvent(out)
    End Sub
End Class
