Public Class MagicGirl
    Inherits pClass
    Sub New()
        MyBase.New(1, 0.3, 2.44, 0.75, 2.44, 2.44, "Magical Girl")
        MyBase.revertPassage = "As you stow your wand, the glow engulfing it fades and you return to your original form. Well, until you should be called on again, at least."
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()

        Game.player1.forgetSpell("Heartblast Starcannon")
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level Mod 2 = 0 Then
            p.speed += 5
        ElseIf level Mod 2 = 1 Then
            p.maxMana += 5
        End If

        If Not learnSkills Then Exit Sub

    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.speed -= 5
        ElseIf level Mod 2 = 1 Then
            p.maxMana -= 5
        End If
    End Sub
End Class
