Public Class Warrior
    Inherits pClass
    Sub New()
        MyBase.New(1, 1.5, 0.75, 1.5, 0.75, 1, "Warrior")
        MyBase.revertPassage = "You feel your muscle mass decrease slightly, and your physical strength becomes far more average."
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If level Mod 2 = 0 Then
            p.attack += 4
        ElseIf level Mod 2 = 1 Then
            p.defense += 4
        End If

        If Not learnSkills Then Exit Sub
        If level = 2 Then p.learnSpecial("Blade Breaker")
        If level = 3 Then p.learnSpecial("Guard Up")
        If level = 4 Then p.learnSpecial("Triple Strike")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.attack -= 4
        ElseIf level Mod 2 = 1 Then
            p.defense -= 4
        End If
    End Sub
End Class
