Public NotInheritable Class SlimeETF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.slime

    Sub New(Optional cs As Integer = 2)
        MyBase.New(1, 0, 0, False)
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
        Dim p = Game.player1

        Dim out As String = "Teal slime coats your " & DDUtils.amrOrClth(p) & "." & DDUtils.RNRN

        If Not p.equippedArmor.getAName.Equals("Naked") And Not p.equippedArmor.getAName.Contains("Armor") And p.equippedArmor.getAntiSlutInd = -1 Then
            TextEvent.push(out & "With a caustic hiss it evaporates, eating into your gear signifigantly." & DDUtils.RNRN &
                           Math.Max(p.equippedArmor.durability - 50, 0) & " durability remains on your " & p.equippedArmor.getAName.Replace("_", " ") & "...")
            p.equippedArmor.damage(50)
            If p.inv.getCountAt(DissolvedClothes.ITEM_NAME) < 1 Then p.inv.add(DissolvedClothes.ITEM_NAME, 1)
            EquipmentDialogBackend.armorChange(p, "Dissolved_Clothes")
        ElseIf p.equippedArmor.getAName.Contains("Armor") Or p.equippedArmor.getAntiSlutInd <> -1 Then
            TextEvent.push(out & "With a caustic hiss it evaporates, eating into your gear." & DDUtils.RNRN &
                           Math.Max(p.equippedArmor.durability - 25, 0) & " durability remains on your " & p.equippedArmor.getAName.Replace("_", " ") & "...")
            p.equippedArmor.damage(25)
        End If

        If p.equippedArmor.getAName = "Naked" Or p.equippedArmor.getAName.Equals(DissolvedClothes.ITEM_NAME) Then
            If p.perks(perk.slimetf) > -1 Then p.perks(perk.slimetf) += 1
        Else
            curr_step -= 1
        End If
    End Sub

    Sub step2()
        Dim p As Player = Game.player1

        p.prt.haircolor = Color.FromArgb(180, 5, 245, 198)
        p.drawPort()
        p.perks(perk.vsslimehair) = 0

        'Author Credit: Marionette
        TextEvent.push("The rogue slime starts moving upwards towards your head, your fingers unable to get a grip on the slippery goo as it works its way up your neck and into your hair." & DDUtils.RNRN &
                       "Despite your best attempts you just can’t get the bulk of the goo out.  It almost feels like your trying to pull out your own hair..." & DDUtils.RNRN &
                       "After a few more experimental tugs you confirm that the slime seems to have converted your hair to a much more gooey consistency. ")

        If Game.player1.perks(perk.slimetf) > -1 Then Game.player1.perks(perk.slimetf) += 1
    End Sub

    Sub step3()
        Dim p As Player = Game.player1

        p.changeForm("Half-Slime")
        p.prt.skincolor = Color.FromArgb(230, 0, 255, 255)

        p.drawPort()

        'Author Credit: Marionette
        TextEvent.push("Looking back, you see you’ve gotten far enough away to catch your breath." & DDUtils.RNRN &
                       "The adrenaline that had driven you on now drains, and you are left breathing heavily.  You realize too late that the Slime had landed a fairly large glob of slime on you, as it quickly surges around your body." & DDUtils.RNRN &
                       "Your skin starts to tingle as you watch your skin soak in the goo, the color of it changing and even becoming nearly translucent." & DDUtils.RNRN &
                       "You are now a half-slime!")

        If Game.player1.perks(perk.slimetf) > -1 Then Game.player1.perks(perk.slimetf) += 1
    End Sub

    Sub step4()
        Dim p As Player = Game.player1
        If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") Or
            p.equippedWeapon.getName.Equals("Valkyrie_Sword") Then
            EquipmentDialogBackend.weaponChange(p, "Fists")
        End If

        p.changeForm("Slime")

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

        EquipmentDialogBackend.armorChange(p, "Naked")

        p.prt.skincolor = Color.FromArgb(200, p.prt.skincolor.R, p.prt.skincolor.G, p.prt.skincolor.B)

        'Author Credit: Marionette
        Dim out = ""
        out += "The impact of the goo was much more forceful than you expected, and your foot is tripped up on a loose stone as you stumble and sprawl onto the floor.  "

        If p.breastSize >= 4 Then
            out += "Luckily, most of the fall is absorbed by your bountiful breasts; the stone floor cold against your tits." & DDUtils.RNRN
        Else
            out += "Luckily, you are able to catch yourself before smacking your head; the stone floor cold against the palms of your hands." & DDUtils.RNRN
        End If

        out += "You roll over to look back at the Slime, finding the creature to have quickly closed the gap as it begins flowing over your feet.  Kicking it only ends up sinking your legs in further, and soon enough the slime has made it past your crotch." & DDUtils.RNRN

        If p.prt.sexBool Then
            out += "A spike of pleasure hits you as you start to feel the Slime brush against your clit, and your eyes widen as your legs are spread by the mass of goo.  Unable to resist the gelatinous mass, you watch as your feminine slit is slowly parted; a soft moan escaping your lips as you feel the cool goo pushing its way inside." & DDUtils.RNRN &
                   "At the same time, you feel the Slime pushing into your anus as well which only adds to the pleasure.  The Slime reaches past your chest and under your chin, propping it up, as you stop struggling and give in to its advances.  The goo inside your cunt reaches your cervix and with fluid ease pushes past it into your womb, as the sudden flow of swelling fluid now causes you to let out another loud moan.  The Slime seizes the opportunity to push up and into your mouth, forcing it open as you swallow mouthful after mouthful of goo." & DDUtils.RNRN &
                   "Your eyes roll back as the sensations start to overwhelm you, hips rocking back and forth as you feel yourself begin to climax.  The lusty arousal keeps rising as your stomach swells with goo, your back arching as you reach the epitome of pleasure.  It's like your body is being filled with liquid bliss, your vision now obscured as your head is fully engulfed in goo.  Your orgasm starts to taper off after a little while, only for the Slime to start back up.  This happens again and again; each time you feel as if you are practically melting into gooey paradise..."
        Else
            out += "As the Slime writhes and pushes around your crotch, you can’t help but to be aroused at the strange sensation; your penis beginning to harden against your will." & DDUtils.RNRN &
                   "Suddenly you feel a surge of goo spread your anus wide, a meek moan slips from your lips as you feel the cool fluid starting to push into your depths.  The Slime reaches past your chest and under your chin, propping it up, as you stop struggling and give in to its advances.  Deeper and deeper, the Slime pushes into you; an electric jolt of pleasure shoots through your body as the goo hits your prostate in just the right way.  Your cock pulses as you cum a little on the spot, the white fluid sputtering into the goo as you let out another loud moan.  The Slime seizes the opportunity to push up and into your mouth, forcing it open as you swallow mouthful after mouthful of goo." & DDUtils.RNRN &
                   "Your eyes roll back as the sensations start to overwhelm you, your now-over-sensitive cock dribbling a constant stream of precum into the goo as your hips start rocking back and forth reflexively.  The lusty arousal keeps rising as your stomach swells with goo, your back arching as you reach the epitome of pleasure.  It's like your body is being filled with liquid bliss, your vision now obscured as your head is fully engulfed in goo.  You can hold back no longer, and your back arches as you begin to cum heavily into the Slime.  You can feel the warmth of your cum flowing from your cock up along your front and towards your head, whether on purpose or just caught in the flow it seems the Slime is forcing you to drink your own cum as you taste your salty sweetness passing across your tongue.  Just as your first climax is dying down, you feel the Slime building another one up; uncaring as it works your oversensitized cock."
        End If

        TextEvent.push(out, AddressOf part4p2)
        p.drawPort()

        If Game.player1.perks(perk.slimetf) > -1 Then Game.player1.perks(perk.slimetf) = -1
    End Sub

    Private Sub part4p2()
        'Author Credit: Marionette
        TextEvent.push("A few hours later..." & DDUtils.RNRN &
                       "The afterglow of your last orgasm fades away as you lay on the stone floor.  You try to pick yourself up only to flop wetly back down." & DDUtils.RNRN &
                       "Confused, you look down at your body only to realize that it seems to actually be the puddle of slime you had thought you were lying in.  The Slime must have filled and coated you with enough of the magic gel to turn you into one yourself!" & DDUtils.RNRN &
                       "You focus on your old form, and slowly sculpt yourself into a rough approximation of it.  Now back in a much more familiar (albeit gooey) shape, you gather your gear and prepare to face the dungeon once again." & DDUtils.RNRN &
                       "Your base form is now that of a Slime!  Should you revert to your start state, this is what you will become.")

        Game.player1.setStartStates()
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub
    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1

        Select Case curr_step
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
        stopTF()
    End Sub
End Class
