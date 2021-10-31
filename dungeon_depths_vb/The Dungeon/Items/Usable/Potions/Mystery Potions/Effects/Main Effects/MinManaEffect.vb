Public Class MinManaEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.mana += 10
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        out += "+10 mana."
        TextEvent.push(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Minor mana gain"
    End Function
End Class
