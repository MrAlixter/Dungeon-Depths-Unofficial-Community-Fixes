Public Class Spellbook
    Inherits Item

    Sub New()
        MyBase.setName("Spellbook")
        MyBase.setDesc("A simple, leather-bound book that likely contains something cool and magic.")
        id = 4
        tier = 2
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 500
    End Sub

    Overrides Sub use()
        Randomize()
        If Me.getUsable() = False Then Exit Sub
        Dim sName As String = "ERROR"
        Dim ct As Integer = 0
        Dim out As String = ""
        While ct < 1 Or Game.cboxMG.Items.Contains(sName)
            ct += 1
            Dim spell As Integer = CInt(Int(Rnd() * 9))
            Select Case spell
                Case 0
                    sName = "Super Fireball"
                Case 1
                    sName = "Icicle Spear"
                Case 2
                    sName = "Self Polymorph"
                    Dim form As String = "Err"
                    Dim c As Integer = 0
                    While c < 1 Or Game.formList.Contains(form)
                        c += 1
                        Dim learnForm As Integer = CInt(Int(Rnd() * 4))
                        Select Case learnForm
                            Case 0
                                form = "Dragon"
                            Case 1
                                form = "Succubus"
                            Case 2
                                form = "Slime"
                            Case 3
                                form = "Tigress"
                        End Select
                        If c > 40 Then
                            out = "All self polymorph forms learned from spellbooks!"
                            Exit Select
                        End If
                    End While
                    If Not Game.formList.Contains(form) Then
                        Game.formList.Add(form)
                        out = "You learn how to turn yourself into a " & form & "!"
                        Exit While
                    End If
                Case 3
                    sName = "Turn to Frog"
                Case 4
                    sName = "Polymorph Enemy"
                    Dim form As String = "Err"
                    Dim c As Integer = 0
                    While c < 1 Or Game.formList.Contains(form)
                        c += 1
                        Dim learnForm As Integer = CInt(Int(Rnd() * 3))
                        Select Case learnForm
                            Case 0
                                form = "Sheep"
                            Case 1
                                form = "Princess"
                            Case 2
                                form = "Bunny"
                        End Select
                        If c > 40 Then
                            out = "All polymorph enemy forms learned from spellbooks!"
                            Exit Select
                        End If
                    End While
                    If Not Game.tFormList.Contains(form) Then
                        Game.tFormList.Add(form)
                        out = "You learn how to polymorph somthing into a " & form & "!"
                        Exit While
                    End If
                Case 5
                    sName = "Petrify"
                Case 6
                    sName = "Heal"
                Case 7
                    sName = "Dowse"
                Case 8
                    sName = "Illuminate"
                    'Case 7
                    '    sName = "Arcane Hypnosis"
                    'Case 8
                    '    sName = "Mindshrink"
                    'Case 9
                    '    sName = "Freeze"
            End Select
            If ct > 60 Then
                Game.lstLog.Items.Add("You know all the spells in spellbooks already!")
                count -= 1
                Exit Sub
            End If
        End While
        If (sName = "Turn to Frog" Or sName = "Polymorph Enemy" Or sName = "Arcane Hypnosis" Or sName = "Freeze" Or sName = "Petrify") And Not Game.cboxNPCMG.Items.Contains(sName) Then Game.cboxNPCMG.Items.Add(sName)
        If Not Game.cboxMG.Items.Contains(sName) Then Game.cboxMG.Items.Add(sName)
        Game.lstLog.Items.Add("You read the " & getName() & ". " & sName & " learned!")
        If Not out.Equals("") Then Game.lstLog.Items.Add(out)
        count -= 1
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
    End Sub
    Overrides Sub discard()
        Game.lstLog.Items.Add("You drop the " & getName())
        Game.lstLog.TopIndex = Game.lstLog.Items.Count - 1
        count -= 1
    End Sub
End Class
