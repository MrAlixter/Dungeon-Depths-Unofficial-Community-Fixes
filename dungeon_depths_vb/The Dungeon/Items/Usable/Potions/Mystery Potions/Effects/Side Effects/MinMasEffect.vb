Public Class MinMasEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        TextEvent.push("You get slightly more masculine...")

        p.idRouteFM(True)

        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Minor masculine effect"
    End Function
End Class
