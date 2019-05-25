Public Class Valkyrie
    Inherits pClass
    Sub New()
        MyBase.New(0.77, 1.77, 0.5, 1.2, 1.77, 1.5, "Valkyrie")
        MyBase.revertPassage = "As you sheath your flaming blade, its fire fades to embers and you return to your original form. Well, until you should need its power again, at least."
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()
        If Game.cboxSpec.SelectedItem = "Blazing Angel Strike" Then
            Game.cboxSpec.Items.Insert(0, "-- Select --")
            Game.cboxSpec.SelectedIndex = 0
        End If
        Do While Game.player.knownSpecials.Contains("Blazing Angel Strike")
            Game.player.knownSpecials.Remove("Blazing Angel Strike")
        Loop
        Game.pushLstLog("'Blazing Angel Strike' special forgotten!")
    End Sub
End Class
