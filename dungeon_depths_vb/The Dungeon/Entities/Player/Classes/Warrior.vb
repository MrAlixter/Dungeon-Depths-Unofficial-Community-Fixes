Public Class Warrior
    Inherits pClass
    Sub New()
        MyBase.New(1, 1.5, 0.75, 1.5, 0.75, 1, "Warrior")
        MyBase.revertPassage = "You feel your muscle mass decrease slightly, and your physical strength becomes far more average."
    End Sub

    Public Overrides Sub onLVLUp(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.attack += 4
        ElseIf level Mod 2 = 1 Then
            p.defense += 4
        End If

        If level = 3 And Not p.knownSpecials.Contains("Rapid Fire Jabs") Then p.knownSpecials.Add("Rapid Fire Jabs") : Game.pushLstLog("Rapid Fire Jabs special learned!")
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
      
        If level Mod 2 = 0 Then
            p.attack -= 4
        ElseIf level Mod 2 = 1 Then
            p.defense -= 4
        End If

        If level = 3 And p.knownSpecials.Contains("Rapid Fire Jabs") Then p.knownSpecials.Remove("Rapid Fire Jabs") : Game.pushLstLog("Rapid Fire Jabs special forgotten!")
    End Sub
End Class
