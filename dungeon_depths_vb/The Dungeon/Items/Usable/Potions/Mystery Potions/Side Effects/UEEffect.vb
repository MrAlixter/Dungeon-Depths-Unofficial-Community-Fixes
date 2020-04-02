Public Class UEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.ue()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        Game.pushLblEvent("Your ass tingles pleasantly . . .")
        p.drawPort()
    End Sub
End Class
