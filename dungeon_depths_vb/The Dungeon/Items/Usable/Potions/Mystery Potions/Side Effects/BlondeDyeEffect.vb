Public Class BlondeDyeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have blonde hair!")
        Dim c As Integer = Int(Rnd() * 75) + 180
        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, c, c - 25, 0)
        p.drawPort()
        p.savePState()
    End Sub
End Class
