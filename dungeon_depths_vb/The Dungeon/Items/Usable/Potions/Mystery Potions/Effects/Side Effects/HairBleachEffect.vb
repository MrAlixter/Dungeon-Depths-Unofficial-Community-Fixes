Public Class HairBleachEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have brighter hair!")
        Dim r = p.prt.haircolor.R + 75
        Dim g = p.prt.haircolor.G + 75
        Dim b = p.prt.haircolor.B + 75

        If r > 255 Then r = 255
        If g > 255 Then g = 255
        If b > 255 Then b = 255

        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, r, g, b)
        p.drawPort()
        p.savePState()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Hair brightening effect"
    End Function
End Class
