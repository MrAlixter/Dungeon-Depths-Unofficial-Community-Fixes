Public Class MinFemEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You get slightly more feminine...")

        p.idRouteMFHalf()
        If Int(Rnd() * 2) = 0 Then p.be()
        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
