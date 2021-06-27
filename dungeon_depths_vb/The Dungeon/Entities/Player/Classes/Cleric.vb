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
        If level = 2 And Not p.knownSpells.Contains("Flash Heal") Then p.knownSpells.Add("Flash Heal") : Game.pushLstLog("Flash Heal spell learned!")
        If level = 3 And Not p.knownSpells.Contains("Benediction") Then p.knownSpells.Add("Benediction") : Game.pushLstLog("Benediction spell learned!")
        If level = 4 And Not p.knownSpells.Contains("Smite") Then p.knownSpells.Add("Smite") : Game.pushLstLog("Smite spell learned!")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.maxHealth -= 8
        ElseIf level Mod 2 = 1 Then
            p.maxMana -= 4
        End If
    End Sub
End Class
