Public Class BimbHairEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have long, straight hair!")

        p.prt.setIAInd(pInd.rearhair, 6, True, True)
        p.prt.setIAInd(pInd.midhair, 6, True, True)
        p.prt.setIAInd(pInd.fronthair, 7, True, True)

        p.drawPort()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
