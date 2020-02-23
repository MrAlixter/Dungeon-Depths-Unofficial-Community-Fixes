Public Class BEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.be()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        Game.pushLblEvent("You breasts tingle plesently . . .")
        p.drawPort()
    End Sub
End Class
