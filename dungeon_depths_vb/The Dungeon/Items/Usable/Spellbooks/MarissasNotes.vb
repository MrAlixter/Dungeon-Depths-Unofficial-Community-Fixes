Public Class MarissasNotes
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Marissa's_Notes")
        id = 278
        tier = Nothing

        '|Item Flags|
        usable = true

        '|Stats|
        count = 0
        value = 800

        '|Description|
        setDesc("A small, black book with the golden silloette of a cat on the cover.  According to the title page, the author is ""Marissa, Master Nekomancer""")
    End Sub

    Overrides Sub use(ByRef p As Player)

        Dim sName = "Polymorph Enemy"
        Dim out = "You learn how to polymorph somthing into a Catgirl!"

        If Not p.knownSpells.Contains(sName) Then
            p.knownSpells.Add(sName)
            TextEvent.pushLog("You learn ""Polymorph Enemy""")
        End If

        If Not p.enemPolyForms.Contains("Cat-Girl") Then
            p.enemPolyForms.Add("Cat-Girl")
            TextEvent.pushLog(out)
        Else
            TextEvent.pushAndLog("The book doesn't contain any new information...")
        End If

        count -= 1
    End Sub
End Class
