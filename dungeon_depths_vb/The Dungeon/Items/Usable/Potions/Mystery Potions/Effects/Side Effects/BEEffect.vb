Public Class BEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.be()
        p.savePState()
        TextEvent.push("You breasts tingle plesently...")
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Breast enlargement effect"
    End Function
End Class
