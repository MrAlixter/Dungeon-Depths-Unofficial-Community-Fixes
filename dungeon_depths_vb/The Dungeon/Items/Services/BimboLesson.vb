Public Class BimboLesson
    Inherits Item

    Sub New()
        '|ID Info|
        MyBase.setName("Bimbo_Lesson")
        id = 87
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(True)
        MyBase.isRandoTFAcceptable = False
        MyBase.onBuy = AddressOf teach

        '|Stats|
        MyBase.count = 0
        MyBase.value = 150

        '|Description|
        MyBase.setDesc("""*sigh* This lesson is part of an ill-advised negotiation tactic with a shady bastard of a wizard, and now I am contractually obligated to provide it to my customers, lest he release some 'trigger' words to the public.  Once you listen to it, his magic will take its course and anything that happens to you is out of my hands.  'Buyer beware', I suppose.""")
    End Sub

    Sub teach()
        count = 0
        Game.hideNPCButtons()
        CType(Game.hteach, HTeach).hypnotize("*sigh* Fine, whatever.  You're very sleepy.  Very sleeeepy.  Here, a pendant.  Yayyyyy.", AddressOf display)
    End Sub
    Sub display()
        Game.pushLblEvent("Unimpressed, you give the so called hypnotist a questioning glare." & DDUtils.RNRN &
                          """What?  It doesn't matter."" she states, looking mildly irate.  ""The spell portion of this 'lesson' essentially does all the work, both mental and physical, with this one.  Mr. Vendor suggested that the travelling wizard might be a good opportunity to weave some transformative magic into my lessons, and I set up a meeting.  I made the mistake of implying that he might not be worth his price, and the next thing I know I'm nearly naked, covered in Panacea and semen, and apperantly under a magic contract so one-sided I'm suprised I have any free will left at all.""" & DDUtils.RNRN & """Well, either way you've paid me, so I'm obligated to add at least one of us to this damned dungeon's pool of large-breasted blondes.""  the hypnotist muses, adjusting her glasses.  She raises her right hand, eyes now glowing with a sinister pink light.  While you know you should probably look away, something about her gaze is almost...binding..." & DDUtils.RNRN &
                          """Now then, my mindless sex-doll to be..."" despite her lack of finess, you feel yourself drifting away all the same as she snaps and commands, ""Sleep.""", AddressOf tf)
    End Sub
    Sub tf()
        Dim bTF As BimboTF = New BimboTF(2, 0, 0.25, True)
        bTF.doubleTf()
        Game.player1.drawPort()
        CType(Game.hteach, HTeach).back()
    End Sub
End Class
