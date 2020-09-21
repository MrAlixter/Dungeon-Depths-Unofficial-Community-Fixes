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

        If level = 3 And Not p.knownSpecials.Contains("Dodge") Then p.knownSpecials.Add("Dodge") : Game.pushLstLog("Dodge special learned!")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.speed -= 4
        ElseIf level Mod 2 = 1 Then
            p.attack -= 4
        End If
    End Sub
End Class
