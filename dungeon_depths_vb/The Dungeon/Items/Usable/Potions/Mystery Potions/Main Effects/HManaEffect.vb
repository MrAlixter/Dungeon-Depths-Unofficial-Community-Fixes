Public Class HManaEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & vbCrLf

        p.mana += 25
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana
        p.mBuff += 15
        p.UIupdate()
        Game.pushLblEvent(out & "+25 Mana," & vbCrLf & "+15 Max Mana")
    End Sub
End Class
