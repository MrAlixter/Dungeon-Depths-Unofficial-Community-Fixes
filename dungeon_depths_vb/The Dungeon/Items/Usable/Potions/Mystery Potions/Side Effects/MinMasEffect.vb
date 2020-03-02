Public Class MinMasEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You get slightly more masculine...")

        p.idRouteFM(True)

        p.drawPort()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
