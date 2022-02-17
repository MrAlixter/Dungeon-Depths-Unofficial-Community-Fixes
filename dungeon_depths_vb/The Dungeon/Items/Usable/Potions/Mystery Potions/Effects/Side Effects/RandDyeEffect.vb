Public Class RandDyeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        TextEvent.push("You now have randomly colored hair!")

        p.prt.haircolor = Color.FromArgb(255, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100, Int(Rnd() * 125) + 100)
        p.drawPort()

         p.savePState()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Random color dye effect"
    End Function
End Class
