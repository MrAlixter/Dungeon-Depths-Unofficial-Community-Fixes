Public Class RosePetalSpellbook
    Inherits Item

    Public Const ITEM_NAME As String = "Rosepetal_Spellbook"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 379
        tier = Nothing

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

        Dim sName = "Polymorph Enemy"
        Dim out = "You learn how to polymorph somthing into a Bee-Girl!"

        If Not p.knownSpells.Contains(sName) Then
            p.knownSpells.Add(sName)
            TextEvent.pushLog("You learn ""Polymorph Enemy""")
        End If

        If Not p.enemPolyForms.Contains("Bee-Girl") Then
            p.enemPolyForms.Add("Bee-Girl")
            TextEvent.pushLog(out)
        Else
            TextEvent.pushAndLog("The book doesn't contain any new information...")
        End If

        count -= 1
    End Sub
End Class
