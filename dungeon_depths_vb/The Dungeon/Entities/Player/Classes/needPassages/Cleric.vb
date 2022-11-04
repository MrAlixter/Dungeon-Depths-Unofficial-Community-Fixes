Public Class Cleric
    Inherits pClass
    Sub New()
        MyBase.New(1.5, 0.5, 1.5, 1, 1, 1, "Cleric")
        MyBase.revertPassage = "Your mind feels slightly weaker, and your magical aptitude becomes far more average."
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If level Mod 2 = 0 Then
            p.maxHealth += 8
        ElseIf level Mod 2 = 1 Then
            p.maxMana += 4
            p.mana += 4
        End If

        If Not learnSkills Then Exit Sub
        If level = 2 Then p.learnSpell("Flash Heal")
        If level = 3 Then p.learnSpell("Benediction")
        If level = 4 Then p.learnSpell("Smite")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.maxHealth -= 8
        ElseIf level Mod 2 = 1 Then
            p.maxMana -= 4
        End If
    End Sub
End Class
