Public Class BimFaceEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("Your face feels different...")

        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 6, True, True)
        p.prt.setIAInd(pInd.eyes, 8, True, True)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 7, True, True)

        p.be()

        p.drawPort()
        p.savePState()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Facial bimbofication effect"
    End Function
End Class
