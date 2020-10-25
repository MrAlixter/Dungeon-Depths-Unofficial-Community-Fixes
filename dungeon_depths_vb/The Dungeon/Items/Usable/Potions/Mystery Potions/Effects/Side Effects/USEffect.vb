Public Class USEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.us()
        p.savePState()
        Game.pushLblEvent("Your ass squeezes uncomfortably...")
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Ass Expansion effect"
    End Function
End Class
