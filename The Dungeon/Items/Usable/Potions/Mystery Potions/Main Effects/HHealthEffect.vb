Public Class HHealthEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Dim out = Game.lblEvent.Text.Split(vbCrLf)(0) & vbCrLf & vbCrLf
        If p.pClass.name.Equals("Soul-Lord") Then
            Game.pushLblEvent("You spike the health potion on the ground, shattering it all over the dungeon floor.  As you go back to your buisness, you muse on how cowardly healing is." & vbCrLf & vbCrLf & """Only someone who cares about their mortal vessel would bother to maintain it.")
            p.UIupdate()
            Exit Sub
        End If
        p.health += 100 / p.getMaxHealth
        If p.health > 1 Then p.health = 1
        p.hBuff += 25
        p.UIupdate()
        Game.pushLblEvent(out & "+100 Health," & vbCrLf & "+25 Max Health")
    End Sub
End Class
