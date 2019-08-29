Public Class BimbNameEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You suddenly seem to have some trouble remembering your name, before it becomes clear again.  Weird.")

        Polymorph.giveRNDBimName(p)
        p.pClass = p.classes("Bimbo")
        If game.mDun.numCurrFloor < 6 Then p.pImage = Game.picPlayerB.BackgroundImage Else p.pImage = Game.picBimbof.BackgroundImage
        p.TextColor = Color.HotPink

        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
