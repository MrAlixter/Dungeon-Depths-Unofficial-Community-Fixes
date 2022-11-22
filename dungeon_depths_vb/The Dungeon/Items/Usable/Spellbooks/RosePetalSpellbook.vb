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

        Dim learnable_spells = New List(Of String)(spells)
        Dim learned_spell As String = ""

        While learnable_spells.Count > 0 And learned_spell = ""
            Dim spell As String = learnable_spells(Int(Rnd() * learnable_spells.Count))

            If Not Game.player1.knownSpells.Contains(spell) Or spell.Equals("Polymorph Enemy") Then
                learned_spell = spell

                If spell = "Polymorph Enemy" Then
                    If Game.player1.enemPolyForms.Contains("Bee-Girl") Then
                        learned_spell = ""
                    Else
                        TextEvent.pushLog("You learn how to polymorph somthing into a Bee-Girl!")
                        Game.player1.enemPolyForms.Add("Bee-Girl")
                    End If
                End If
            End If

            learnable_spells.Remove(spell)
        End While

        If learned_spell = "" Then
            TextEvent.pushLog("You know all the spells in " & getAName() & "s already!")
            Exit Sub
        End If

        If Not Game.player1.knownSpells.Contains(learned_spell) Then Game.player1.knownSpells.Add(learned_spell)

        TextEvent.pushAndLog("You read the " & getName() & ". " & learned_spell & " learned!")

        count -= 1
    End Sub
End Class
