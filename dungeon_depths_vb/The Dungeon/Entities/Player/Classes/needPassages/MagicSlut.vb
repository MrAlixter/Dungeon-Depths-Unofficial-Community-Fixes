Public Class MagicSlut
    Inherits pClass
    Sub New()
        MyBase.New(0.9, 0.5, 2.1, 1.0, 1.1, 0.5, "Magical Slut")
        MyBase.revertPassage = "As you stow your wand, the glow engulfing it fades and you return to your original form. Well, until you should be called on again, at least."
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()

        Game.player1.forgetSpell("Heartblast Starcannon")
    End Sub
End Class
