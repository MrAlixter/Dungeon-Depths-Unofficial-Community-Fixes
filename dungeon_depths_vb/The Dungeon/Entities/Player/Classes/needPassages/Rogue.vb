Public Class Rogue
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 1.5, 1, 0.75, 1.5, 1, "Rogue")
        MyBase.revertPassage = "Your agility decreases, and your relatively average speed leaves you feeling slugish..."
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level Mod 2 = 0 Then
            p.speed += 4
        ElseIf level Mod 2 = 1 Then
            p.attack += 4
        End If

        If Not learnSkills Then Exit Sub

        If level = 2 Then p.learnSpecial("Flash Strike")
        If level = 3 Then p.learnSpecial("Attack Up")
        If level = 4 Then p.learnSpecial("Lurk")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.speed -= 4
        ElseIf level Mod 2 = 1 Then
            p.attack -= 4
        End If
    End Sub
End Class
