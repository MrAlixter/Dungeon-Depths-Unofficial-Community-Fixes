Public Class BimFaceEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("Your face feels different...")

        p.setIAInd(4, 0, True, False)
        p.setIAInd(8, 6, True, True)
        p.setIAInd(9, 8, True, True)
        p.setIAInd(13, 0, True, False)
        p.setIAInd(15, 7, True, True)

        p.be()

        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
