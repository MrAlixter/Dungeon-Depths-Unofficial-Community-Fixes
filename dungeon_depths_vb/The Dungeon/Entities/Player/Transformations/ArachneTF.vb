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
        Game.pushLblEvent("\tSomewhat concerningly, the color of the veins in your hands have darkened to a jet black.  While you aren't exactly a biologist, it's fairly obvious that the venom you were exposed to is causing this.\n\n" &
                          """Arachne venom, nasty stuff,"" you remember someone telling you once, ""It's a powerful mutator, and if you take a bite, you'll be lucky if you even remain human for a single night.  More than that, once it's done with you there isn't much that can be done to bring you back.  That's why antivenom like what the Shopkeeper has is so important.""\n\n" &
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
            out += "\tYour facial structure softens, and you can feel your chest expand slightly.  It seems like you are becoming more feminine!\n\n"
        End If

        p.prt.changeSkinColor(DDUtils.cShift(p.prt.skincolor, Color.LightSlateGray, 15))

        out += "Seemingly out of nowhere, your wound throbs, and your vision goes black.  Fortunately, it quickly returns, but everything seems slightly . . . off.  While shadows seem less dark, bright areas seem no brighter, and everything looks slightly fuzzier.\n\n" &
               "As you examine yourself, you can tell that the venom has been progressing through your darkening veins, and while you aren't completely sure, your skin also seems to have become marginally greyer."

        Game.pushLblEvent(out)
        If Game.player1.perks(perk.svenom) > -1 Then Game.player1.perks(perk.svenom) += 1
    End Sub

    Sub step3()
        Dim p As Player = Game.player1

        p.prt.setIAInd(pInd.eyes, 22, True, True)
        Dim out = ""

        If p.sex.Equals("Male") Then
            p.MtF()
            If p.breastSize < 2 Then be()
            out += "\tWhile you aren't sure exactly when, you have become fully female since exposure to the venom.  While you feel like this should be a huge deal, the throbbing of the venom through your head has you more concerned.\n\n"
        End If

        p.prt.changeSkinColor(DDUtils.cShift(p.prt.skincolor, Color.LightSlateGray, 15))

        out += "With every beat of your heart, your vision becomes clearer and clearer.  It isn't until you blink and feel eight eyelids reopen that you realize why.  You have eight eyes now! With six on the front of your head, and one on each side, not only is your vision sharper, but your field of vision has expanded as well!\n\n" &
               "Between your improved sight and noticeably quickened reflexes, it seems that the venom is actually improving your body, contrary to what you had heard of it.  Examining your body further, you do notice that you seem more bottom heavy than before, with your ass easily spilling over clothes that fit perfectly just last night.  You set back out, excited for what the venom brings next."

        Game.pushLblEvent(out)
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

        Game.pushLblEvent("\tWhile for the most part the venom seems to be concentrated in your lower body now, all at once its familiar throb returns so suddenly it forces you to the ground and onto the brink of passing out.  It isn't until a pain unlike anything you've ever felt before flares up in your legs that you decide that unconciousness might be a blessing, and allow yourself to go under.", AddressOf step4pt1)
        p.changeForm("Arachne")
        p.lust += 5
    End Sub
    Sub step4pt1()
        Game.player1.prt.setIAInd(pInd.tail, 2, True, False)
        Game.player1.drawPort()
        Game.pushLblEvent("\tYour many eyes snap open, and you jump to your feet.  You have no idea how long you were out, but apart from some stiffness in your lower joints, you feel fine now.  Impressed by your new stamina, you remark to yourself that an experience like that would have killed the old, weak person that you used to be.\n\n" &
                          "While picking up your things, you catch a glimpse of your rear over your shoulder and realize at once that you’ve undergone a drastic transformation.  From the waist down, your body has morphed into that of a massive spider.  Your waist leads directly onto your thorax, which in turn leads to a massive abdomen that is topped out with a spinneret, and it takes a few seconds for this drastic change to fully process through your brain.  Testing out your eight new limbs, you find that for as delicate as they look, you can strike the tiles around you with enough force to shatter them.\n\n" &
                          "Mere moments later, your newly heightened senses alert you to a presence behind you.", AddressOf step4pt2)
    End Sub
    Sub step4pt2()
        Dim p As Player = Game.player1

        p.prt.setIAInd(pInd.rearhair, 17, True, True)
        p.prt.setIAInd(pInd.midhair, 21, True, True)
        p.prt.setIAInd(pInd.fronthair, 18, True, True)
        p.prt.setIAInd(pInd.hairacc, 10, True, False)

        Game.pushLblEvent("\tStanding behind you is another arachne, and it is clear from her posture that she is one of the more experienced huntresses.  You stiffen up, and as the she gazes into your eyes you find yourself with a lot less control over the situation than you thought you had.\n\n" &
                          """Well, it seems that our venom has finally run its course,"" she muses, approaching you.  As she speaks, her words supersede any thoughts flowing through your head, and you find yourself completely at her mercy.  ""Our species began when an enchanted spider bit its enchantress, and she underwent a similar process to what you have just experienced.  Since that fateful day, the Sisterhood of Arachne has spread throughout these cursed passages with the singular goal of claiming all whom enter into our ranks. Now that you are one of us, you are free to go about your business without fear of our interference.""\n\n" &
                          "Caressing your cheek, the huntress begins twisting your hair into a style you have seen on Arachne before.\n\n""Of course, the spiders of this dungeon may not share this understanding, but as long as you are Arachne our huntresses will leave you be.""\n\n" &
                          "Finishing with your hair, she kisses you on the cheek before whispering in your ear,\n\n ""Whatever you choose to do, forget who you were before.  You are one of us now, and our venom is a gift that should be passed on."".\n\n\" &
                          "With that and a *thwip*, she vanishes as suddenly as she appeared, the her mental web slowly lifting from your mind.", AddressOf step4pt3)
        p.lust += 20

        p.drawPort()
    End Sub
    Sub step4pt3()
        Dim p As Player = Game.player1
        If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") Or
            p.equippedWeapon.getName.Equals("Valkyrie_Sword") Then
            Equipment.weaponChange(p, "Fists")
        End If

        p.setStartStates()
        Game.pushLblEvent("Your base form is now that of an Arachne!  Should you revert to your start state, this is what you will become.")
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

    Public Overrides Function getNextStep(stage As Integer) As Action
        If (Game.player1.perks(perk.avenom) = -1 And Game.player1.perks(perk.svenom) = -1) Or Game.player1.formName.Equals("Arachne") Then
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
