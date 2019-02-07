Public Class BSEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        If p.pClass.name = "Magic Girl" Then
            Game.pushLblEvent("Your form prevents you from being altered!")
            Exit Sub
        End If
        If p.breastSize > 0 Then
            p.bs()
            If Transformation.canBeTFed(p) Then
                p.pState.save(p)
            End If
            Game.pushLblEvent("You breasts squeeze painfully . . .")
        Else
            Game.pushLblEvent("Nothing happens")
        End If
        p.createP()
    End Sub
End Class
