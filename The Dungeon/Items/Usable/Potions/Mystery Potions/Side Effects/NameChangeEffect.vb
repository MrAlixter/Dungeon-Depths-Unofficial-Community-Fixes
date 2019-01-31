Public Class NameChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        Game.pushLblEvent("You suddenly seem to have some trouble remembering your name, before it becomes clear again.  Weird.")

        If p.sexBool Then
            Polymorph.giveRNDFName(p)
        Else
            Polymorph.giveRNDMName(p)
        End If

        If Transformation.canBeTFed(p) Then
            p.pState.save(p)
        End If
    End Sub
End Class
