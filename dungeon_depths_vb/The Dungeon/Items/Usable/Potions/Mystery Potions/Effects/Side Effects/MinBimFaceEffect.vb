Public Class MinBimFaceEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("Your face feels different...")

        p.prt.setIAInd(pInd.mouth, 6, True, True)
        p.prt.setIAInd(pInd.eyes, 8, True, True)

        p.drawPort()
      p.savePState()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Minor facial bimbofication effect"
    End Function
End Class
