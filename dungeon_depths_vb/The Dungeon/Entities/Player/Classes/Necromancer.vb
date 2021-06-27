Public Class Necromancer
    Inherits pClass
    Sub New()
        MyBase.New(1, 1.75, 1.75, 0.5, 0.75, 0.75, "Necromancer")
        MyBase.revertPassage = "Your mind feels slightly weaker, and your magical aptitude becomes far more average.  You also feel a cold chill down your spine..."
    End Sub
    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If level Mod 2 = 0 Then
            p.attack += 5
        ElseIf level Mod 2 = 1 Then
            p.maxMana += 5
            p.mana += 5
        End If

        If Not learnSkills Then Exit Sub

    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.attack -= 5
        ElseIf level Mod 2 = 1 Then
            p.maxMana -= 5
        End If
    End Sub
End Class
