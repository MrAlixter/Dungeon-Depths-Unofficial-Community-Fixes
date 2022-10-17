Public Class ValkyrieTransform
    Inherits pClass
    Sub New()
        MyBase.New(1, 1.5, 0.5, 1.5, 0.75, 1.5, "Valkyrie​")
        MyBase.revertPassage = "As you sheath your flaming blade, its fire fades to embers and you return to your original form. Well, until you should need its power again, at least."
    End Sub


    Public Overrides Sub revert()
        MyBase.revert()
        If Game.cboxSpec.SelectedItem = "Helix Slash" Then
            Game.cboxSpec.Items.Insert(0, "-- Select --")
            Game.cboxSpec.SelectedIndex = 0
        End If
        Do While Game.player1.knownSpecials.Contains("Helix Slash")
            Game.player1.knownSpecials.Remove("Helix Slash")
        Loop
        TextEvent.pushLog("Helix Slash special forgotten!")
    End Sub
End Class
