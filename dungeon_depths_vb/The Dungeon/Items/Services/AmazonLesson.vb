Public Class AmazonLesson
    Inherits Item

    Sub New()
        MyBase.setName("Amazon_Lesson")
        MyBase.setDesc("More than just mental manipulation, this lesson offers a physical transformation as well as some mental changes.  ""Are you disillusioned with all this magic and weapons malarchy?  Do you just want to smack things around with your bare hands like the powerful woman you are (or could be)?  Perhaps the Amazon life is for you...""")
        id = 113
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 6969
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
        Game.pushPnlYesNo("Start over as an Amazon?", AddressOf tf, AddressOf cancel)
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
            """...and then we met!  You're a fair ways off from the Amazonian village though, right?"" the hypnotist teacher asks cheerfully." & DDUtils.RNRN &
            "Right!  The Village!  You recall all the time you spent in that village; your childhood, your combat training, the first time you saw a man.  He, a lost traveller, had stumbled into the village one clear evening.  Before the sun rose, though, the shamans worked their magic, leaving a very confused woman in his place." & DDUtils.RNRN &
            """Well then, it seems like my work here is done,"" the Hypnotist says, inturupting your reminissing.  ""If I can help you with anything else, don't hesitate to ask!"""
        Dim aTF As AmazonTF = New AmazonTF()
        aTF.step1()

        Dim p = Game.player1

        Game.pushLblEvent(out, AddressOf CType(Game.hteach, HTeach).back)
        p.drawPort()
        p.UIupdate()
        p.pState.save(p)
        p.sState.save(p)
    End Sub
End Class
