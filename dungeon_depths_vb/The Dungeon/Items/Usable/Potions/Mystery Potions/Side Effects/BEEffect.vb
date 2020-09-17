Public Class BEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        p.be()
        p.savePState()
        Game.pushLblEvent("You breasts tingle plesently . . .")
        p.drawPort()
    End Sub
End Class
