Public Class Rogue
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 1.5, 1, 0.75, 1.5, 1, "Rogue")
        MyBase.revertPassage = ""
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level Mod 2 = 0 Then
            p.speed += 4
        ElseIf level Mod 2 = 1 Then
            p.attack += 4
        End If

        If Not learnSkills Then Exit Sub

        If level = 2 And Not p.knownSpecials.Contains("Flash Strike") Then p.knownSpecials.Add("Flash Strike") : Game.pushLstLog("Flash Strike special learned!")
        If level = 3 And Not p.knownSpecials.Contains("Attack Up") Then p.knownSpecials.Add("Attack Up") : Game.pushLstLog("Attack Up special learned!")
        If level = 4 And Not p.knownSpecials.Contains("Lurk") Then p.knownSpecials.Add("Lurk") : Game.pushLstLog("Lurk special learned!")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.speed -= 4
        ElseIf level Mod 2 = 1 Then
            p.attack -= 4
        End If
    End Sub
End Class
