Public Class BimbHairEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You now have long, straight hair!")

        p.prt.setIAInd(1, 6, True, True)
        p.prt.setIAInd(5, 6, True, True)
        p.prt.setIAInd(15, 7, True, True)

        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
