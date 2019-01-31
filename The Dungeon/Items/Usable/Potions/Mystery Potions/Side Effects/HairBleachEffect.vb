Public Class HairBleachEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have brighter hair!")
        Dim r = p.haircolor.R + 75
        Dim g = p.haircolor.G + 75
        Dim b = p.haircolor.B + 75

        If r > 255 Then r = 255
        If g > 255 Then g = 255
        If b > 255 Then b = 255

        p.haircolor = Color.FromArgb(p.haircolor.A, r, g, b)
        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
