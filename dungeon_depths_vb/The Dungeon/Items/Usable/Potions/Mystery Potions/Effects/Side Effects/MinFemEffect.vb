Public Class MinFemEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        TextEvent.push("You get slightly more feminine...")

        p.idRouteMF(True)
        If Int(Rnd() * 2) = 0 Then p.be()
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Minor feminine effect"
    End Function
End Class
