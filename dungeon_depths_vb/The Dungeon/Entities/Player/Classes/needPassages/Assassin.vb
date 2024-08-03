Public Class Assassin
    Inherits pClass
    Sub New()
        MyBase.New(0.7, 1.5, 1, 0.7, 1.5, 1.3, "Assassin")
        MyBase.revertPassage = "Your agility decreases, and your relatively average speed leaves you feeling slugish..."
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If level Mod 2 = 0 Then
            p.speed += 4
        ElseIf level Mod 2 = 1 Then
            p.attack += 4
        End If
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.speed -= 4
        ElseIf level Mod 2 = 1 Then
            p.attack -= 4
        End If
    End Sub
End Class
