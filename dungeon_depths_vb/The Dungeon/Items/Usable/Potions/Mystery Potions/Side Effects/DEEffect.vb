Public Class DEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.de()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        Game.pushLblEvent("Your dick tingles pleasantly . . .")
        p.drawPort()
    End Sub
End Class
