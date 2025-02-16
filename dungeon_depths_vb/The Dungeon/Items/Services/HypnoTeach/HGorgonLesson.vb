Public Class HGorgonLesson
    Inherits HypnoService

    Public Const ITEM_NAME As String = "Gorgon_Lesson"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 122
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = Sub() teach(h_ind.misc)

        '|Stats|
        count = 0
        value = 8888

        '|Description|
        setDesc("More than just mental manipulation, this lesson offers a physical transformation as well as some mental changes." & DDUtils.RNRN &
                """While I don't think anyone can make you immune to Medusa's power completely, I can at least give you a Gorgon upbringing.  It is not a flawless counter to her abilities, but at least you won't be petrified from the offset.  Fair warning though, I'll also make it so that you can no longer petrify the other shopkeepers and I...""")
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
        Return Not p.formName.Equals("Half-Gorgon")
    End Function

    '| - TRANSFORMATION - |
    Sub warning()
        TextEvent.pushYesNo("Start over as a Half-Gorgon?", AddressOf tf, AddressOf cancel)
    End Sub
    Sub cancel()
        Game.player1.gold += getRefundAmount(Game.hteach, value)
        CType(Game.hteach, HypnoTeach).back()
    End Sub
    Sub tf()
        Dim p As Player = Game.player1
        CType(Game.hteach, HypnoTeach).hypnotize(getHypnoDesc(p), p, h_ind.misc, AddressOf tf2)
    End Sub
    Sub tf2()
        Dim out = "As soon as she snaps, your entire reality fades away.  You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses voice, though in your haze you don't understand much of what she's saying.  You pass in and out of conciousness several times until gradually you begin to clearly hear what she's saying." & DDUtils.RNRN &
            """...aaannnd there.  We wouldn't want you turning any of the vendors to stone!"" the teacher giggles, returning her pendant to her pocket.  ""I focused primarily on getting you acclimated to your new body with this session, so your concious memories should mostly be in tact.""" & DDUtils.RNRN &
            "A 'hiss' startles you, and it is only now that it sinks in that your hair is now made up of nest of snakes!  Fortunatly they seem to be fairly well behaved snakes, and you already feel comfortable with them." & DDUtils.RNRN &
            """Well then, it seems like my work here is done,"" the Hypnotist says, inturupting your thoughts.  ""If I can help you with anything else, don't hesitate to ask!"""

        Dim aTF As HGorgonTF = New HGorgonTF()
        aTF.step1()

        Dim p = Game.player1

        TextEvent.push(out, AddressOf CType(Game.hteach, HypnoTeach).back)
        p.drawPort()
        p.UIupdate()
        p.pState.save(p)
        p.sState.save(p)
    End Sub
End Class
