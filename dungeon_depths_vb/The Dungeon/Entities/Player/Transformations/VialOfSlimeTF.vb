Public NotInheritable Class VialOfSlimeTF
    Inherits Transformation

    Private Const TF_IND As tfind = tfind.vialofslime

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
        TextEvent.push("As you open the vial, the contained goo slowly works its way out and onto your arm.  The soft, cool feeling of the Slime creeping along is surprisingly refreshing." & DDUtils.RNRN &
                       "It reaches your shoulder and then pushes itself up into your hair, settling in as you reach your hand up to poke at it.  The Slime almost seems to nuzzle your finger as it slowly seeps throughout your hair, changing the color and consistency of it to that of goo!")

        If Game.player1.perks(perk.slimetf) > -1 Then Game.player1.perks(perk.slimetf) += 1
    End Sub

    Sub step3()
        Dim p As Player = Game.player1
        p.prt.skincolor = Color.FromArgb(230, 0, 255, 255)
        p.changeForm("Half-Slime")

        'Author Credit: Marionette
        Dim out = "As soon as the lid of the vial comes off, the contained goo jumps out.  It "

        If p.breastSize < 1 Then
            out += "lands on your flat chest, splattering around as it grasps for something to hang onto." & DDUtils.RNRN
        ElseIf p.breastSize > 0 And p.breastSize < 4 Then
            out += "lands on your breasts, wiggling around as it seeps between your mammaries." & DDUtils.RNRN
        Else
            out += "lands on you breasts, your massive mammaries jiggling a little with the impact as a bit of the goo seeps into your cleavage." & DDUtils.RNRN
        End If

        out += "Your skin tingles where the slime touches it and you can’t help but smile as the blob of goo nuzzles your chest.  Slowly, you watch as the goo starts to squirm and creep along your skin; the tingling sensation growing stronger as your body starts to change to the same color and consistency of the Slime." & DDUtils.RNRN &
               "You are now a half-slime!"
        TextEvent.push(out)

        If Game.player1.perks(perk.slimetf) > -1 Then Game.player1.perks(perk.slimetf) += 1
    End Sub

    Sub step4()
        Dim p As Player = Game.player1
        If p.equippedWeapon.getName.Equals("Magical_Girl_Wand") Or
            p.equippedWeapon.getName.Equals("Valkyrie_Sword") Then
            EquipmentDialogBackend.weaponChange(p, "Fists")
        End If

        p.health = 1

        p.changeForm("Slime")

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

        TextEvent.push("Teal slime coats your entire body." & DDUtils.RNRN &
                       "Nearly as soon as you make contact, a reaction begins and you start to melt.  Suprisingly, this doesn't really hurt so much as it just feels weird, and you figure that with how much of your body was gelatinous this must have been just enough to finish you off." & DDUtils.RNRN &
                       "Now a puddle, you further reflect that regardless of how you started out, you seem to have been completely turned into a slime.  Hmm, but being a sentient ball of goo means you can easily reshape your body, right?" & DDUtils.RNRN &
                       "Focusing all your willpower, you sculpt yourself into a rough aproximation of your former body." & DDUtils.RNRN &
                       "Your base form is now that of a Slime!  Should you revert to your start state, this is what you will become.")
        p.drawPort()

        If Game.player1.perks(perk.slimetf) > -1 Then Game.player1.perks(perk.slimetf) = -1

        p.setStartStates()
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
