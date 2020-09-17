Public Class Mage
    Inherits pClass
    Sub New()
        MyBase.New(1, 0.75, 1.5, 0.75, 1, 1.5, "Mage")
        MyBase.revertPassage = "Your mind feels slightly weaker, and your magical aptitude becomes far more average."
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.maxMana += 10
            p.mana += 10
        ElseIf level Mod 2 = 1 Then
            p.will += 5
        End If

        If level = 3 And Not p.knownSpells.Contains("Super Fireball") Then p.knownSpells.Add("Super Fireball") : Game.pushLstLog("Super Fireball spell learned!")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.maxMana -= 10
        ElseIf level Mod 2 = 1 Then
            p.will -= 5
        End If

        If level = 3 And p.knownSpells.Contains("Super Fireball") Then p.knownSpells.Remove("Super Fireball") : Game.pushLstLog("Super Fireball spell forgotten!")
    End Sub
End Class
