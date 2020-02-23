Public NotInheritable Class SlimeETF
    Inherits Transformation
    Sub New(Optional cs As Integer = 2)
        MyBase.New(1, 0, 0, False)
        tfName = "SlimeETF"
        currStep = cs
        nextStep = getNextStep(cs)
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "SlimeETF"
        nextStep = getNextStep(cs)
    End Sub

    Shared Sub step1()
        'In the future this will damage/destroy armor
        Dim p = Game.player
        p.inv.add("Dissolved_Clothes", 1)
        Equipment.clothesChange("Dissolved_Clothes")
        pushLblEventWithoutLoss("As you take stock of yourself, you notice that your clothing has been partially eaten away by a teal slime that you seem to sweating in small amounts.  This seems like something you are going to need to keep an eye on...")
        p.drawPort()
        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") += 1
        If Game.player.perks("googirltf") > -1 Then Game.player.perks("googirltf") += 1
    End Sub

    Sub step2()
        Dim p As Player = Game.player

        p.prt.haircolor = Color.FromArgb(180, 5, 245, 198)
        p.drawPort()
        p.perks("vsslimehair") = 0
        'Author Credit: Marionette
        pushLblEventWithoutLoss("The rogue slime starts moving upwards towards your head, your fingers unable to get a grip on the slippery goo as it works its way up your neck and into your hair. Despite your best attempts you just can’t get the bulk of the goo out. It almost feels like your trying to pull out your own hair... After a few more experimental tugs you confirm that the slime seems to have converted your hair to a much more gooey consistency. ")

        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") += 1
    End Sub
    Sub step3()
        Dim p As Player = Game.player
        p.prt.skincolor = Color.FromArgb(230, 0, 255, 255)
        p.pForm = p.forms("Half-Slime")
        'Author Credit: Marionette
        pushLblEventWithoutLoss("Looking back you see you’ve gotten far enough away to catch your breath, the adrenalin that had driven you on now draining as your left breathing heavily. Too late you remember the Slime had landed a fairly large glob of slime on you as it quickly surges around your body. Your skin starts to tingle as you watch your skin soak in the goo, the color of it changing and even becoming nearly translucent. You are now a half-slime!")
        p.drawPort()
        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") += 1
    End Sub
    Sub step4()
        Dim p As Player = Game.player
        If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") Or
            p.equippedWeapon.getName.Equals("Valkyrie_Sword") Then
            Equipment.weaponChange("Fists")
        End If

        p.health = 1

        p.prt.setIAInd(pInd.ears, 5, True, True)
        If p.sex.Equals("Male") Then
            p.prt.setIAInd(pInd.eyes, 5, False, True)
        Else
            p.prt.setIAInd(pInd.eyes, 11, True, True)
        End If
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

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
        pushLblEventWithoutLoss(out)
        p.drawPort()

        If Game.player.perks("slimetf") > -1 Then Game.player.perks("slimetf") = -1

        p.setStartStates()
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
