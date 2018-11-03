Public Class MagicGirl
    Inherits pClass
    Sub New()
        MyBase.New(1, 0.5, 1.5, 0.75, 1.5, 1.5, "Magic Girl")
        MyBase.revertPassage = "As you stow your wand, the glow engulfing it fades and you return to your original form. Well, until you should be called on again, at least."
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()
        If Game.cboxMG.SelectedItem = "Heartblast Starcannon" Then
            Game.cboxMG.Items.Insert(0, "-- Select --")
            Game.cboxMG.SelectedIndex = 0
        End If
        Do While Game.cboxMG.Items.Contains("Heartblast Starcannon")
            Game.cboxMG.Items.Remove("Heartblast Starcannon")
        Loop
        Game.lstLog.Items.Add("'Heartblast Starcannon' spell forgotten!")
    End Sub
End Class
