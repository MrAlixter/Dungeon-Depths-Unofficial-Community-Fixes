Public Class MinHungerEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & vbCrLf

        p.hunger -= 5
        If p.hunger < 0 Then p.hunger = 0

        out += "-5 hunger."
        Game.pushLblEvent(out)
    End Sub
End Class
