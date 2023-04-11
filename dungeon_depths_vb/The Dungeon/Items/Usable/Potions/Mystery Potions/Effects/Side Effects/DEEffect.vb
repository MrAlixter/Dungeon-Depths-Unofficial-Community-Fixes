Public Class DEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.de()

        TextEvent.push("Your dick tingles pleasantly...")
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Dick growth effect"
    End Function
End Class
