Public Class RedDyeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        TextEvent.push("You now have red hair!")
        Dim r As Integer = Int(Rnd() * 100) + 155
        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, r, 69, 0)
        p.drawPort()
        p.savePState()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Red dye effect"
    End Function
End Class
