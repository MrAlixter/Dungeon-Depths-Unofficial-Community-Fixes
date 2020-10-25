Public Class AntiCurseTag
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Anti_Curse_Tag")
        id = 153
        tier = 3

        '|Item Flags|
        MyBase.setUsable(True)

        '|Stats|
        MyBase.count = 0
        MyBase.value = 777

        '|Description|
        MyBase.setDesc("A small paper tag with instructions to apply it to your equipment." & DDUtils.RNRN &
                       "Using this item will un-do the slut curse on your currently equipped armor." & DDUtils.RNRN &
                       "To remove cursed (unremoveable) equipment, unequip it as usual while at least 1 Anti_Curse_Tag is present in your inventory.  Anti_Curse_Tags are consumed per each cursed equipment unequipped.")
    End Sub

    Overrides Sub use(ByRef p As Player)
        p.perks(perk.slutcurse) = -1

        If Equipment.antiClothingCurse(p) Then
            Game.pushLblEvent("You apply the anti-curse tag to your equipment.  The slut curse is neutralized!")
        ElseIf p.equippedArmor.isCursed Then
            Equipment.equipArmor(p, "Naked")
        ElseIf p.equippedWeapon.isCursed Then
            Equipment.equipWeapon(p, "Fists")
        ElseIf p.equippedAcce.isCursed Then
            Equipment.equipAcce(p, "Nothing")
        End If

        p.drawPort()
        count -= 1
    End Sub
End Class
