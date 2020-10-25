Public Class ManaEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.mana += 25
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        out += "+25 mana."
        Game.pushLblEvent(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Mana gain"
    End Function
End Class
