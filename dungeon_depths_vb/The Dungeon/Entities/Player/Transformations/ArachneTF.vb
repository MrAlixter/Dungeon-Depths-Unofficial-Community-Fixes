Public NotInheritable Class ArachneTF
    'Displayed passages proofread and formatted as of 7/28/2019
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.arachne

    Sub New(cs As Integer)
        MyBase.New(4, 0, 100, False)
        tf_name = TF_IND
        curr_step = cs
        next_step = getNextStep(cs)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As Player = Game.player1
        If p.sex.Equals("Male") Then
            p.prt.setIAInd(pInd.eyes, 9, False, True)
        Else
            p.prt.setIAInd(pInd.eyes, 20, True, True)
        End If

        TextEvent.push("Somewhat concerningly, the color of the veins in your hands has darkened to a jet black.  While you aren't exactly a biologist, it's fairly obvious what the cause is..." & DDUtils.RNRN &
                       """Arachne venom, nasty stuff..."" you remember someone saying, ""Magic, too...  If you get bitten you'd be lucky to still be human a few hours later." & DDUtils.RNRN &
                       "More than that, once it's done with you there isn't much that can be done to bring you back.  If you know a Shopkeeper with anti-venom for sale, keep them close, yeah?""" &
                       "Well, it seems like it’s only a matter of time before you start changing.  The real question is what you should do about it.")

        If Game.player1.perks(perk.svenom) > -1 Then Game.player1.perks(perk.svenom) += 1
    End Sub

    Sub step2()
        Dim p As Player = Game.player1

        p.prt.setIAInd(pInd.eyes, 21, True, True)
        Dim out = ""

        If p.sex.Equals("Male") Then
            p.prt.setIAInd(pInd.face, 0, True, False)
            If p.breastSize < 1 Then be()
            out += "Your facial structure softens, and you can feel your chest expand slightly.  It seems like you are becoming more feminine!" & DDUtils.RNRN
        End If

        p.prt.changeSkinColor(DDUtils.cShift(p.prt.skincolor, Color.LightSlateGray, 15))

        out += "Seemingly out of nowhere, your spider bite throbs and your vision goes black." & DDUtils.RNRN &
               "Fortunately it returns a few seconds later, but after it does everything seems slightly... off.  Shadows seem less dark, while bright areas seem no brighter, and everything has a fuzzy grain to it." &
               "Your skin even seems to be a little greyer, a grim reminder of the dark venom that has been working its way through your veins..."

        TextEvent.push(out)
        If Game.player1.perks(perk.svenom) > -1 Then Game.player1.perks(perk.svenom) += 1
    End Sub

    Sub step3()
        Dim p As Player = Game.player1
        Dim out = ""


        p.prt.changeSkinColor(DDUtils.cShift(p.prt.skincolor, Color.LightSlateGray, 15))

        If p.sex.Equals("Male") Then
            p.MtF()
            If p.breastSize < 2 Then be()
            out += "While you aren't sure exactly when, you have become fully female after being exposed to the arachne venom.  While it feels like this should be a huge deal, the throbbing headache that has also come with the venom's effect has you more concerned..." & DDUtils.RNRN
        End If

        If p.buttSize < 2 Then p.buttSize = 2 Else p.ue()

        p.prt.setIAInd(pInd.eyes, 22, True, True)

        out += "With every beat of your heart, your vision becomes clearer and clearer.  It isn't until you blink and feel eight eyelids reopen that you realize why." & DDUtils.RNRN &
               "You have eight eyes now!  With six on the front of your head, and one on each side, not only is your vision sharper, but your depth of field has expanded as well!" & DDUtils.RNRN &
               "Between your improved sight and noticeably faster reflexes, it seems that the venom is actually improving your body; contrary to what the rumors you'd heard." & DDUtils.RNRN &
               "You do seem more bottom-heavy though, with your ass easily spilling out of clothes that fit perfectly just last night..."

        TextEvent.push(out)
        If Game.player1.perks(perk.svenom) > -1 Then Game.player1.perks(perk.svenom) += 1
    End Sub

    Sub step4()
        Dim p As Player = Game.player1

        If p.sex.Equals("Male") Then
            p.MtF()
            If p.breastSize < 2 Then be()
        End If

        If p.breastSize < 2 Then be()
        p.prt.setIAInd(pInd.eyes, 22, True, True)
        p.prt.setIAInd(pInd.rearhair, 8, True, True)
        p.prt.setIAInd(pInd.midhair, 19, True, True)
        p.prt.changeSkinColor(DDUtils.cShift(p.prt.skincolor, Color.LightSlateGray, 5))

        TextEvent.push("The Arachne Venom's familiar throbbing headache flares up so suddenly that it forces you to the ground and to the brink of passing out." & DDUtils.RNRN &
                       "You try to tough it out, until a splitting pain in your legs- unlike anything you've ever felt before- convinces you that unconciousness might be a blessing." & DDUtils.RNRN &
                       "As your vision fades into darkness, you collapse on the floor." & DDUtils.RNRN &
                       "Hours pass...", AddressOf step4pt1)
        p.changeForm("Arachne")
        p.lust += 5
    End Sub
    Sub step4pt1()
        Game.player1.prt.setIAInd(pInd.tail, 2, True, False)
        Game.player1.drawPort()
        TextEvent.push("Many eyes snapping open at once, you jump to your feet.  You have no idea how long you were out, but apart from some stiffness in your lower joints, you feel fine now.  An experience like that would have probably killed the old, weak person that you used to be; your new form seems far more reliable." &
                       "While picking up your things, you catch a glimpse of your rear over your shoulder and realize at once that you’ve undergone a more drastic transformation than you may have first thought.  From the waist down, your body has morphed into that of a massive spider!" & DDUtils.RNRN &
                       "Your waist leads directly onto your thorax, which in turn leads to a massive abdomen that is topped out with a spinneret, and it takes a few seconds for this to fully process.  For as delicate as your eight new limbs, a quick test reveals that they can strike the tiles around you with enough force to shatter them." & DDUtils.RNRN &
                       "Before you can experiement further, though, your heightened senses alert you to a presence behind you...", AddressOf step4pt2)
    End Sub
    Sub step4pt2()
        Dim p As Player = Game.player1

        p.prt.setIAInd(pInd.rearhair, 17, True, True)
        p.prt.setIAInd(pInd.midhair, 21, True, True)
        p.prt.setIAInd(pInd.fronthair, 18, True, True)
        p.prt.setIAInd(pInd.hairacc, 10, True, False)

        TextEvent.push("Lurking behind you is another arachne, and it is clear from her poise that she is an experienced huntress.  You stiffen up as her piercing gaze locks onto you, and it becomes clear that you have less control over the situation than you thought you might." & DDUtils.RNRN &
                       """Well, it seems that our venom has finally run its course,"" she muses, approaching you.  As she speaks, her words supplant any thoughts flowing through your head, and you find yourself completely at her mercy.  ""Ages ago, an enchanted spider bit its enchantress and the first of our kind was awakened.  Since that fateful day, the Sisterhood of Arachne has spread throughout these cursed passages with the singular goal of claiming all who enter.""" & DDUtils.RNRN &
                       "Caressing your cheek, the huntress begins twisting your hair into a style you have seen on Arachne before." & DDUtils.RNRN &
                       """Now that you are one of us, you are free to go about, well, whatever you'd like.  Of course, the spiders of this dungeon may not share this understanding, but as long as you are Arachne our huntresses will leave you be.""" & DDUtils.RNRN &
                       "Finishing with your hair, she kisses you on the cheek before whispering in your ear...", AddressOf step4pt3)
        p.lust += 20

        p.drawPort()
    End Sub
    Sub step4pt3()
        Dim p As Player = Game.player1
        If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") Or
            p.equippedWeapon.getName.Equals("Valkyrie_Sword") Then
            EquipmentDialogBackend.weaponChange(p, "Fists")
        End If

        p.setStartStates()
        TextEvent.push("""Whatever you choose to do going forward, though, forget who you were before.  You are one of us now, and our venom is a gift that should be shared...""" & DDUtils.RNRN &
                        "With that and a *thwip* she vanishes as suddenly as she appeared, her mental web slowly lifting from your mind." & DDUtils.RNRN &
                        "Your base form is now that of an Arachne!  Should you revert to your start state, this is what you will become.")
        stopTF()
    End Sub

    Public Shared Sub rapidTF(ByRef p As Player)
        If p.sex.Equals("Male") Then
            p.MtF()
            If p.breastSize < 2 Then p.be()
        End If

        If p.breastSize < 2 Then p.be()

        p.prt.setIAInd(pInd.eyes, 22, True, True)
        p.prt.setIAInd(pInd.rearhair, 8, True, True)
        p.prt.setIAInd(pInd.midhair, 19, True, True)
        p.prt.setIAInd(pInd.tail, 2, True, False)
        p.prt.changeSkinColor(DDUtils.cShift(p.prt.skincolor, Color.LightSlateGray, 35))

        p.changeForm("Arachne")
        p.lust += 35

        p.drawPort()
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player1.perks(perk.avenom) = -1
    End Sub

    Public Overrides Function getTFDone() As Boolean
        Return MyBase.getTFDone() Or Game.player1.perks(perk.avenom) < 0 And Game.player1.perks(perk.svenom) < 0
    End Function
    Public Overrides Function getNextStep(stage As Integer) As Action
        If (Game.player1.perks(perk.avenom) < 0 And Game.player1.perks(perk.svenom) < 0) Or Game.player1.formName.Equals("Arachne") Then
            Return AddressOf stopTF
        End If
        If Game.player1.perks(perk.svenom) > -1 Then stage = Game.player1.perks(perk.svenom)

        Select Case stage
            Case 1
                Return AddressOf step1
            Case 2
                Return AddressOf step2
            Case 3
                Return AddressOf step3
            Case 4
                Return AddressOf step4
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        If Game.player1.perks(perk.avenom) > -1 Then
            turns_until_next_step = 1
            turns_until_next_step += generatWILResistance()
            turns_until_next_step += -2 + Int(Rnd() * 4)
        ElseIf Game.player1.perks(perk.svenom) > -1 Then
            stopTF()
        End If
    End Sub

    Sub be()
        Dim p = Game.player1
        If p.breastSize < 7 Then
            p.breastSize += 1
        End If
    End Sub
End Class
