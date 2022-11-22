Public Class CursePurge
    Inherits Item

    Public Const ITEM_NAME As String = "Blight_Dismissal"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 245
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf purge

        '|Stats|
        count = 0
        value = 3110

        '|Description|
        setDesc("""There's no good reason to continue a cursed existence if you don't want to.  Come, let's get those curses off of you so that they can be put to better use elsewhere...""")
    End Sub

    Sub purge()
        Dim p = Game.player1
        Game.shopMenu.Close()

        '| -- Curses -- |
        If p.perks(perk.slutcurse) > -1 Then p.perks(perk.slutcurse) = -1 : TextEvent.pushLog("The slut curse is neutralized")
        If p.perks(perk.copoly) > -1 Then p.perks(perk.copoly) = -1 : TextEvent.pushLog("The curse of polymorph is neutralized")
        If p.perks(perk.cogreed) > -1 Then p.perks(perk.cogreed) = -1 : TextEvent.pushLog("The curse of greed is neutralized")
        If p.perks(perk.corust) > -1 Then p.perks(perk.corust) = -1 : TextEvent.pushLog("The curse of rust is neutralized")
        If p.perks(perk.comilk) > -1 Then p.perks(perk.comilk) = -1 : TextEvent.pushLog("The curse of milk is neutralized")
        If p.perks(perk.coblind) > -1 Then p.perks(perk.coblind) = -1 : TextEvent.pushLog("The curse of blindness is neutralized")
        If p.perks(perk.coscale) > -1 Then p.perks(perk.coscale) = -1 : TextEvent.pushLog("The Curse of Scales is neutralized")
        If p.perks(perk.faecurse) > -1 Then p.perks(perk.faecurse) = -1 : TextEvent.pushLog("The fae's curse is neutralized")
        If p.perks(perk.succubuscurse) > -1 Then p.perks(perk.succubuscurse) = -1 : TextEvent.pushLog("The succubus's curse is neutralized")
        If p.ongoingTFs.contains(tfind.malmino) Then p.ongoingTFs.remove(tfind.malmino) : TextEvent.pushLog("The Curse of the Bull is neutralized")
        If p.perks(perk.coftheox) > -1 Then p.perks(perk.coftheox) = -1 : TextEvent.pushLog("The curse of the ox is neutralized")

        '| -- Cursed Equipment -- |
        If p.equippedArmor.getCursed(p) Then EquipmentDialogBackend.equipArmor(p, "Naked", False) : TextEvent.pushLog("Cursed armor removed")
        If p.equippedWeapon.getCursed(p) Then EquipmentDialogBackend.equipWeapon(p, "Fists", False) : TextEvent.pushLog("Cursed weapon removed")
        If p.equippedAcce.getCursed(p) Then EquipmentDialogBackend.equipAcce(p, "Nothing", False) : TextEvent.pushLog("Cursed accessory removed")
        If p.equippedGlasses.getCursed(p) Then EquipmentDialogBackend.equipGlasses(p, "Nothing", False) : TextEvent.pushLog("Cursed glasses removed")

        TextEvent.pushNPCDialog("Ah, a fresh slate.  Don't stay out of too much trouble now, caution won't lead you anywhere...interesting...")

        p.drawPort()

        count -= 1
    End Sub
End Class
