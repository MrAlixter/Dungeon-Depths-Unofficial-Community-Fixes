Public Class MajBSEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.breastSize > 0 Then
            p.bs()
            p.bs()
            p.savePState()
            Game.pushLblEvent("You breasts squeeze painfully . . .")
        Else
            Game.pushLblEvent("Nothing happens")
        End If
        p.drawPort()
    End Sub
End Class
