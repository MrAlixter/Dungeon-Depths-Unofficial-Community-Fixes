Public Class Pirate
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 1.66, 0.75, 0.75, 1.0, 1.66, "Pirate")
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If level Mod 2 = 0 Then
            p.attack += 5
        ElseIf level Mod 2 = 1 Then
            p.will += 5
        End If

        If Not learnSkills Then Exit Sub

        If level = 3 Then p.learnSpecial("Crow's Nest")
        If level = 4 Then p.learnSpell("Grog Blossom")
        If level = 5 Then p.learnSpecial("Swashbuckle")
        If level = 9 Then p.learnSpell("First Sea's Scourge")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.attack -= 5
        ElseIf level Mod 2 = 1 Then
            p.will -= 5
        End If
    End Sub
End Class
