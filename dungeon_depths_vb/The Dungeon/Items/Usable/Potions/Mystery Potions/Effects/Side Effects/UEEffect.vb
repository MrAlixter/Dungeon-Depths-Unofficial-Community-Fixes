Public Class UEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.ue()
        p.savePState()
        TextEvent.push("Your ass tingles pleasantly...")
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Ass Expansion effect"
    End Function
End Class
