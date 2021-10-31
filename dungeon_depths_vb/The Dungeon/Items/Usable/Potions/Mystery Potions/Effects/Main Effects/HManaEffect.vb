Public Class HManaEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.mana += 40
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
        p.mBuff += 15
        p.UIupdate()
        TextEvent.push(out & "+40 Mana," & vbCrLf & "+15 Max Mana")
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Hyper mana effect"
    End Function
End Class
