Public Class HHealthEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        p.health += 100 / p.getMaxHealth
        If p.health > 1 Then p.health = 1
        p.hBuff += 25
        p.UIupdate()
        Game.pushLblEvent(out & "+100 Health," & vbCrLf & "+25 Max Health")
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Hyper health effect"
    End Function
End Class
