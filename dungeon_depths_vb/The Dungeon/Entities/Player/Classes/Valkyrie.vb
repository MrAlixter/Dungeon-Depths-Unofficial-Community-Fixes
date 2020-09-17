Public Class Valkyrie
    Inherits pClass
    Sub New()
        MyBase.New(0.77, 2.0, 0.5, 1.2, 1.77, 1.5, "Valkyrie")
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
        Game.pushLstLog("Helix Slash special forgotten!")
    End Sub
End Class
