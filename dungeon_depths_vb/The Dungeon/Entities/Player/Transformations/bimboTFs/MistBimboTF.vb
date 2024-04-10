Public Class MistBimboTF
    Inherits Transformation

    Public Shared bimbopink1 As Color = Color.FromArgb(255, 255, 119, 203)
    Public Shared bimbopink2 As Color = Color.FromArgb(255, 255, 210, 255)

    Private Const TF_IND As tfind = tfind.mistbimbo

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

    Overridable Sub hairColorShift()
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, bimbopink1, 10)
        If Not Game.player1.getHairColor.Equals(bimbopink1) Then curr_step -= 1
        TextEvent.fpush("Your hair color becomes slightly lighter, brightening to a rosy pink.")
    End Sub

    Protected Sub step1()
        TextEvent.push("Something feels... weird..." & DDUtils.RNRN &
                       "As pink sparkles drift though the air around you, your head begins to ache...")
        TextEvent.pushLog("The pink mist swirls around you...")
    End Sub

    'Step 2:  Eye color shift, stat reduction
    Protected Sub step2()

        TextEvent.pushLog("The pink mist swirls around you...")
    End Sub

    Protected Sub step3()
        Dim p = Game.player1
        Dim out = "You sneeze, as the pink mist seems to coalesce around the contours of your body.  It's easy enough to clear the air with a wave of your hand, but... hmm..." & DDUtils.RNRN

        If EquipmentDialogBackend.clothingCurse(p, False) Then
            out += "Wait- has your outfit always been, like... this?  And " & hairChangeS3(p) & DDUtils.RNRN
        Else
            out += "Wait- " & hairChangeS3(p) & DDUtils.RNRN
        End If

        TextEvent.fpush(out & "No... probably just best to keep moving...")
        TextEvent.pushLog("The pink mist swirls around you...")
    End Sub
    Protected Function hairChangeS3(ByRef p As Player) As String
        p.prt.setIAInd(pInd.rearhair, 1, True, False)
        p.prt.setIAInd(pInd.midhair, 32, True, True)
        p.prt.setIAInd(pInd.fronthair, 9, True, True)
        Return "why do strands of your hair keep falling over your face?"
    End Function

    'Step 4:  Potion transformation, major headache
    Protected Sub step4()
        Dim p = Game.player1

        For Each itm In p.inv.getPotions
            If Not itm.getAName.Equals(DitzyPotion.ITEM_NAME) Then
                p.inv.item(DitzyPotion.ITEM_NAME).add(itm.getCount())
                itm.add(-itm.getCount())
            End If
        Next

        TextEvent.pushLog("The pink mist swirls around you...")
    End Sub
    'Step 5:  Forget any restore spells, transfiguration of any restore items
    Protected Sub step5()
        TextEvent.pushLog("The pink mist swirls around you...")
    End Sub
    'Step 6:  Trancelike daze, slut curse on all gear
    Protected Sub step6()
        Dim p = Game.player1

        Dim out = "As the mists swirl around you once more, you find that you aren't feeling much different.  Your body and mind seem to have been unaffected this time around..." & DDUtils.RNRN

        Dim ctTFdArmors = transfigureClothes(p)
        Dim ctTFdWeapons = transfigureWeapons(p)

        If ctTFdArmors > 0 Then
            out += "Within your bag, " & ctTFdArmors & " sets of clothing and armor seem to have been touched by the mists..." & DDUtils.RNRN
        End If

        If ctTFdWeapons > 0 Then
            out += "Within your bag, " & ctTFdArmors & " weapons seem to have been touched by the mists..." & DDUtils.RNRN
        End If

        If EquipmentDialogBackend.clothingCurse(p, False) Then
            out += "Your " & DDUtils.amrOrClth(p) & " twists in the mist's magic, not that you notice the change..." & DDUtils.RNRN
        End If

        TextEvent.pushLog("The pink mist swirls around you...")
    End Sub
    Protected Function transfigureClothes(ByRef p As Player) As Integer
        Dim ctTFClothes As Integer = 0
        Dim idsToTF As List(Of Integer) = New List(Of Integer)()

        For Each itm In p.inv.getArmors.Item2
            If (itm.getCount > 0 AndAlso itm.getSlutVarInd() > 0 AndAlso p.equippedArmor.getId <> itm.getId) OrElse (itm.getCount > 1 AndAlso itm.getSlutVarInd() > 0 AndAlso p.equippedArmor.getId = itm.getId) Then
                idsToTF.Add(itm.getId())
                ctTFClothes += 1
            End If
        Next

        For Each id In idsToTF
            If Not id = p.equippedArmor.getId Then
                p.inv.add(CType(p.inv.item(id), Armor).getSlutVarInd, (p.inv.item(id).getCount - 1))
                p.inv.add(id, -(p.inv.item(id).getCount - 1))
            Else
                p.inv.add(CType(p.inv.item(id), Armor).getSlutVarInd, p.inv.item(id).getCount)
                p.inv.add(id, -p.inv.item(id).getCount)
            End If
        Next

        Return ctTFClothes
    End Function
    Protected Function transfigureWeapons(ByRef p As Player) As Integer
        Dim ctTFWeapons As Integer = 0

        Return ctTFWeapons
    End Function

    Protected Sub step7()
        Dim p = Game.player1

        p.prt.setIAInd(pInd.eyebrows, 9, True, False)
        p.prt.setIAInd(pInd.mouth, 36, True, True)
        p.prt.setIAInd(pInd.eyes, 68, True, True)

        p.changeClass("Bimbo")

        TextEvent.fpush("Your face feels... kinda tingly...")
        TextEvent.pushLog("The pink mist swirls around you...")
    End Sub

    Protected Sub step8()
        Dim p As Player = Game.player1

        TextEvent.fpush("The air around you almost seems to glow; pulsing with the ebb and flow of the swirling mists." & DDUtils.RNRN &
                        hairChangeS8(p) & DDUtils.RNRN &
                        clothesChangeS8(p) & DDUtils.RNRN &
                        weaponChangeS8(p))
        TextEvent.pushLog("The pink mist swirls around you...")
    End Sub
    Protected Function clothesChangeS8(ByRef p As Player) As String
        If p.equippedArmor.getSlutVarInd() > -1 Then
            EquipmentDialogBackend.clothingCurse(p, False)

            Return "A glittery shimmer washes over your gear, and your outfit becomes far more revealing."
        ElseIf p.equippedArmor.is_sexy Then
            Return "A glittery shimmer washes over your gear, but it doesn't seem to do anything..."
        ElseIf p.equippedArmor.d_boost > 20 Then
            p.inv.add(BimboArmor.ITEM_NAME, -1)
            p.inv.add(p.equippedArmor.getAName(), -1)

            If Not p.inv.item(BimboArmor.ITEM_NAME) Is Nothing AndAlso CType(p.inv.item(BimboArmor.ITEM_NAME), Armor).fits(p) Then
                EquipmentDialogBackend.equipArmor(p, BimboArmor.ITEM_NAME, False)
                Return "Your equipment twists into a revealing set of pink armor.  Jet black stockings slink up to your thighs, and a pair garters fall down from around your waist before pulling taut.  Your top warps into a sheer breastplate; held in place only by the contours of your chest.  Finally, a short pink skirt spins into being around your hips."
            ElseIf Not p.equippedArmor.getAName.Equals("Naked") Then
                EquipmentDialogBackend.equipArmor(p, "Naked", False)
                Return "Your equipment twists into a revealing set of pink armor, so tight that it can barely contain your body.  With even the slightest movement it stretches and strains, until eventually you hear a tear and it falls to the ground in tatters."
            End If

            Return "A revealing set of pink armor twists into being around you, but it doesn't seem to fit."
        Else
            p.inv.add(MistwarpedClothes.ITEM_NAME, -1)
            p.inv.add(p.equippedArmor.getAName(), -1)

            If Not p.inv.item(MistwarpedClothes.ITEM_NAME) Is Nothing AndAlso CType(p.inv.item(MistwarpedClothes.ITEM_NAME), Armor).fits(p) Then
                EquipmentDialogBackend.equipArmor(p, MistwarpedClothes.ITEM_NAME, False)
                Return "Your equipment twists into a skanty pink outfit.  Pale rose stockings slink up to your thighs, and a pair of small ribbons twirl around their cuff.  Your top melts into sheer fabric; held in place only by the contours of your chest.  Finally, a short pink skirt spins into being around your hips."
            ElseIf Not p.equippedArmor.getAName.Equals("Naked") Then
                EquipmentDialogBackend.equipArmor(p, "Naked", False)
                Return "Your equipment twists into a skanty pink outfit, so tight that it can barely contain your body.  With even the slightest movement it stretches and strains, until eventually you hear a tear and it falls to the ground in tatters."
            End If

            Return "A skimpy pink outfit twists into being around you, but it doesn't seem to fit."
        End If
    End Function
    Protected Function weaponChangeS8(ByRef p As Player) As String

        If p.equippedWeapon.GetType.IsSubclassOf(GetType(Sword)) Then
            p.inv.item(p.equippedWeapon.getAName).add(-1)
            p.inv.item(MistwarpedSword.ITEM_NAME).add(1)
            EquipmentDialogBackend.equipWeapon(p, MistwarpedSword.ITEM_NAME, False)
            Return "Your weapon shimmers, as it morphs into a less effective version of itself."
        ElseIf p.equippedWeapon.GetType.IsSubclassOf(GetType(Spear)) And p.equippedWeapon.GetType.IsSubclassOf(GetType(Staff)) Then
            p.inv.item(p.equippedWeapon.getAName).add(-1)
            p.inv.item(MistwarpedPolearm.ITEM_NAME).add(1)
            EquipmentDialogBackend.equipWeapon(p, MistwarpedPolearm.ITEM_NAME, False)
            Return "Your weapon shimmers, as it morphs into a less effective version of itself."
        ElseIf p.equippedWeapon.GetType.IsSubclassOf(GetType(Dagger)) And p.equippedWeapon.GetType.IsSubclassOf(GetType(Wand)) Then
            p.inv.item(p.equippedWeapon.getAName).add(-1)
            p.inv.item(MistwarpedRod.ITEM_NAME).add(1)
            EquipmentDialogBackend.equipWeapon(p, MistwarpedRod.ITEM_NAME, False)
            Return "Your weapon shimmers, as it morphs into a less effective version of itself."
        End If

        Return "Your weapon shimmers briefly, but nothing seems to happen to it."
    End Function
    Protected Function hairChangeS8(ByRef p As Player) As String
        p.prt.haircolor = bimbopink2
        p.prt.setIAInd(pInd.rearhair, 18, True, True)
        p.prt.setIAInd(pInd.midhair, 7, True, False)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
        Return ""
    End Function

    Protected Sub step9()
        Dim p = Game.player1

        If Not p.className.Equals("Mindless Bimbo") Then p.changeClass("Mindless Bimbo")

        If p.level > 20 Then
            p.deLevel(10)
        ElseIf p.level > 10 Then
            p.deLevel(5)
        ElseIf p.level > 5 Then
            p.deLevel(3)
        Else
            p.deLevel(p.level)
        End If

        TextEvent.push("You... uh..." & DDUtils.RNRN &
                       "Something kinda... feels- like- uh..." & DDUtils.RNRN &
                       "Everything's all... um- shimmery...")
        TextEvent.pushLog("The pink mist swirls around you...")
    End Sub

    Protected Sub step10()
        Dim p As Player = Game.player1

        For i = 0 To p.inv.upperBound
            If Not (i = p.equippedArmor.getId Or i = p.equippedWeapon.getId Or i = p.equippedAcce.getId Or i = p.equippedGlasses.getId) Then p.inv.setCount(i, 0)
        Next

        TextEvent.push("You absentmindedly swoon as the rose haze thickens to the point that you can't see anything else.  You can faintly recognize that you're tumbling, but- like... it doesn't really feel like you're hurt or anything..." & DDUtils.RNRN &
                       "You fade... in and out... in... and out... deeper... and woozier... and deeper... oh..." & DDUtils.PAKTC, AddressOf step10p2)
        TextEvent.pushLog("The pink mist swirls around you, one final time...")
    End Sub
    Protected Sub step10p2()
        Game.mDun.jumpTo(Game.currFloor.floorNumber - 1)
        Game.mDun.setFloor(Game.currFloor)

        Game.player1.health = 1.0

        Game.player1.inv.invNeedsUDate = True
        Game.player1.UIupdate()
        Game.player1.drawPort()

        TextEvent.push("You eventually come to, somewhere else." & DDUtils.RNRN &
                  "Hey... haven't you been here before?")
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player1.perks(perk.bimbotf) = -1
    End Sub

    Public Overridable Function hasBimboHair(ByVal p As Player) As Boolean
        Return p.prt.haircolor.Equals(bimbopink1) Or p.prt.haircolor.Equals(bimbopink2)
    End Function
    Public Overrides Function getNextStep(stage As Integer) As Action
        If Not hasBimboHair(Game.player1) Then
            Return AddressOf hairColorShift
        End If
        If Game.player1.perks(perk.bimbotf) = -1 Then
            Return AddressOf stopTF
        End If
        If stage < 8 And Game.player1.className.Contains("Bimbo") Then
            Return AddressOf stopTF
        End If

        Select Case stage
            Case 0
                Return AddressOf step1
            Case 1
                Return AddressOf step2
            Case 2
                Return AddressOf step3
            Case 3
                Return AddressOf step4
            Case 4
                Return AddressOf step5
            Case 5
                Return AddressOf step6
            Case 6
                Return AddressOf step7
            Case 7
                Return AddressOf step8
            Case 8
                Return AddressOf step9
            Case 9
                Return AddressOf step10
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        Select Case stage
            Case 3
                turns_until_next_step = 33 + (Int(Rnd() * 5) + 1)
            Case 6
                turns_until_next_step = 22 + (Int(Rnd() * 5) + 1)
            Case 7
                turns_until_next_step = 7 + (Int(Rnd() * 5) + 1)
            Case 8
                turns_until_next_step = 66 + (Int(Rnd() * 5) + 1)
            Case 9
                turns_until_next_step = 77 + (Int(Rnd() * 5) + 1)
            Case 10
                turns_until_next_step = 99 + (Int(Rnd() * 5) + 1)
            Case Else
                turns_until_next_step = 5 + (Int(Rnd() * 5) + 1)
        End Select

        turns_until_next_step += generatWILResistance()
    End Sub
End Class
