Public Class BEEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If
        p.be()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
        Game.pushLblEvent("You breasts tingle plesently . . .")
        p.createP()
    End Sub
End Class
