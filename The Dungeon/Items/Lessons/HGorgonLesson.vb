Public Class HGorgonLesson
    Inherits Item

    Sub New()
        MyBase.setName("Gorgon_Lesson")
        MyBase.setDesc("More than just mental manipulation, this lesson offers a physical transformation as well as some mental changes.  ""While I don't think anyone can make you immune to Medusa's power completely, I can at least give you a Gorgon upbringing.  It is not a flawless counter to her abilities, but at least you won't be petrified from the offset.  Fair warning though, I'll also make it so that you can no longer petrify the other shopkeepers and I...""")
        id = 122
        tier = Nothing
        MyBase.setUsable(False)
        MyBase.count = 0
        MyBase.value = 8888
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
        Game.pushPnlYesNo("Start over as a Half-Gorgon?", AddressOf tf, AddressOf cancel)
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
            """...aaannnd there.  We wouldn't want you turning any of the vendors to stone!"" the teacher giggles, returning her pendant to her pocket.  ""I focused primarily on getting you acclimated to your new body with this session, so your concious memories should mostly be in tact.""" & vbCrLf & vbCrLf &
            "A 'hiss' startles you, and it is only now that it sinks in that your hair is now made up of nest of snakes!  Fortunatly they seem to be fairly well behaved snakes, and you already feel comfortable with them." & vbCrLf & vbCrLf &
            """Well then, it seems like my work here is done,"" the Hypnotist says, inturupting your thoughts.  ""If I can help you with anything else, don't hesitate to ask!"""

        Dim aTF As HGorgonTF = New HGorgonTF()
        aTF.step1()

        Dim p = Game.player

        Game.pushLblEvent(out, AddressOf CType(Game.hteach, HTeach).back)
        p.createP()
        p.UIupdate()
        p.pState.save(p)
        p.sState.save(p)
    End Sub
End Class
