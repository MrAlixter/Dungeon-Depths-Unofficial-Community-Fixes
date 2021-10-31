Public Class DodgeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.perks(perk.dodge) = 1

        out += "You will dodge the next attack that comes your way (Note: This will not stack)."
        TextEvent.push(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Dodge effect"
    End Function
End Class
