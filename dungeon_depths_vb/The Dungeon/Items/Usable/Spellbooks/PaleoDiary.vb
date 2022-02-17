Public Class PaleoDiary
    Inherits Item

    Public Const ITEM_NAME As String = "Paleomancer's_Diary"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 277
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 800

        '|Description|
        setDesc("A simple, leather-bound journal written by a wizard studying the past that likely contains something cool and magic.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        
        Dim sName = "Polymorph Enemy"
        Dim out = "You learn how to polymorph somthing into a Trilobite!"

        If Not p.knownSpells.Contains(sName) Then
            p.knownSpells.Add(sName)
            TextEvent.pushLog("You learn ""Polymorph Enemy""")
        End If

        If Not p.enemPolyForms.Contains("Trilobite") Then
            p.enemPolyForms.Add("Trilobite")
            TextEvent.pushLog(out)
        Else
            TextEvent.pushAndLog("The book doesn't contain any new information...")
        End If

        count -= 1
    End Sub
End Class
