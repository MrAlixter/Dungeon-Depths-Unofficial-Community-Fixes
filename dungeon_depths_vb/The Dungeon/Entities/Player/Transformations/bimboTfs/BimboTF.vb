Public Class BimboTF
    Inherits Transformation

    Public Shared bimboyellow1 As Color = Color.FromArgb(255, 255, 230, 160)
    Public Shared bimboyellow2 As Color = Color.FromArgb(255, 250, 250, 205)

    Private Const TF_IND As tfind = tfind.bimbo

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    'Hair color shifting
    Overridable Sub hairColorShift()
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, bimboYellow1, 25)
        If Not Game.player1.getHairColor.Equals(bimboYellow1) Then curr_step -= 1
        TextEvent.fpush("Your hair becomes slightly lighter, brightening to a light blonde.")
    End Sub

    'Step 1
    Overridable Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimboYellow1
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub
    Sub s1HairChange(ByRef p As Player)
        If p.name = "Targax" Then
            p.prt.haircolor = Color.FromArgb(255, 255, 0, 147)
            p.prt.setIAInd(pInd.rearhair, 9, True, True)
            p.prt.setIAInd(pInd.midhair, 9, True, True)
            p.prt.setIAInd(pInd.fronthair, 13, True, True)
        Else
            s1BimboHairChange(p)
        End If
    End Sub
    Overridable Sub s1FaceChange(ByRef p As Player)
        If p.prt.checkNDefFemInd(pInd.ears, 6) Then p.prt.setIAInd(pInd.ears, 0, True, True)
        p.prt.setIAInd(pInd.mouth, 5, True, True)
        p.prt.setIAInd(pInd.eyes, 7, True, True)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        If Not p.className.Equals("Magical Girl") Then p.prt.setIAInd(pInd.hat, 0, True, False)
    End Sub
    Overridable Sub s1BodyChange(ByRef p As Player)
        If p.breastSize = 1 Then
            p.breastSize = 2
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
        End If
        If p.className.Equals("Magical Girl") Then
            p.perks(perk.bimbotf) = 24
        End If
    End Sub
    Overridable Sub s1TFText(ByRef p As Player)
        TextEvent.fpush("You pause to rub your temples, as you begin to develop a massive headache." & DDUtils.RNRN &
                        "While taking a few minutes to recover, you notice that your center of balance is... off.  More disturbingly, you can't seem to focus enough to figure out why that would be." & DDUtils.RNRN &
                        "Maybe you can just walk this off...")
    End Sub
    Overridable Sub step1()
        Dim p As Player = Game.player1

        s1HairChange(p)
        s1FaceChange(p)
        s1BodyChange(p)

        p.setName(Polymorph.bimboizeName(p.getName))

        p.lust += 10
        'p.drawPort()
        s1TFText(p)
    End Sub

    'Step 2
    Overridable Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        If Not p.prt.sexBool Then
            out += "Lost in a swirling trance, your gaze drifts down to your blossoming pair of breasts... had they always been there?" & DDUtils.RNRN &
                   "You giggle, as all traces of intellect vanish from your mind while your body becomes more curvy and feminine.  Feeling yorself up with your dainty hands, you discover that you no longer have a cock and balls; finding instead a tight, moist pussy." & DDUtils.RNRN &
                   "Your hair lengthens, shifting in color to a " & haircolor & ", and your " & DDUtils.amrOrClth(p) & " warps and reweaves itself to match your new figure."
            p.MtF()
        ElseIf p.prt.sexBool And p.breastSize < 3 Then
            out += "Lost in a swirling trance, your gaze drifts down to your tits.  You, like, never noticed how big and round they'd been getting..." & DDUtils.RNRN &
                   "You giggle as all traces of intellect vanish from your mind, while your body becomes more curvy and feminine." & DDUtils.RNRN &
                   "Your hair lengthens, shifting in color to a " & haircolor & ", and your " & DDUtils.amrOrClth(p) & " warps and reweaves itself to match your new figure."
        ElseIf p.prt.sexBool And p.breastSize >= 3 Then
            out += "Lost in a swirling trance, your gaze drifts down to your huge tits." & DDUtils.RNRN &
                   "You giggle, as all traces of intellect vanish from your mind and your body becomes more curvy and feminine.  Giving your chest some exp... um... test bounces, you find yourself lost in their jiggly movement." & DDUtils.RNRN &
                   "Your hair lengthens, shifting in color to a " & haircolor & ", and your " & DDUtils.amrOrClth(p) & " warps and reweaves itself to match your new figure."
        End If
    End Sub
    Overridable Sub s2FaceChange(ByRef p As Player)
        If p.name <> "Targax" Then
            p.prt.setIAInd(pInd.eyes, 8, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 16, True, True)
        End If
        p.prt.setIAInd(pInd.mouth, 6, True, True)
    End Sub
    Overridable Sub s2BodyChange(ByRef p As Player)
        If p.breastSize < 3 Then
            p.breastSize = 3
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
        End If
        s2ClothesChange(p)
    End Sub
    Overridable Sub s2ClothesChange(ByRef p As Player)
        If Not p.equippedArmor.getName.Equals("Naked") And Not p.className.Equals("Magical Girl") Then
            If p.equippedArmor.getSlutVarInd = -1 Then
                If p.inv.item("Skimpy_Clothes").count < 1 Then p.inv.add("Skimpy_Clothes", 1)
                EquipmentDialogBackend.armorChange(p, "Skimpy_Clothes")
            ElseIf p.equippedArmor.getAntiSlutInd = -1 Then
                Equipment.clothingCurse1(p)
            End If
        End If
    End Sub
    Overridable Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = Color.FromArgb(255, 245, 231, 184)

        If p.name <> "Targax" Then
            p.prt.haircolor = bimboyellow2
            p.prt.setIAInd(pInd.rearhair, 6, True, True)
            p.prt.setIAInd(pInd.midhair, 6, True, True)
            p.prt.setIAInd(pInd.fronthair, 7, True, True)
        End If
    End Sub
    Overridable Sub s2WrapUp(ByRef p As Player, ByRef out As String)
        p.changeClass("Bimbo")
        p.TextColor = Color.FromArgb(255, 255, 235, 240)
        p.perks(perk.bimbotf) = -1
        'p.drawPort()
        TextEvent.fpush(out)
    End Sub
    Sub step2()
        Dim p As Player = Game.player1
        Dim out As String = ""

        s2M2F(p, out, "platinum blonde")
        s2HairChange(p)
        s2FaceChange(p)
        s2BodyChange(p)

        p.lust += 10

        stopTF()
        s2WrapUp(p, out)
    End Sub

    'Alternate Step 2
    Sub doubleTf()
        Dim p = Game.player1
        Dim out As String = ""

        p.setName(Polymorph.bimboizeName(p.getName))

        s2M2F(p, out, "platinum blonde")
        s2BodyChange(p)
        'Face Change
        If p.prt.checkNDefFemInd(pInd.ears, 6) Then p.prt.setIAInd(pInd.ears, 0, True, True)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 32, True, True)
        p.prt.setIAInd(pInd.mouth, 17, True, True)
        'Clothes Change
        If Not p.equippedArmor.getName.Equals("Naked") Then
            If Game.shop_npc_engaged And Game.active_shop_npc.npc_index = ShopNPCInd.hypnoteach And Game.hteach.form.Equals("Bimbo") Then
                Dim statname = p.getGreatestStatname
                Dim tf_outfit = VSkimpyClothes.ITEM_NAME
                If statname = DDConst.STATNAME_HP Then
                    tf_outfit = CowArmor.ITEM_NAME
                ElseIf statname = DDConst.STATNAME_MP Then
                    tf_outfit = WitchCosplay.ITEM_NAME
                ElseIf statname = DDConst.STATNAME_ATK Then
                    tf_outfit = BrawlerCosplay.ITEM_NAME
                ElseIf statname = DDConst.STATNAME_DEF Then
                    tf_outfit = PaladinBikini.ITEM_NAME
                ElseIf statname = DDConst.STATNAME_SPD Then
                    tf_outfit = AmaAttire.ITEM_NAME
                ElseIf statname = DDConst.STATNAME_WILL Then
                    tf_outfit = AcolyteCosplay.ITEM_NAME
                End If

                If p.inv.getCountAt(tf_outfit) < 1 Then p.inv.add(tf_outfit, 1)
                EquipmentDialogBackend.armorChange(p, tf_outfit)

                out = ""
            Else
                If p.equippedArmor.getSlutVarInd = -1 Then
                    If p.inv.getCountAt(VSkimpyClothes.ITEM_NAME) < 1 Then p.inv.add(VSkimpyClothes.ITEM_NAME, 1)
                    EquipmentDialogBackend.armorChange(p, VSkimpyClothes.ITEM_NAME)
                ElseIf p.equippedArmor.getAntiSlutInd = -1 Then
                    Equipment.clothingCurse1(p)
                End If
            End If
        End If
        'Hair Change
        p.prt.haircolor = Color.FromArgb(255, 250, 250, 205)
        p.prt.setIAInd(pInd.rearhair, 23, True, True)
        p.prt.setIAInd(pInd.midhair, 26, True, True)
        p.prt.setIAInd(pInd.fronthair, 24, True, True)

        p.lust += 50

        stopTF()

        p.changeClass("Bimbo")
        p.textColor = Color.FromArgb(255, 255, 235, 240)
        p.perks(perk.bimbotf) = -1
    End Sub
    Sub chickenTf(ByRef p As Player)
        Dim cRed = Color.FromArgb(255, 215, 0, 4)

        Dim out As String = "As you don the chicken suit you found, part of you half expects to turn into some sort of bird." & DDUtils.RNRN &
                            "Parting your short red bangs off to one side, you adjust the loose fit of the suit.  Nothing seems to be happening, and after a few boring seconds you guess that it's probably safe after all... if a little frumpy." & DDUtils.RNRN &
                            "Even though it, like, covers most of your body, it doesn't even begin to provide enough support for your tits.  You strip some parts of the outfit away, shift other parts around, and soon you are left with a pair of wings and a set of straps that provide just about all the support you think you're going to get out of it." & DDUtils.RNRN &
                            "Proud of your handiwork, you strut back out into the dungeon; still giggling at your ditzy self for being, like, scared of some silly chicken costume."

        p.setName(Polymorph.bimboizeName(p.getName))

        s2M2F(p, "", "bright red")

        If p.breastSize < 3 Then
            p.breastSize = 3
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
        End If

        'Face Change
        If p.prt.checkNDefFemInd(pInd.ears, 6) Then p.prt.setIAInd(pInd.ears, 0, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False) 'hat
        p.prt.setIAInd(pInd.eyes, 8, True, True) 'eyes
        p.prt.setIAInd(pInd.mouth, 6, True, True) 'mouth

        'Hair Change
        p.prt.haircolor = cRed
        p.prt.setIAInd(pInd.rearhair, 11, True, True) 'rhair 2
        p.prt.setIAInd(pInd.midhair, 11, True, True) 'rhair 1
        p.prt.setIAInd(pInd.fronthair, 17, True, True) 'fhair

        p.lust += 20

        s2WrapUp(p, out)
        stopTF()
    End Sub
    Overridable Sub step2alt()
        Dim p As Player = Game.player1

        Dim mstf = New MagSlutTF(1, 0, 0, False)
        mstf.fullTF(p)
        TextEvent.fpush("You immediately feel funny, as the increased concentration of magic in your system reacts swiftly with the gum." & DDUtils.RNRN &
                        "Lost in a swirling trance, you giggle as all traces of intellect vanish from your mind.  Your body becomes curvy and feminine, and your hair lengthens while shifting in color to a platinum blonde." & DDUtils.RNRN &
                        "Your " & DDUtils.amrOrClth(p) & " warps and reweaves itself to match your new figure.")
        p.lust += 10

        p.TextColor = Color.FromArgb(255, 255, 235, 240)

        stopTF()
    End Sub
    Shared Sub polymorphTf(ByRef p As Player, ByVal duration As Integer)
        p.savePState()

        p.setName(Polymorph.bimboizeName(p.getName))

        'Body Change
        If p.sex = "Male" Then p.MtF()
        If p.breastSize < 3 Then
            p.breastSize = 3
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
        End If

        'Face Change
        If p.prt.checkNDefFemInd(pInd.ears, 6) Then p.prt.setIAInd(pInd.ears, 0, True, True)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 8, True, True)
        p.prt.setIAInd(pInd.mouth, 27, True, True)

        'Clothes Change
        If Not p.equippedArmor.getName.Equals("Naked") Then
            If p.equippedArmor.getSlutVarInd = -1 Then
                If p.inv.getCountAt(SkimpyClothes.ITEM_NAME) < 1 Then p.inv.add(SkimpyClothes.ITEM_NAME, 1)
                EquipmentDialogBackend.armorChange(p, SkimpyClothes.ITEM_NAME)
            ElseIf p.equippedArmor.getAntiSlutInd = -1 Then
                Equipment.clothingCurse1(p)
            End If
        End If

        'Hair Change
        p.prt.haircolor = Color.FromArgb(255, 250, 250, 205)

        p.lust += 50

        p.changeClass("Bimbo")
        p.textColor = Color.FromArgb(255, 255, 235, 240)
        p.perks(perk.bimbotf) = -1
        p.perks(perk.polymorphed) = duration
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player1.perks(perk.bimbotf) = -1
    End Sub

    Public Overridable Function hasBimboHair(ByVal p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimboYellow1) Or p.prt.haircolor.Equals(bimboyellow2)
    End Function
    Public Overrides Function getNextStep(stage As Integer) As Action
        If Not hasBimboHair(Game.player1) Then
            Return AddressOf hairColorShift
        End If
        If Game.player1.className.Equals("Magical Girl") Then
            Return AddressOf step2alt
        End If
        If Game.player1.perks(perk.bimbotf) = -1 Then
            Return AddressOf stopTF
        End If

        Select Case stage
            Case 0
                Return AddressOf step1
            Case 1
                Return AddressOf step2
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 5 + (Int(Rnd() * 5) + 1)
        turns_until_next_step += generatWILResistance()
    End Sub
End Class
