Public Class MarissasNotes
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Marissa's_Notes")
        id = 278
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 800

        '|Description|
        MyBase.setDesc("A small, black book with the golden silloette of a cat on the cover.  According to the title page, the author is ""Marissa, Master Nekomancer""")
    End Sub

    Overrides Sub use(ByRef p As Player)

        Dim sName = "Polymorph Enemy"
        Dim out = "You learn how to polymorph somthing into a Catgirl!"

        If Not p.knownSpells.Contains(sName) Then
            p.knownSpells.Add(sName)
            Game.pushLstLog("You learn ""Polymorph Enemy""")
        End If

        If Not p.enemPolyForms.Contains("Cat-Girl") Then
            p.enemPolyForms.Add("Cat-Girl")
            Game.pushLstLog(out)
        Else
            Game.pushLogAndEvent("The book doesn't contain any new information...")
        End If

        count -= 1
    End Sub
End Class
