Public Class MajBEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.be()
        p.be()
        p.savePState()
        TextEvent.push("You breasts tingle plesently . . .")
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Major breast enlargement effect"
    End Function
End Class
