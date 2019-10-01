Public Class MajBEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.be()
        p.be()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        Game.pushLblEvent("You breasts tingle plesently . . .")
        p.createP()
    End Sub
End Class
