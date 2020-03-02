Public Class GalaxyDyeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have galactic hair!")


        p.prt.haircolor = Color.FromArgb(p.prt.haircolor.A, 127, 77, 157)

        p.prt.setIAInd(pInd.rearhair, 26, True, True)
        p.prt.setIAInd(pInd.midhair, 29, True, True)
        p.prt.setIAInd(pInd.fronthair, 27, True, True)

        p.drawPort()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
