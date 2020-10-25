Public Class Maid
    Inherits pClass
    Sub New()
        MyBase.New(1.75, 0.5, 0.75, 0.75, 1.75, 0.5, "Maid")
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level Mod 2 = 0 Then
            p.maxHealth += 5
        ElseIf level Mod 2 = 1 Then
            p.speed += 5
        End If

        If Not learnSkills Then Exit Sub

    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.maxHealth -= 5
        ElseIf level Mod 2 = 1 Then
            p.speed -= 5
        End If
    End Sub
End Class
