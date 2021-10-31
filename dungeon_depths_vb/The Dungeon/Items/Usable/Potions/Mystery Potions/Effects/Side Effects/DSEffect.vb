Public Class DSEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.ds()
        p.savePState()
        TextEvent.push("Your dick squeezes uncomfortably...")
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Dick shrinking effect"
    End Function
End Class
