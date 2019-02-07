Public Class HungerEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & vbCrLf

        p.hunger -= 25
        If p.hunger < 0 Then p.hunger = 0

        out += "-25 hunger."
        Game.pushLblEvent(out)
    End Sub
End Class
