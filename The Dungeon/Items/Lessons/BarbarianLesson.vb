Public Class BarbarianLesson
    Inherits Item

    Sub New()
        MyBase.setName("Barbarian_Lesson")
        MyBase.setDesc("""Are you a fan of the simple things in life, without the complications of magic?  Are you bored of the standard warrior class, and are you looking to shift things up a bit?  Perhaps the Barbarian life is for you...""")
        id = 114
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 5900
        MyBase.onBuy = AddressOf teach
    End Sub

    Sub teach()
        count = 0
        Game.pushNPCDialog("Before we get started, I just want to make sure you really want this.  This lesson will completely change who you are forever, and you'll lose any stat boosts you might have gotten from charms.", AddressOf warning)
        Game.shopMenu.Close()
        CType(Game.hteach, HTeach).hideShopButtons()
    End Sub
    Sub warning()
        Game.pushPnlYesNo("Start over as a Barbarian?", AddressOf tf, AddressOf cancel)
    End Sub
    Sub cancel()
        Game.player.gold += value
        CType(Game.hteach, HTeach).back()
    End Sub
    Sub tf()
        CType(Game.hteach, HTeach).hypnotize("Perfect!  Speaking of perfection, have you seen my pendant?  I know it is a bit of a cliche, but doesn't seeing it swing back and forth just relax you so perfectly?  Back...and forth...watch it glisten in the light...feel yourself go deeper and deeper...deeper...and deeper...until you just...*SNAP*...drift away...", AddressOf tf2)
    End Sub
    Sub tf2()
        Dim out = "As soon as she snaps, your entire reality fades away.  You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses voice, though in your haze you don't understand much of what she's saying.  You pass in and out of conciousness several times until gradually you begin to clearly hear what she's saying." & vbCrLf & vbCrLf &
            """...and then we met!  Are you sure you're feeling alright?  Ever you fought off that dragon you've been a little strange..."" the hypnotist teacher asks, sounding slightly concerned." & vbCrLf & vbCrLf &
            "Fought a dragon!?  While that sounds like something you'd do, you don't remember it which is strange considering how much you savor combat.  All the same, you tell this strange, yet beautiful lady that you are fine.  Twirling your heavy weapon deftly, you remark that you've never felt better!  This actually isn't too far off, your well toned muscles are raring to give something a beatdown." & vbCrLf & vbCrLf &
            """Well then, it seems like my work here is done,"" the Hypnotist says, inturupting your thoughts.  ""If I can help you with anything else, don't hesitate to ask!"""

        Dim p = Game.player

        p.setStatsToBeginning()

        p.inv.add("Barbarian_Armor", 1)
        Equipment.clothesChange("Barbarian_Armor")
        p.inv.add("Corse_War_Axe", 1)
        Equipment.weaponChange("Corse_War_Axe")


        p.pClass = p.classes("Barbarian")

        Game.pushLblEvent(out, AddressOf CType(Game.hteach, HTeach).back)
        p.createP()
        p.UIupdate()
        p.pState.save(p)
        p.sState.save(p)
    End Sub
End Class
