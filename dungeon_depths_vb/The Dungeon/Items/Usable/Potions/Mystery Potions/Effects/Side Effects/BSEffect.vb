Public Class BSEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.breastSize > 0 Then
            p.bs()
            p.savePState()
            TextEvent.push("You breasts squeeze uncomfortably...")
        Else
            TextEvent.push("Nothing happens")
        End If
        p.drawPort()
    End Sub


    Public Overrides Function getEffectDesc()
        Return "Breast shrinking effect"
    End Function
End Class
