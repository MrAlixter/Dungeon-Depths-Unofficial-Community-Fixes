Public Class RedDyeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have red hair!")
        Dim r As Integer = Int(Rnd() * 100) + 155
        p.haircolor = Color.FromArgb(p.haircolor.A, r, 69, 0)
        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
