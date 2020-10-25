Public Class EarChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("Your ears feels different...")

        Dim r As Integer = 0
        While r = p.prt.iArrInd(pInd.ears).Item1
            r = Int(Rnd() * 4)
        End While

        p.prt.setIAInd(pInd.ears, r, True, False)

        p.drawPort()
        p.savePState()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Ear change effect"
    End Function
End Class
