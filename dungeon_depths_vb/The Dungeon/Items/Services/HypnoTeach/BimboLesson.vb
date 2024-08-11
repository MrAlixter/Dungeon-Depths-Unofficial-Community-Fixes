Public Class BimboLesson
    Inherits Item

    Public Const ITEM_NAME As String = "Bimbo_Lesson"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 87
        tier = Nothing

        '|Item Flags|
        usable = true
        rando_inv_allowed = False
        can_be_stolen = False
        MyBase.onBuy = AddressOf teach

        '|Stats|
        count = 0
        value = 150

        '|Description|
        setDesc("""*sigh* This lesson is part of an ill-advised negotiation tactic with a shady bastard of a wizard, and now I am contractually obligated to provide it to my customers, lest he release some 'trigger' words to the public.  Once you listen to it, his magic will take its course and anything that happens to you is out of my hands.  'Buyer beware', I suppose.""")
    End Sub

    Sub teach()
        count = 0
        Game.hideNPCButtons()
        If Game.hteach.form.Equals("Bimbo") Then
            CType(Game.hteach, HypnoTeach).hypnotize("Ooh!  Like, you wanna be a bimbo too?  I can do that for you!  Here, lemme get my- uh, my other necklace.  Ooh, I'm gonna make you so cute..." & DDUtils.RNRN &
                                              "Like, ok... see my shiny gem?  Watch it for a bit... watch it glimmer... as it goes side to side... swinging... swinging..." & DDUtils.RNRN &
                                              "Sink deeper and deeper... deeper... and deeper... until you just..." & DDUtils.RNRN &
                                              "*giggle* *SNAP*" & DDUtils.RNRN &
                                              "...drift away...", AddressOf display)
        Else
             CType(Game.hteach, HypnoTeach).hypnotize("*sigh* Fine, whatever.  You're very sleepy.  Very sleeeepy.  Here, a pendant.  Yayyyyy.", AddressOf display)
        End If
    End Sub
    Sub display()
        If Game.hteach.form.Equals("Bimbo") Then
            TextEvent.push("As soon as she snaps, your entire reality fades away." & DDUtils.RNRN &
                           "You can't bother to recall who you are, or what you're doing, focusing instead solely on your mistresses' silky voice, though in your haze you don't understand much of what's being said." & DDUtils.RNRN &
                           "You pass in and out of conciousness several times until things seem to get a little clearer.  A soft haze lingers in your mind, but it feels too, like, comfy to be bad, so you just ignore it..." & DDUtils.RNRN &
                           """...annnd one.  Hey sleepyhead, wake up!  Are you ok?"" the teacher asks, stowing something in her cleavage and adjusting her glasses." & DDUtils.RNRN &
                           "Something seems different, but it probably isn't worth thinking about.", AddressOf tf)
        Else
            TextEvent.push("Unimpressed, you give the so called hypnotist a questioning glare." & DDUtils.RNRN &
                           """What?  It doesn't matter."" she states, looking mildly irate.  ""The spell portion of this 'lesson' essentially does all the work, both mental and physical, with this one.  Mr. Vendor suggested that the travelling wizard might be a good opportunity to weave some transformative magic into my lessons, and I set up a meeting.  I made the mistake of implying that he might not be worth his price, and the next thing I know I'm nearly naked, covered in Panacea and mystery fluids, and apperantly under a magic contract so one-sided I'm suprised I have any free will left at all.""" & DDUtils.RNRN & """Well, either way you've paid me, so I'm obligated to add at least one of us to this damned dungeon's pool of large-breasted blondes.""  the hypnotist muses, adjusting her glasses.  She raises her right hand, eyes now glowing with a sinister pink light.  While you know you should probably look away, something about her gaze is almost... binding..." & DDUtils.RNRN &
                           """Now then, my mindless sex-doll to be..."" despite her lack of finess, you feel yourself drifting away all the same as she snaps and commands, ""Sleep.""", AddressOf tf)
        End If
    End Sub
    Sub tf()
        Dim bTF As BimboTF = New BimboTF(2, 0, 0.25, True)
        bTF.doubleTf()
        Game.player1.drawPort()
        CType(Game.hteach, HypnoTeach).back()
    End Sub
End Class
