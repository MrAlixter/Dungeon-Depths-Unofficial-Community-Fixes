Public Class BarbarianLesson
    Inherits Item

    Sub New()
        '|ID Info|
        setName("Barbarian_Lesson")
        id = 114
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False
        MyBase.onBuy = AddressOf teach

        '|Stats|
        count = 0
        value = 5900

        '|Description|

        setDesc("""Are you a fan of the simple things in life, without the complications of magic?  Are you bored of the standard warrior class, and are you looking to shift things up a bit?  Perhaps the Barbarian life is for you...""")
    End Sub

  Sub teach()
        count = 0
        TextEvent.pushNPCDialog("Before we get started, I just want to make sure you really want this.  This lesson will completely change who you are and were, forever.", AddressOf warning)
        Game.shopMenu.Close()
        Game.hideNPCButtons()
    End Sub

    Sub warning()
        TextEvent.pushYesNo("Start over as a Barbarian?", AddressOf tf, AddressOf cancel)
    End Sub
    Sub cancel()
        Game.player1.gold += value
        CType(Game.hteach, HypnoTeach).back()
    End Sub
    Sub tf()
        CType(Game.hteach, HypnoTeach).hypnotize("Perfect!  Speaking of perfection, have you seen my pendant?  I know it is a bit of a cliche, but doesn't seeing it swing back and forth just relax you so perfectly?  Back...and forth...watch it glisten in the light...feel yourself go deeper and deeper...deeper...and deeper...until you just...*SNAP*...drift away...", AddressOf tf2)
    End Sub
    Sub tf2()
        Dim out = "As soon as she snaps, your entire reality fades away.  You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses voice, though in your haze you don't understand much of what she's saying.  You pass in and out of conciousness several times until gradually you begin to clearly hear what she's saying." & DDUtils.RNRN &
            """...and then we met!  Are you sure you're feeling alright?  Ever you fought off that dragon you've been a little strange..."" the hypnotist teacher asks, sounding slightly concerned." & DDUtils.RNRN &
            "Fought a dragon!?  While that sounds like something you'd do, you don't remember it which is strange considering how much you savor combat.  All the same, you tell this strange, yet beautiful lady that you are fine.  Twirling your heavy weapon deftly, you remark that you've never felt better!  This actually isn't too far off, your well toned muscles are raring to give something a beatdown." & DDUtils.RNRN &
            """Well then, it seems like my work here is done,"" the Hypnotist says, inturupting your thoughts.  ""If I can help you with anything else, don't hesitate to ask!"""

        Dim p = Game.player1

        p.inv.add("Barbarian_Armor", 1)
        EquipmentDialogBackend.armorChange(p, "Barbarian_Armor")
        p.inv.add("Corse_War_Axe", 1)
        EquipmentDialogBackend.weaponChange(p, "Corse_War_Axe")


        p.changeClass("Barbarian")

        TextEvent.push(out, AddressOf CType(Game.hteach, HypnoTeach).back)
        p.drawPort()
        p.UIupdate()
        p.pState.save(p)
        p.sState.save(p)
    End Sub
End Class
