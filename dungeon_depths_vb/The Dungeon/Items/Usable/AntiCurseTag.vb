Public Class AntiCurseTag
    Inherits Item

    Public Const ITEM_NAME As String = "Anti_Curse_Tag"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 153
        tier = 3

        '|Item Flags|
        usable = True

        '|Stats|
        count = 0
        value = 777

        '|Description|
        setDesc("A small paper tag with instructions to apply it to your equipment." & DDUtils.RNRN &
                "Using this item will un-do the slut curse on your currently equipped armor." & DDUtils.RNRN &
                "To remove cursed (unremoveable) equipment, unequip it as usual while at least 1 Anti_Curse_Tag is present in your inventory.  Anti_Curse_Tags are consumed per each cursed equipment unequipped.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        MyBase.use(p)

        p.perks(perk.slutcurse) = -1

        If Equipment.antiClothingCurse(p) Then
            If Not Game.combat_engaged And Game.pnlEvent.Visible Then
                Game.txtPNLEvents.Text = ("You apply the anti-curse tag to your equipment, and " & Game.txtPNLEvents.Text.Substring(0, 1).ToLower & Game.txtPNLEvents.Text.Substring(1, Game.txtPNLEvents.Text.Length - 1))
            Else
                TextEvent.push("You apply the anti-curse tag to your equipment.  The slut curse is neutralized!")
            End If

            count -= 1

            Exit Sub
        ElseIf p.equippedArmor.getCursed(p) Then
            EquipmentDialogBackend.equipArmor(p, "Naked")
        ElseIf p.equippedWeapon.getCursed(p) Then
            EquipmentDialogBackend.equipWeapon(p, "Fists")
        ElseIf p.equippedAcce.getCursed(p) Then
            EquipmentDialogBackend.equipAcce(p, "Nothing")
        ElseIf p.equippedGlasses.getCursed(p) Then
            EquipmentDialogBackend.equipGlasses(p, "Nothing")
        End If

        p.drawPort()
    End Sub
End Class
