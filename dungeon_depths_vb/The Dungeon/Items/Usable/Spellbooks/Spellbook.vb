Public Class Spellbook
    Inherits Item

    Public Const ITEM_NAME = "Spellbook"

    Public Shared spells() As String = {"Super Fireball", "Icicle Spear", "Self Polymorph", "Turn to Frog", "Polymorph Enemy",
                                        "Petrify", "Heal", "Illuminate", "Fireball", "Warp", "Arcane Compass", "Hydrodart"}
    Sub New()
        setName(ITEM_NAME)
        setDesc("A simple, leather-bound book that likely contains something cool and magic.")
        id = 4
        tier = 2
        usable = true
        count = 0
        value = 500
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
                    Case 2
                        sName = "Self Polymorph"
                        Dim form As String = "Err"
                        Dim c As Integer = 0
                        While c < 1 Or p.selfPolyForms.Contains(form)
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
                        If Not p.selfPolyForms.Contains(form) Then
                            p.selfPolyForms.Add(form)
                            out = "You learn how to turn yourself into a " & form & "!"
                            Exit While
                        End If
                    Case 4
                        sName = "Polymorph Enemy"
                        Dim form As String = "Err"
                        Dim c As Integer = 0
                        While c < 1 Or p.enemPolyForms.Contains(form)
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
                        If Not p.enemPolyForms.Contains(form) Then
                            p.enemPolyForms.Add(form)
                            out = "You learn how to polymorph somthing into a " & form & "!"
                            Exit While
                        End If
                    Case Else
                        sName = spells(spell)
                End Select
                If ct > 60 Then
                    TextEvent.pushLog("You know all the spells in spellbooks already!")
                    Exit Sub
                End If
            End While
            If Not Game.player1.knownSpells.Contains(sName) Then Game.player1.knownSpells.Add(sName)
            TextEvent.pushLog("You read the " & getName() & ". " & sName & " learned!")
            If Not out.Equals("") Then
                TextEvent.pushLog(out)
                TextEvent.push("You read the " & getName() & ". " & sName & " learned!" & DDUtils.RNRN & out)
            Else
                TextEvent.push("You read the " & getName() & ". " & sName & " learned!")
            End If
        End If
        count -= 1

    End Sub
End Class
