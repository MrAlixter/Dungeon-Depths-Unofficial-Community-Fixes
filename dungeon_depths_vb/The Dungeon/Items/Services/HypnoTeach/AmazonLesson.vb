Public Class AmazonLesson
    Inherits HypnoService

    Public Const ITEM_NAME As String = "Amazon_Lesson"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 113
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = Sub() teach(h_ind.misc)

        '|Stats|
        count = 0
        value = 6969

        '|Description|
        setDesc("More than just mental manipulation, this lesson offers a physical transformation as well as some mental changes." & DDUtils.RNRN &
                       """Are you disillusioned with all this 'magic and weapons' malarchy?  Do you just want to smack things around with your bare hands like the powerful woman you are (or could be)?  Perhaps the Amazon life is for you...""")
    End Sub

    '| - OUTCOMES - |
    Protected Overrides Sub doTrigger(ByRef p As Player, ByVal i As h_ind)
        'Don't do anything
    End Sub
    Protected Overrides Function doHypnosis(ByRef plr As Player, ByVal i As h_ind, Optional ByVal hypnoDesc As String = "") As Boolean
        TextEvent.pushNPCDialog("""Before we get started, I would like to confirm that you understand your selection.  This lesson will alter who you are now, and how you remember your 'original' self...""" & DDUtils.PAKTC, AddressOf warning)

        Return True
    End Function

    '| - MISC - |
    Protected Overrides Function canHypnotize(ByRef p As Player) As Boolean
        Return Not p.formName.Equals("Amazon")
    End Function

    '| - TRANSFORMATION - |
    Sub warning()
        TextEvent.pushYesNo("Start over as an Amazon?", AddressOf tf, AddressOf cancel)
    End Sub
    Sub cancel()
        Game.player1.gold += getRefundAmount(Game.hteach, value)
        CType(Game.hteach, HypnoTeach).back()
    End Sub
    Sub tf()
        Dim p = Game.player1

        CType(Game.hteach, HypnoTeach).hypnotize(getHypnoDesc(p), p, h_ind.misc, AddressOf tf2)
    End Sub
    Sub tf2()
        Dim out = "As soon as she snaps, your entire reality fades away.  You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses voice, though in your haze you don't understand much of what she's saying.  You pass in and out of conciousness several times until gradually you begin to clearly hear what she's saying." & DDUtils.RNRN &
            """...and then we met!  You're a fair ways off from the Amazonian village though, right?"" the hypnotist teacher asks cheerfully." & DDUtils.RNRN &
            "Right!  The Village!  You recall all the time you spent in that village; your childhood, your combat training, the first time you saw a man.  He, a lost traveller, had stumbled into the village one clear evening.  Before the sun rose, though, the shamans worked their magic, leaving a very confused woman in his place." & DDUtils.RNRN &
            """Well then, it seems like my work here is done,"" the Hypnotist says, inturupting your reminissing.  ""If I can help you with anything else, don't hesitate to ask!"""
        Dim aTF As AmazonTF = New AmazonTF()
        aTF.step1()

        Dim p = Game.player1

        TextEvent.push(out, AddressOf CType(Game.hteach, HypnoTeach).back)
        p.drawPort()
        p.UIupdate()
        p.pState.save(p)
        p.sState.save(p)
    End Sub
End Class
