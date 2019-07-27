Public Class MinManaEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & vbCrLf

        p.mana += 10
        If p.mana > p.getMaxMana Then p.mana = p.getMaxMana

        out += "+10 mana."
        Game.pushLblEvent(out)
    End Sub
End Class
