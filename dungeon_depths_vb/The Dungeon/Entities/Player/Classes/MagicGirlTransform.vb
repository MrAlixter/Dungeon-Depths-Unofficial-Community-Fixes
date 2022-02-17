Public Class MagicGirlTransform
    Inherits pClass
    Sub New()
        MyBase.New(1, 0.5, 1.5, 0.75, 1.5, 1.5, "Magical Girl​")
        MyBase.revertPassage = "As you stow your wand, the glow engulfing it fades and you return to your original form. Well, until you should be called on again, at least."
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()
        Do While Game.player1.knownSpells.Contains("Heartblast Starcannon")
            Game.player1.knownSpells.Remove("Heartblast Starcannon")
        Loop
        TextEvent.pushLog("'Heartblast Starcannon' spell forgotten!")
    End Sub
End Class
