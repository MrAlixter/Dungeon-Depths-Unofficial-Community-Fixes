Public Class BlindEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & DDUtils.RNRN

        If p.perks(perk.blind) = -1 Then
            p.ongoingTFs.Add(New Blindness)
            p.update()
            Game.zoom()
            out += "You are now temporarily blind!"
        Else
            out += "You are still temporarily blind!"
        End If

        TextEvent.push(out)
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Blinding effect"
    End Function
End Class
