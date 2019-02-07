Public Class BlondeDyeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have blonde hair!")
        Dim c As Integer = Int(Rnd() * 75) + 180
        p.haircolor = Color.FromArgb(p.haircolor.A, c, c - 25, 0)
        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
