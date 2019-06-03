Public Class AmazonWeak
    Inherits pClass
    Sub New()
        MyBase.New(1, 1.1, 0.1, 1, 1.1, 2.0, "Amazon")
        MyBase.revertPassage = ""
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
