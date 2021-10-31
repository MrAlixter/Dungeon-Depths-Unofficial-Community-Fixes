Public Class MajHealthEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.health += 120 / p.getMaxHealth
        If p.health > 1 Then p.health = 1
        out += "+120 health."

        TextEvent.push(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Major health gain"
    End Function
End Class
