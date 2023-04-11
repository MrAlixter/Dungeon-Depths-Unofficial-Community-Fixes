Public Class NameChangeEffect
    Inherits PEffect

    Public Overrides Sub apply(ByRef p As Player)
        TextEvent.push("You suddenly seem to have some trouble remembering your name, before it becomes clear again.  Weird.")

        If p.prt.sexBool Then
            Polymorph.giveRNDFName(p)
        Else
            Polymorph.giveRNDMName(p)
        End If
    End Sub

    Public Overrides Function getEffectDesc()
        Return "Name change effect"
    End Function
End Class
