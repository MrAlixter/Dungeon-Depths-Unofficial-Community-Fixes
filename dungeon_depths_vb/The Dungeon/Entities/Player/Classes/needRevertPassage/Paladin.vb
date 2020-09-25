Public Class Paladin
    Inherits pClass
    Sub New()
        MyBase.New(1, 1.5, 1.5, 1.5, 0.75, 1.5, "Paladin")
        MyBase.revertPassage = ""
    End Sub
    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level Mod 2 = 0 Then
            p.will += 6
        ElseIf level Mod 2 = 1 Then
            p.defense += 6
        End If

        If Not learnSkills Then Exit Sub

    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.will -= 6
        ElseIf level Mod 2 = 1 Then
            p.defense -= 6
        End If
    End Sub

End Class
