Public Class MinMasEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You get slightly more masculine...")

        p.idRouteFM(True)

        p.drawPort()
       p.savePState()
    End Sub
End Class
