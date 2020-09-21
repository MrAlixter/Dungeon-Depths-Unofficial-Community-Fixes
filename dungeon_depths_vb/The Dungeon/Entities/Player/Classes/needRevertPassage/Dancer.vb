Public Class Dancer
    Inherits pClass
    Sub New()
        MyBase.New(0.5, 0.7, 0.7, 0.75, 3.5, 1, "Bunny Girl")
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.will += 5
        ElseIf level Mod 2 = 1 Then
            p.speed += 5
        End If
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.will -= 5
        ElseIf level Mod 2 = 1 Then
            p.speed -= 5
        End If
    End Sub
End Class
