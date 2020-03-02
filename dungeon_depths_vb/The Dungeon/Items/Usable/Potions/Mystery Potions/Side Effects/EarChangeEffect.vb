Public Class EarChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("Your ears feels different...")

        Dim r As Integer = 0
        While r = p.prt.iArrInd(6).Item1
            r = Int(Rnd() * 4)
        End While

        p.prt.setIAInd(6, r, True, False)

        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
