Public Class AntiVenomEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & vbCrLf
        Game.player1.perks("avenom") = -1
        Game.player1.perks("svenom") = -1
        out += "Venom effects neutralized!"

        Game.pushLblEvent(out)
    End Sub
End Class
