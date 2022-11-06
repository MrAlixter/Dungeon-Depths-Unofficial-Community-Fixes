Public Class RosePetalSpellbook
    Inherits Item

    Public Const ITEM_NAME As String = "Rosepetal_Spellbook"

    Public Shared spells() As String = {"Slitherslice", "Polymorph Enemy", "Turn to Frog"}

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 379
        tier = 3

        '|Item Flags|
        usable = True
        npc_drop_only = True

        '|Stats|
        count = 0
        value = 700

        '|Description|
        setDesc("A small, pale-green book with a pink rose sigil on the cover.  Its pages glitter with pixie dust...")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        Randomize()

        Dim sName As String = "ERROR"
        Dim ct As Integer = 0
        Dim out As String = ""

        While ct < 1 Or Game.player1.knownSpells.Contains(sName)
            ct += 1

            Dim spell As Integer = CInt(Int(Rnd() * (spells.Length)))

            Select Case spell
                Case 1
                    sName = "Polymorph Enemy"

                    If Game.player1.enemPolyForms.Contains("Bee-Girl") Then
                        out = "All polymorph enemy forms learned from this spellbook!"
                    Else
                        out = "You learn how to polymorph somthing into a Bee-Girl!"
                    End If

                    TextEvent.pushLog(out)
                Case Else
                    sName = spells(spell)
            End Select

            If ct > 60 Then
                TextEvent.pushLog("You know all the spells in spellbooks already!")
                Exit Sub
            End If
        End While

        If Not Game.player1.knownSpells.Contains(sName) Then Game.player1.knownSpells.Add(sName)

        TextEvent.pushAndLog("You read the " & getName() & ". " & sName & " learned!")

        count -= 1
    End Sub
End Class
