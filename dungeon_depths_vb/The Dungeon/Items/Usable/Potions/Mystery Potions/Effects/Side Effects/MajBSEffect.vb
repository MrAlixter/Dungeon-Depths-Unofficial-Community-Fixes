Public Class MajBSEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.breastSize > 0 Then
            p.bs()
            p.bs()
            p.savePState()
            TextEvent.push("You breasts squeeze painfully . . .")
        Else
            TextEvent.push("Nothing happens")
        End If
        p.drawPort()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Major breast shrinking effect"
    End Function
End Class
