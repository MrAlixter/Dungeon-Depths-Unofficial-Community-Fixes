Public Class BSEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.breastSize > 0 Then
            p.bs()
            p.savePState()
            Game.pushLblEvent("You breasts squeeze uncomfortably...")
        Else
            Game.pushLblEvent("Nothing happens")
        End If
        p.drawPort()
    End Sub


    Public Overrides Function getEffectDesc()
        Return "Breast shrinking effect"
    End Function
End Class
