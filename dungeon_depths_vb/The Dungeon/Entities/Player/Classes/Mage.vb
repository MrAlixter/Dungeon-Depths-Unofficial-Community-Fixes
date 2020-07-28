Public Class Mage
    Inherits pClass
    Sub New()
        MyBase.New(1, 0.75, 1.5, 0.75, 1, 1.5, "Mage")
        MyBase.revertPassage = "Your mind feels slightly weaker, and your magical aptitude becomes far more average."
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.maxMana += 4
            p.mana += 4
        ElseIf level Mod 2 = 1 Then
            p.will += 4
        End If
    End Sub

    Public Overrides Sub deLVL(levels As Integer, ByRef p As Player)
        For i = p.level To p.level - levels Step -1
            p.level = i
            If i Mod 2 = 0 Then
                p.maxMana -= 4
            ElseIf i Mod 2 = 1 Then
                p.will -= 4
            End If
        Next
    End Sub
End Class
