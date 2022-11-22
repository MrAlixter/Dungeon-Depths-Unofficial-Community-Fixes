Public Class Battlemaiden
    Inherits pClass
    Sub New()
        MyBase.New(1.75, 1.1, 0.75, 1.0, 1.75, 0.75, "Battlemaiden")
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills As Boolean = True)
        If level Mod 2 = 0 Then
            p.maxHealth += 5
        ElseIf level Mod 2 = 1 Then
            p.speed += 5
        End If

        p.attack += 2

        p.nextLevelXp = p.nextLevelXp / 1.5

        If Not learnSkills Then Exit Sub
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.maxHealth -= 5
        ElseIf level Mod 2 = 1 Then
            p.speed -= 5
        End If

        p.attack -= 2
    End Sub
End Class
