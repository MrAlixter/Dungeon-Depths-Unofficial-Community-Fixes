Public Class CursePurge
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Blight_Dismissal")
        id = 245
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        MyBase.onBuy = AddressOf purge

        '|Stats|
        count = 0
        value = 3110

        '|Description|
        setDesc("""There's no good reason to continue a cursed existance if you don't want to.  Come, let's get those curses off of you so that they can be put to better use elsewhere...""")
    End Sub

    Sub purge()
        Dim p = Game.player1
        Game.shopMenu.Close()

        '| -- Curses -- |
        If p.perks(perk.slutcurse) > -1 Then p.perks(perk.slutcurse) = -1 : Game.pushLstLog("The slut curse is neutralized")
        If p.perks(perk.copoly) > -1 Then p.perks(perk.copoly) = -1 : Game.pushLstLog("The curse of polymorph is neutralized")
        If p.perks(perk.cogreed) > -1 Then p.perks(perk.cogreed) = -1 : Game.pushLstLog("The curse of greed is neutralized")
        If p.perks(perk.corust) > -1 Then p.perks(perk.corust) = -1 : Game.pushLstLog("The curse of rust is neutralized")
        If p.perks(perk.comilk) > -1 Then p.perks(perk.comilk) = -1 : Game.pushLstLog("The curse of milk is neutralized")
        If p.perks(perk.coblind) > -1 Then p.perks(perk.coblind) = -1 : Game.pushLstLog("The curse of blindness is neutralized")
        If p.perks(perk.coscale) > -1 Then p.perks(perk.coscale) = -1 : Game.pushLstLog("The Curse of Scales is neutralized")
        If p.perks(perk.faecurse) > -1 Then p.perks(perk.faecurse) = -1 : Game.pushLstLog("The fae's curse is neutralized")
        If p.perks(perk.succubuscurse) > -1 Then p.perks(perk.succubuscurse) = -1 : Game.pushLstLog("The succubus's curse is neutralized")
        If Not p.ongoingTFs.getAt("MinoMTF") Is Nothing Then p.ongoingTFs.remove("MinoMTF") : Game.pushLstLog("The Curse of the Bull is neutralized")
        If p.perks(perk.coftheox) > -1 Then p.perks(perk.coftheox) = -1 : Game.pushLstLog("The curse of the ox is neutralized")

        '| -- Cursed Equipment -- |
        If p.equippedArmor.cursed Then Equipment.equipArmor(p, "Naked") : Game.pushLstLog("Cursed armor removed")
        If p.equippedWeapon.cursed Then Equipment.equipWeapon(p, "Fists") : Game.pushLstLog("Cursed weapon removed")
        If p.equippedAcce.cursed Then Equipment.equipAcce(p, "Nothing") : Game.pushLstLog("Cursed accessory removed")

        Game.pushNPCDialog("Ah, a fresh slate.  Don't stay out of too much trouble now, caution won't lead you anywhere...interesting...")

        count -= 1
    End Sub
End Class
