Public Class Witch
    Inherits Mage
    Sub New()
        MyBase.New()
        MyBase.name = "Witch"
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level Mod 2 = 0 Then
            p.maxMana += 10
            p.mana += 10
        ElseIf level Mod 2 = 1 Then
            p.will += 5
        End If

        If Not learnSkills Then Exit Sub

    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.maxMana -= 10
        ElseIf level Mod 2 = 1 Then
            p.will -= 5
        End If
    End Sub
End Class
