Public Class BimbNameEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You suddenly seem to have some trouble remembering your name, before it becomes clear again.  Weird.")

        p.name = Polymorph.bimboizeName(p.name)
        p.changeClass("Bimbo")
        If Game.mDun.numCurrFloor < 6 Then p.pImage = Game.picPlayerB.BackgroundImage Else p.pImage = Game.picBimbof.BackgroundImage
        p.TextColor = Color.HotPink

        p.drawPort()
        p.savePState()
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Bimbo name effect"
    End Function
End Class
