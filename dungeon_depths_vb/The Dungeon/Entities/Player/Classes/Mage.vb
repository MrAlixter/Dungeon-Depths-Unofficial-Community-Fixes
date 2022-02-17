Public Class Mage
    Inherits pClass
    Sub New()
        MyBase.New(1, 0.75, 1.5, 0.75, 1, 1.5, "Mage")
        MyBase.revertPassage = "Your mind feels slightly weaker, and your magical aptitude becomes far more average."
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level Mod 2 = 0 Then
            p.maxMana += 4
            p.mana += 4
        ElseIf level Mod 2 = 1 Then
            p.will += 4
        End If

        If Not learnSkills Then Exit Sub
        If level = 2 Then p.learnSpell("Flash Bolt")
        If level = 3 Then p.learnSpecial("Will Up")
        If level = 4 Then p.learnSpell("Firestorm")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.maxMana -= 4
        ElseIf level Mod 2 = 1 Then
            p.will -= 4
        End If
    End Sub
End Class
