Public Class MinStaminaEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.stamina += 15
        If p.stamina < 0 Then p.stamina = 0

        out += "+15 Stamina."
        Game.pushLblEvent(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Minor stamina gain"
    End Function
End Class
