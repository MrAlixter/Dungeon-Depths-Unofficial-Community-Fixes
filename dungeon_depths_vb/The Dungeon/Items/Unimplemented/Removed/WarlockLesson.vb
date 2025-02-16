Public Class WarlockLesson
    Inherits HypnoService

    Sub New()
        '|ID Info|
        setName("Warlock_Lesson")
        id = 124
        tier = Nothing

        '|Item Flags|
        usable = false
        rando_inv_allowed = False
        MyBase.onBuy = Sub() teach(h_ind.misc)

        '|Stats|
        count = 0
        value = 5900

        '|Description|
        setDesc("""Are you a fan of overwhelming magical power, without regard to its cost?  Do you mind bending to the whim of, say, a goddess of forgetfulness, in order to achive your hopes and dreams?  Perhaps the Warlock life is for you...""")
    End Sub

    '| - OUTCOMES - |
    Protected Overrides Sub doTrigger(ByRef p As Player, ByVal i As h_ind)
        'Don't do anything
    End Sub
    Protected Overrides Function doHypnosis(ByRef plr As Player, ByVal i As h_ind, Optional ByVal hypnoDesc As String = "") As Boolean
        TextEvent.pushNPCDialog("Before we get started, I just want to make sure you really want this.  This lesson will completely change who you are and were, forever.", AddressOf warning)

        Return True
    End Function

    '| - MISC - |
    Protected Overrides Function canHypnotize(ByRef p As Player) As Boolean
        Return Not p.className.Equals("Warlock")
    End Function

    '| - TRANSFORMATION - |
    Sub warning()
        TextEvent.pushYesNo("Start over as a Warlock?", AddressOf tf, AddressOf cancel)
    End Sub
    Sub cancel()
        Game.player1.gold += value
        CType(Game.hteach, HypnoTeach).back()
    End Sub
    Sub tf()
        Dim p As Player = Game.player1
        CType(Game.hteach, HypnoTeach).hypnotize(getHypnoDesc(p), p, h_ind.misc, AddressOf tf2)
    End Sub
    Sub tf2()
        Dim out = "As soon as she snaps, your entire reality fades away.  You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses voice, though in your haze you don't understand much of what she's saying.  You pass in and out of conciousness several times until gradually you begin to clearly hear what she's saying." & DDUtils.RNRN &
            """...for the last time, I am not interested in your cult!"" the hypnotist teacher states, sounding mildly annoyed." & DDUtils.RNRN &
            "A cult?  Hardly...  While you're certainly in an arrangement with a deity, it isn't that of a worshipper and goddess so much as that she offered you a great deal of magical power in exchange for whole bunch of favors.  Your benefactor Uvona, Goddess of Fugue, rarely calls these favors in, though when she does it's even rarer that you remember them.  Are there cults devoted to Uvona? Probably, but you would never-" & DDUtils.RNRN &
            """Well, I think you're done at least..."" the Hypnotist says, inturupting your thoughts.  ""If I can help you with anything else, don't hesitate to ask."""

        Dim p = Game.player1

        p.inv.add("Warlock's_Robes", 1)
        EquipmentDialogBackend.armorChange(p, "Warlock's_Robes")
        p.inv.add("Ring_of_Uvona", 1)
        Equipment.accChange(p, "Ring_of_Uvona")


        p.changeClass("Warlock")

        TextEvent.push(out, AddressOf CType(Game.hteach, HypnoTeach).back)
        p.drawPort()
        p.UIupdate()
        p.pState.save(p)
        p.sState.save(p)
    End Sub
End Class
