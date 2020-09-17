Public Class Paladin
    Inherits pClass
    Sub New()
        MyBase.New(1, 1.5, 1.5, 1.5, 0.75, 1.5, "Paladin")
        MyBase.revertPassage = ""
    End Sub
    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player)
        If level Mod 4 = 0 Then
            p.maxMana += 4
            p.mana += 4
        ElseIf level Mod 4 = 1 Then
            p.attack += 4
        ElseIf level Mod 4 = 2 Then
            p.will += 4
        ElseIf level Mod 4 = 3 Then
            p.defense += 4
        End If
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 4 = 0 Then
            p.maxMana -= 4
        ElseIf level Mod 4 = 1 Then
            p.attack -= 4
        ElseIf level Mod 4 = 2 Then
            p.will -= 4
        ElseIf level Mod 4 = 3 Then
            p.defense -= 4
        End If
    End Sub

End Class
