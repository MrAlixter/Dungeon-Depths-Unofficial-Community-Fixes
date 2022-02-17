Public Class ASpellbook
    Inherits Item

    Public Const ITEM_NAME As String = "Advanced_Spellbook"

    Public Shared spells() As String = {"Turn to Blade", "Turn to Cupcake", "Self Polymorph",
                                        "Magma Spear", "Petrify II", "Major Heal", "Uvona's Fugue",
                                        "Summon Apple"}

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 65
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 1500

        '|Description|
        setDesc("An ornate, gilded book that likely contains something outside of the standard magic curriculum.")
    End Sub

    Overrides Sub use(ByRef p As Player)
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
                TextEvent.pushLog("You know all the spells in advanced spellbooks already!")
                Exit Sub
            End If
        End While
        If Not Game.player1.knownSpells.Contains(sName) Then Game.player1.knownSpells.Add(sName)
        TextEvent.pushLog("You read the " & getName() & ". " & sName & " learned!")
        If Not out.Equals("") Then TextEvent.pushLog(out)
        count -= 1
    End Sub
End Class
