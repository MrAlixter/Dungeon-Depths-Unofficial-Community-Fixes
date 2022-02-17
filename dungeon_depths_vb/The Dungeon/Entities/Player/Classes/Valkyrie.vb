Public Class Valkyrie
    Inherits pClass
    Sub New()
        MyBase.New(0.75, 2.44, 0.3, 2.44, 2.44, 1, "Valkyrie")
        MyBase.revertPassage = "As you sheath your flaming blade, its fire fades to embers and you return to your original form. Well, until you should need its power again, at least."
    End Sub

    Public Overrides Sub revert()
        MyBase.revert()
        If Game.cboxSpec.SelectedItem = "Helix Slash" Then
            Game.cboxSpec.Items.Insert(0, "-- Select --")
            Game.cboxSpec.SelectedIndex = 0
        End If
        Do While Game.player1.knownSpecials.Contains("Helix Slash")
            Game.player1.knownSpecials.Remove("Helix Slash")
        Loop
        TextEvent.pushLog("Helix Slash special forgotten!")
    End Sub

    Public Overrides Sub onLVLUp(ByVal level As Integer, ByRef p As Player, Optional learnSkills as Boolean = True)
        If level Mod 2 = 0 Then
            p.speed += 5
        ElseIf level Mod 2 = 1 Then
            p.defense += 5
        End If

        If Not learnSkills Then Exit Sub
    End Sub

    Public Overrides Sub deLVL(level As Integer, ByRef p As Player)
        If level Mod 2 = 0 Then
            p.speed -= 5
        ElseIf level Mod 2 = 1 Then
            p.defense -= 5
        End If
    End Sub
End Class
