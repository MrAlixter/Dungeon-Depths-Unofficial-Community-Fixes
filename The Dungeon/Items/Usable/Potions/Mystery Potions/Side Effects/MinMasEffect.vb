Public Class MinMasEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If

        Game.pushLblEvent("You get slightly more masculine...")

        p.idRouteFMHalf()

        p.createP()
        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
