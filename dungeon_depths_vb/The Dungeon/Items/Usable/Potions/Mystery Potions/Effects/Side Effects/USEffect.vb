Public Class USEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.us()

        TextEvent.push("Your ass squeezes uncomfortably...")
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Ass Shrinking effect"
    End Function
End Class
