Public Class WarlockLesson
    Inherits Item

    Sub New()
        MyBase.setName("Warlock_Lesson")
        MyBase.setDesc("""Are you a fan of overwhelming magical power, without regard to its cost?  Do you mind needing to bend to the whim of, say, a goddess of forgetfulness, in order to achive your hopes and dreams?  Perhaps the Warlock life is for you...""")
        id = 124
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 5900
        MyBase.onBuy = AddressOf teach

        MyBase.isRandoTFAcceptable = False
    End Sub

    Sub teach()
        count = 0
        Game.pushNPCDialog("Before we get started, I just want to make sure you really want this.  This lesson will completely change who you are and were, forever.", AddressOf warning)
        Game.shopMenu.Close()
        Game.hideNPCButtons()
    End Sub
    Sub warning()
        Game.pushPnlYesNo("Start over as a Warlock?", AddressOf tf, AddressOf cancel)
    End Sub
    Sub cancel()
        Game.player1.gold += value
        CType(Game.hteach, HTeach).back()
    End Sub
    Sub tf()
        CType(Game.hteach, HTeach).hypnotize("Perfect!  Speaking of perfection, have you seen my pendant?  I know it is a bit of a cliche, but doesn't seeing it swing back and forth just relax you so perfectly?  Back...and forth...watch it glisten in the light...feel yourself go deeper and deeper...deeper...and deeper...until you just...*SNAP*...drift away...", AddressOf tf2)
    End Sub
    Sub tf2()
        Dim out = "As soon as she snaps, your entire reality fades away.  You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses voice, though in your haze you don't understand much of what she's saying.  You pass in and out of conciousness several times until gradually you begin to clearly hear what she's saying." & DDUtils.RNRN &
            """...for the last time, I am not interested in your cult!"" the hypnotist teacher states, sounding mildly annoyed." & DDUtils.RNRN &
            "A cult?  Hardly...  While you're certainly in an arrangement with a deity, it isn't that of a worshipper and goddess so much as that she offered you a great deal of magical power in exchange for whole bunch of favors.  Your benefactor Uvona, Goddess of Fugue, rarely calls these favors in, though when she does it's even rarer that you remember them.  Are there cults devoted to Uvona? Probably, but you would never..." & DDUtils.RNRN &
            """Well, I think you're done at least..."" the Hypnotist says, inturupting your thoughts.  ""If I can help you with anything else, don't hesitate to ask."""

        Dim p = Game.player1

        p.inv.add("Warlock's_Robes", 1)
        Equipment.clothesChange("Warlock's_Robes")
        p.inv.add("Ring_of_Uvona", 1)
        Equipment.accChange("Ring_of_Uvona")


        p.changeClass("Warlock")

        Game.pushLblEvent(out, AddressOf CType(Game.hteach, HTeach).back)
        p.drawPort()
        p.UIupdate()
        p.pState.save(p)
        p.sState.save(p)
    End Sub
End Class
