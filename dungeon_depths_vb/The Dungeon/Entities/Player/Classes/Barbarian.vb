Public Class Barbarian
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 1.75, 0.5, 1.75, 1.0, 0.75, "Barbarian")
        MyBase.revertPassage = "You feel your muscle mass decrease slightly, and your physical strength becomes far more average."
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level Mod 2 = 0 Then
            p.attack += 5
        ElseIf level Mod 2 = 1 Then
            p.defense += 5
        End If

        If Not learnSkills Then Exit Sub

    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.attack -= 5
        ElseIf level Mod 2 = 1 Then
            p.defense -= 5
        End If
    End Sub
End Class
