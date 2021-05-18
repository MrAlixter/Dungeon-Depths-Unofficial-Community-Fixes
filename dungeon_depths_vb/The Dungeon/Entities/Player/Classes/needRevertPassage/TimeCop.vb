Public Class TimeCop
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 1.0, 1.0, 0.75, 1.5, 1.5, "Time Cop")
        MyBase.revertPassage = ""
    End Sub
    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If level Mod 2 = 0 Then
            p.will += 4
        ElseIf level Mod 2 = 1 Then
            p.speed += 4
        End If

        If Not learnSkills Then Exit Sub

        If level = 4 And Not p.knownSpells.Contains("Summon Battery") Then p.knownSpells.Add("Summon Battery") : Game.pushLstLog("Summon Battery spell learned!")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.will -= 4
        ElseIf level Mod 2 = 1 Then
            p.speed -= 4
        End If
    End Sub
End Class
