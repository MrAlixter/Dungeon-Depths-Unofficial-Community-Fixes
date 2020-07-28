Public Class Rogue
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 1.5, 1, 0.75, 1.5, 1, "Rogue")
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.speed += 4
        ElseIf level Mod 2 = 1 Then
            p.attack += 4
        End If
    End Sub

    Public Overrides Sub deLVL(levels As Integer, ByRef p As Player)
        For i = p.level To p.level - levels Step -1
            p.level = i
            If i Mod 2 = 0 Then
                p.speed -= 4
            ElseIf i Mod 2 = 1 Then
                p.attack -= 4
            End If
        Next
    End Sub
End Class
