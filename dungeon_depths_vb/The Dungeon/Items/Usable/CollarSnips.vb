Public Class CollarSnips
    Inherits Item

    Public Const ITEM_NAME As String = "Collar_Snips"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 252
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 1111

        '|Description|
        setDesc("A small pair of pliers capable of cutting the enchanted locks of any thrall collar, even one worn by the user.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        If Me.getUsable() = False Then Exit Sub

        If p.equippedAcce.getAName.Equals("Slave_Collar") And Not Game.combat_engaged Then
            TextEvent.pushAndLog("You snip off the collar on your neck.")

            EquipmentDialogBackend.equipAcce(p, "Nothing", False)

            p.drawPort()
            Exit Sub
        End If

        If Not Game.combat_engaged Then Exit Sub

        If p.currTarget.getName.Contains("Thrall") Then
            Game.fromCombat()
            TextEvent.pushLog("You snip the collar off of the thrall!")
            TextEvent.push("You snip the collar off of the thrall, and as it falls to the ground the haze lifts from their eyes.  Before they wander off, you mention that the Shopkeeper is looking for some willing help and they nod before thanking you.")
            p.perks(perk.collarssnipped) += 1
        End If
    End Sub
End Class
