Public Class GalaxyDyeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have galactic hair!")


        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, 127, 77, 157)

        p.prt.setIAInd(1, 26, True, True)
        p.prt.setIAInd(5, 29, True, True)
        p.prt.setIAInd(15, 27, True, True)

        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
