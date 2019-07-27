Public Class BlindEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & vbCrLf

        If p.perks("blind") = -1 Then
            p.ongoingTFs.Add(New Blindness)
            p.update()
            Game.zoom()
            out += "You are now temporarily blind!"
        Else
            out += "You are still temporarily blind!"
        End If

        Game.pushLblEvent(out)
    End Sub
End Class
