Public Class DEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.de()
        p.savePState()
        Game.pushLblEvent("Your dick tingles pleasantly . . .")
        p.drawPort()
    End Sub
End Class
