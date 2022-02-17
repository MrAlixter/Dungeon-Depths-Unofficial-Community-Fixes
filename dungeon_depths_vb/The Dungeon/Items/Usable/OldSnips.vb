Public Class OldSnips
    Inherits Item

    Public Const ITEM_NAME As String = "Old_Snips"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 251
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 0

        '|Description|
        setDesc("A small pair of pliers capable of cutting the enchanted locks of thrall collars.  Unfortunately, the arms of the snips are not long enough to cut through one's own collar.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If p.equippedAcce.getAName.Equals("Thrall_Collar") And Not Game.combat_engaged Then
            TextEvent.pushAndLog("You can't get a proper angle with the snips on the lock sealing your collar...")
            Exit Sub
        End If

        If Not Game.combat_engaged Then Exit Sub

        If p.currTarget.getName.Contains("Thrall") Then
            Game.fromCombat()
            TextEvent.pushLog("You snip the collar off of the thrall!")
            TextEvent.push("You snip the collar off of the thrall, and as it falls to the ground the haze lifts from their eyes.  Before they wander off, you mention that the Shopkeeper is looking for some willing help and they nod before thanking you.")
            p.perks(perk.collarssnipped) += 1
            damage(20)
        End If
    End Sub
End Class
