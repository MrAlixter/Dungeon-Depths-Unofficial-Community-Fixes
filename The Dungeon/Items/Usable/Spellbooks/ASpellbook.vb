Public Class ASpellbook
    Inherits Item
    Public Shared spells() As String = {"Turn to Blade", "Turn to Cupcake", "Self Polymorph", "Arcane Compass",
                                        "Magma Spear", "Petrify II", "Major Heal", "Warp", "Uvona's Fugue"}

    Sub New()
        MyBase.setName("Advanced_Spellbook")
        MyBase.setDesc("An ornate, gilded book that likely contains something outside of the standard magic curriculum.")
        id = 65
        tier = 3
        MyBase.setUsable(True)
        MyBase.count = 0
        MyBase.value = 1000
    End Sub

    Overrides Sub use()
        Randomize()
        If Me.getUsable() = False Then Exit Sub
        Dim sName As String = "ERROR"
        Dim ct As Integer = 0
        Dim out As String = ""
        While ct < 1 Or Game.player.knownSpells.Contains(sName)
            ct += 1
            Dim spell As Integer = CInt(Int(Rnd() * (spells.Length)))
            Select Case spell
                Case 2
                    sName = "Self Polymorph"
                    Dim form As String = "Err"
                    Dim c As Integer = 0
                    Dim p = Game.player
                    While c < 1 Or p.selfPolyForms.Contains(form)
                        c += 1
                        Dim learnForm As Integer = CInt(Int(Rnd() * 0))
                        Select Case learnForm
                            Case 0
                                form = "Goddess"
                        End Select
                        If c > 40 Then
                          Exit Select
                        End If
                    End While
                    If Not p.selfPolyForms.Contains(form) Then
                        p.selfPolyForms.Add(form)
                        out = "You learn how to turn yourself into a " & form & "!"
                        Exit While
                    End If
                Case Else
                    sName = spells(spell)
            End Select
            If ct > 60 Then
                Game.pushLstLog("You know all the spells in advanced spellbooks already!")
                Exit Sub
            End If
        End While
        If Not Game.player.knownSpells.Contains(sName) Then Game.player.knownSpells.Add(sName)
        Game.pushLstLog("You read the " & getName() & ". " & sName & " learned!")
        If Not out.Equals("") Then Game.pushLstLog(out)
        count -= 1
        
    End Sub
End Class
