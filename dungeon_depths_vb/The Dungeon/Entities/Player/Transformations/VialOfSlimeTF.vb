Public Class VialOfSlimeTF
    Inherits Transformation
    Sub New(Optional cs As Integer = 2)
        MyBase.New(1, 0, 0, False)
        tfName = "VialOfSlimeTF"
        currStep = cs
        nextStep = getNextStep(cs)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "VialOfSlimeTF"
        nextStep = getNextStep(cs)
    End Sub

    Shared Sub step1()
        'In the future this will damage/destroy armor
        Dim p = Game.player
        p.inv.add("Dissolved_Clothes", 1)
        Equipment.clothesChange("Dissolved_Clothes")
        pushLblEventWithoutLoss("As you take stock of yourself, you notice that your clothing has been partially eaten away by a teal slime that you seem to sweating in small amounts.  This seems like something you are going to need to keep an eye on...")
        p.createP()
        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") += 1
        If Game.player.perks("googirltf") > -1 Then Game.player.perks("googirltf") += 1
    End Sub

    Sub step2()
        Dim p As Player = Game.player

        If p.prt.checkNDefFemInd(5, 7) Then
            Game.pushLstLog("Your hair resists being altered!")
        Else
            p.prt.haircolor = Color.FromArgb(180, 5, 245, 198)
            p.createP()
            p.perks("vsslimehair") = 0
            'Author Credit: Marionette
            pushLblEventWithoutLoss("The rogue slime starts moving upwards towards your head, your fingers unable to get a grip on the slippery goo as it works its way up your neck and into your hair. Despite your best attempts you just can’t get the bulk of the goo out. It almost feels like your trying to pull out your own hair... After a few more experimental tugs you confirm that the slime seems to have converted your hair to a much more gooey consistency. ")
        End If
        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") += 1
    End Sub
    Shared Sub step2Alt()
        Dim p As Player = Game.player
        If p.prt.checkNDefFemInd(5, 7) Then
            Game.pushLstLog("Your hair resists being altered!")
        Else
            p.prt.setIAInd(1, 12, True, True)
            p.prt.setIAInd(5, 21, True, True)
            p.prt.setIAInd(15, 26, True, True)
            p.prt.haircolor = Color.FromArgb(180, 255, 120, 255)
            p.createP()
            p.perks("vsslimehair") = 0
            pushLblEventWithoutLoss("The teal slime has taken on a pink hue now, and your hair has grown out a bit... Your hair is now made of a pink slime!")
        End If
        If Game.player.perks("googirltf") > -1 Then Game.player.perks("googirltf") += 1
    End Sub

    Sub step3()
        Dim p As Player = Game.player
        p.prt.skincolor = Color.FromArgb(230, 0, 255, 255)
        p.pForm = p.forms("Half-Slime")
        'Author Credit: Marionette
        pushLblEventWithoutLoss("Looking back you see you’ve gotten far enough away to catch your breath, the adrenalin that had driven you on now draining as your left breathing heavily. Too late you remember the Slime had landed a fairly large glob of slime on you as it quickly surges around your body. Your skin starts to tingle as you watch your skin soak in the goo, the color of it changing and even becoming nearly translucent. You are now a half-slime!")
        p.createP()
        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") += 1
    End Sub
    Shared Sub step3Alt()
        Dim p As Player = Game.player

        p.prt.skincolor = Color.FromArgb(230, 255, 102, 179)
        p.pForm = p.forms("Half-Slime")
        pushLblEventWithoutLoss("At first it seems like the slime your skin has slowly been soaking in seems to have dyed it, but as you inspect your hand and notice that you can almost see through it completely, you realize that its become more than just a different color...  You are now a half-slime!")
        p.createP()
        If Game.player.perks("googirltf") > -1 Then Game.player.perks("googirltf") += 1
    End Sub

    Sub step4()
        Dim p As Player = Game.player
        If p.equippedWeapon.getName.Equals("Magic_Girl_Wand") Or
            p.equippedWeapon.getName.Equals("Valkyrie_Sword") Then
            Equipment.weaponChange("Fists")
        End If

        p.health = 1

        p.prt.setIAInd(6, 5, True, True)
        If p.sex.Equals("Male") Then
            p.prt.setIAInd(9, 5, False, True)
        Else
            p.prt.setIAInd(9, 11, True, True)
        End If
        p.prt.setIAInd(10, 0, True, False)
        p.prt.setIAInd(13, 0, True, False)
        p.prt.setIAInd(16, 0, True, False)

        p.pForm = p.forms("Slime")
        Equipment.clothesChange("Naked")

        p.prt.skincolor = Color.FromArgb(200, p.prt.skincolor.R, p.prt.skincolor.G, p.prt.skincolor.B)

        'Author Credit: Marionette
        Dim out = ""
        out += "The impact of the goo was much more forceful than you expected, your foot ending up getting tripped on a loose stone as you stumbled and causing you to end up sprawled on the floor."
        If p.breastSize >= 4 Then
            out += "  Luckily most of the impact was absorbed by your bountiful breasts, the stone floor cold against your tits."
        Else
            out += "  Luckily you were able to catch yourself before smacking your head, the stone floor cold against the palms of your hands."
        End If
        out += "  Rolling over you to look back at the Slime, the creature having quickly closed the gap and now flowing over your feet. You try to kick it only to end up sinking your legs in further, soon enough the slime has made it past your crotch.\n\n"
        If p.prt.sexBool Then
            out += "A spike of pleasure hits you as you start to feel the Slime brush against your clit, you eyes widening as your legs are spread by the mass of goo. Unable to resist the gelatinous mass you watch as your feminine slit is slowly parted, a soft moan escaping your lips as you feel the cool goo pushing its way inside. About the same time you feel the Slime pushing into your anus as well which only adds to the pleasure. By now the Slime has reached past your chest and under your chin, you having stopped struggling and given in to the Slime’s advances. The goo inside your cunt reaches your cervix and with fluid ease pushes past it into your womb, the sudden flow of fluid now swelling your womb causing you to let out another loud moan. Seizing the opportunity the Slime pushes up and into your mouth, forcing it to stay open as your forced to swallow mouthful after mouthful of goo. Your eyes roll back as the sensations start to overwhelm you, your hips rocking back and forth as you feel yourself begin to climax. The sensation keeps rising as your stomach swells with goo, your back arching as you reach the epitome of pleasure. Its like your body is being filled with liquid pleasure, your vision now obscured as your head is fully engulfed in goo. Your orgasm starts to taper off after a little while only to start building back up almost immediately. This happens again and again, each time you feel as if you are practically melting with pleasure."
        Else
            out += "As the Slime writhes and pushes around your crotch you can’t help but to be aroused at the strange sensation, your penis starting to harden against your will. Suddenly you feel a surge of goo spread your anus wide, a meak moan coming from your lips as you feel the cool fluid starting to push into your depths. By now the Slime has reached past your chest and under your chin, you having stopped struggling and given in to the Slime’s advances. Deeper and deeper the Slime pushes into your anus, an electric jolt of pleasure shooting through your body as the goo hits your prostate in just the right way. Your cock pulses as you cum a little on the spot, the white fluid sputtering into the goo as you let out another loud moan. Seizing the opportunity the Slime pushes up and into your mouth, forcing it to stay open as your forced to swallow mouthful after mouthful of goo. Your eyes roll back as the sensations start to overwhelm you, your now over sensitive cock dribbling a constant stream of precum into the goo as your hips start rocking back and forth reflexively. The sensation keeps rising as your stomach swells with goo, your back arching as you reach the epitome of pleasure. Its like your body is being filled with liquid pleasure, your vision now obscured as your head is fully engulfed in goo. You can’t hold back any longer, your back arching as you begin to cum heavily into the Slime. You can feel the warmth of your cum flowing from your cock up along your front and towards your head, whether on purpose or just caught in the flow it seems the Slime is forcing you to drink your own cum as you taste your salty sweetness passing across your tongue. Just as your first climax is dying down you feel another one building up, the Slime uncaring as to your oversensitized cock."
        End If

        out += "\A few hours later…\nYour last orgasm is dying off as you lay on the stone floor. You try to pick yourself up and end up flopping wetly to the floor. Confused you look down at your body, realizing that the Slime all around you IS you. The Slime must of filled you up and turned you into a Slime yourself! Focusing on your old form you slowly form yourself into a rough approximation of yourself to the best of your ability. Now back in a much more familiar form you pick gather your gear prepare to face the dungeon once more in your new gooey form. You are now a Slime! (You will restore to this form)"
        pushLblEventWithoutLoss("Nearly as soon as you make contact with the slime, a reaction begins and you start to melt.  Suprisingly, this doesn't really hurt so much as just feel weird, and you figure that with how much of your body was gelatinous this must have been just enough to finish you off.  Now a puddle, you further reflect that regardless of how you started out, you probably are just a slime now.  Being a sentient ball of goo means you can easily reshape your body, right?  Focusing all your willpower, you pull your body into a rough aproximation of yourself.  You are now a slime! (You will restore to this form)")
        p.createP()

        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") = -1

        p.sState.save(p)
        If Transformation.canBeTFed(p) Then p.pState.save(p)
    End Sub
    Shared Sub step4Alt()
        Dim p As Player = Game.player

        p.pForm = p.forms("Goo Girl")

        If p.sex.Equals("Male") Then
            p.MtF()
        End If

        Equipment.clothesChange("Naked")

        p.breastSize = 4
        p.reverseBSRoute()

        p.prt.setIAInd(6, 5, True, True)
        p.prt.setIAInd(8, 18, True, True)
        p.prt.setIAInd(9, 35, True, True)
        p.prt.setIAInd(10, 0, True, False)
        p.prt.setIAInd(13, 0, True, False)
        p.prt.setIAInd(16, 0, True, False)

        p.prt.setIAInd(1, 27, True, True)
        p.prt.setIAInd(5, 30, True, True)
        p.prt.setIAInd(15, 28, True, True)
        Dim athe = "a"
        If p.health <= 0 Then athe = "the"
        pushLblEventWithoutLoss("Nearly as soon as you make contact with the slime, a reaction begins and you start to melt.  Suprisingly, this doesn't really hurt so much as just feel weird, and you figure that with how much of your body was gelatinous this must have been just enough to finish you off.  While you are reflecting on your current state, " & athe & " Goo Girl glides toward you and giggles. " & vbCrLf & vbCrLf &
                                """Here, let me help you out!  Reforming can be kinda hard, so I'll just hop in and do it for you.""" & vbCrLf & vbCrLf &
                                "Before you can protest, she dives into your body and the two of you merge into a single puddle.  You are powerless to do anything but watch as she raises the two of you back up into a feminine humanoid body.  Once upright, you are able to resist slightly, though not enough to stop her from swelling your breasts to a massive size.  Noticing your resistance, she grabs the nucleus that contains your mind with your shared body, and smushes it into her own.  Suddenly, you can, like, totally control your hot body again!  You are now a goo girl. (You will restore to this form)")

        p.prt.skincolor = Color.FromArgb(200, p.prt.skincolor.R, p.prt.skincolor.G, p.prt.skincolor.B)
        p.createP()

        p.sState.save(p)
        If Transformation.canBeTFed(p) Then p.pState.save(p)

        p.health = 1
        If Game.player.perks("googirltf") > -1 Then Game.player.perks("googirltf") = -1
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub
    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player

        Select Case currStep
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
    Public Shared Sub pushLblEventWithoutLoss(ByRef out As String)
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub
    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub
End Class
