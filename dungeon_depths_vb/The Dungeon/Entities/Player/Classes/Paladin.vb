Public Class Paladin
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 1.0, 0.75, 1.75, 0.5, 1.75, "Paladin")
        revertPassage = "Your muscle mass and your focus both decrease slightly, and you unconsciously relax your stance..."
        transformPassage = "Your muscle mass and your focus both increase slightly, and you adopt a defensive stance..."
    End Sub
    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level Mod 2 = 0 Then
            p.will += 5
        ElseIf level Mod 2 = 1 Then
            p.defense += 5
        End If

        If Not learnSkills Then Exit Sub

    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.will -= 5
        ElseIf level Mod 2 = 1 Then
            p.defense -= 5
        End If
    End Sub

End Class
