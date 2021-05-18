Public Class CSpellbook
    Inherits Item
    Public Shared spells() As String = {"Raise Lust", "Puff Up", "Hellfireball", "Reductive Mending"}
    Sub New()
        setName("Crimson_Spellbook")
        setDesc("A smoldering leather-bound book that contains something magic written by a succubus.")
        id = 226
        tier = Nothing
        usable = true
        count = 0
        value = 666
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Int(Rnd() * 10) = -1 Then
            'bimbo tf
        Else
            Randomize()
            If Me.getUsable() = False Then Exit Sub
            Dim sName As String = "ERROR"
            Dim ct As Integer = 0
            Dim out As String = ""
            While ct < 1 Or Game.player1.knownSpells.Contains(sName)
                ct += 1
                Dim spell As Integer = CInt(Int(Rnd() * (spells.Length)))
                Select Case spell
                    Case 4
                        sName = "Self Polymorph"
                        Dim form As String = "Err"
                        Dim c As Integer = 0
                        While c < 1 Or p.selfPolyForms.Contains(form)
                            c += 1
                            Dim learnForm As Integer = CInt(Int(Rnd() * 4))
                            Select Case learnForm
                                Case 0
                                    form = "Tentacle Fiend"
                            End Select
                            If c > 40 Then
                                out = "All self polymorph forms learned from spellbooks!"
                                Exit Select
                            End If
                        End While
                        If Not p.selfPolyForms.Contains(form) Then
                            p.selfPolyForms.Add(form)
                            out = "You learn how to turn yourself into a " & form & "!"
                            Exit While
                        End If
                    Case 5
                        sName = "Polymorph Enemy"
                        Dim form As String = "Err"
                        Dim c As Integer = 0
                        While c < 1 Or p.enemPolyForms.Contains(form)
                            c += 1
                            Dim learnForm As Integer = CInt(Int(Rnd() * 3))
                            Select Case learnForm
                                Case 0
                                    form = "Goth"
                            End Select
                            If c > 40 Then
                                out = "All polymorph enemy forms learned from spellbooks!"
                                Exit Select
                            End If
                        End While
                        If Not p.enemPolyForms.Contains(form) Then
                            p.enemPolyForms.Add(form)
                            out = "You learn how to polymorph somthing into a " & form & "!"
                            Exit While
                        End If
                    Case Else
                        sName = spells(spell)
                End Select
                If ct > 60 Then
                    Game.pushLstLog("You know all the spells in crimson spellbooks already!")
                    Exit Sub
                End If
            End While
            If Not Game.player1.knownSpells.Contains(sName) Then Game.player1.knownSpells.Add(sName)
            Game.pushLstLog("You read the " & getName() & ". " & sName & " learned!")
            If Not out.Equals("") Then
                Game.pushLstLog(out)
                Game.pushLblEvent("You read the " & getName() & ". " & sName & " learned!" & DDUtils.RNRN & out)
            Else
                Game.pushLblEvent("You read the " & getName() & ". " & sName & " learned!")
            End If
        End If
        count -= 1

    End Sub

    Public Overrides Function getTier() As Integer
        If DDDateTime.isValen Then Return 2

        Return MyBase.getTier()
    End Function
End Class
