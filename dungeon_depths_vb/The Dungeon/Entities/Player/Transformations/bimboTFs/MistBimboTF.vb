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

    'Hair color shifting
    Overridable Sub hairColorShift()
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, bimbopink1, 10)
        If Not Game.player1.getHairColor.Equals(bimbopink1) Then curr_step -= 1
        TextEvent.fpush("Your hair color becomes slightly lighter, brightening to a rosy pink.")
    End Sub

    'Step 1:  Sneeze and Minor Headache
    Protected Sub step1()

    End Sub
    'Step 2:  Eye color shift, stat reduction
    Protected Sub step2()

    End Sub
    'Step 3:  Hair shift (messy), slut curse on equipped gear
    Protected Sub step3()

    End Sub
    'Step 4:  Potion transformation, major headache
    Protected Sub step4()

    End Sub
    'Step 5:  Forget any restore spells, transfiguration of any restore items
    Protected Sub step5()

    End Sub
    'Step 6:  Trancelike daze, slut curse on all gear
    Protected Sub step6()

    End Sub
    'Step 7:  Face change to bimbo, class change to bimbo
    Protected Sub step7()

    End Sub
    'Step 8:  Hair shift (styled), armor changes to bimbo clothes or bimbo armor
    Protected Sub step8()

    End Sub
    Protected Function clothesChangeS8(ByRef p As Player) As String
        If p.equippedArmor.getSlutVarInd() > -1 Then
            Return ""
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
    'Step 9:  clothes change to misttorn bimbo clothes, level drops to 1
    Protected Sub step9()

    End Sub
    'Step 10: Changes class to 'Mindless Bimbo'
    Protected Sub step10()

    End Sub
    'Step 11: inv vanishes, drops the player to floor 1
    Protected Sub step11()

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
            Case 10
                Return AddressOf step11
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
                turns_until_next_step = 77 + (Int(Rnd() * 5) + 1)
            Case 11
                turns_until_next_step = 66 + (Int(Rnd() * 5) + 1)
            Case Else
                turns_until_next_step = 5 + (Int(Rnd() * 5) + 1)
        End Select

        turns_until_next_step += generatWILResistance()
    End Sub
End Class
