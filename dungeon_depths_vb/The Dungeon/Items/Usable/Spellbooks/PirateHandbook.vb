Public Class PirateHandbook
    Inherits Item

    Public Const ITEM_NAME As String = "Pirate_Handbook"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 330
        tier = Nothing

        '|Item Flags|
        usable = True
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 3442

        '|Description|
        setDesc("A small, ornate book with the gilded image of a skull and crossbones on the cover.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If p.knownSpells.Contains("First Sea's Scourge") And p.knownSpells.Contains("Grog Blossom") And p.knownSpecials.Contains("Swashbuckle") And p.knownSpecials.Contains("Crow's Nest") Then
            TextEvent.pushAndLog("The book doesn't contain any new information...")
        Else
            p.learnSpell("First Sea's Scourge")
            p.learnSpell("Grog Blossom")
            p.learnSpecial("Swashbuckle")
            p.learnSpecial("Crow's Nest")
        End If

        count -= 1
    End Sub
End Class
