Public NotInheritable Class FClericTF
    Inherits BimboTF

    Public Shared clericbrown As Color = Color.FromArgb(255, 139, 89, 54)

    Private Const TF_IND As tfind = tfind.faecleric

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

    'Hair Color Shift
    Overrides Sub hairColorShift()
        Game.player1.prt.haircolor = DDUtils.cShift(Game.player1.prt.haircolor, clericbrown, 50)
        If Not Game.player1.getHairColor.Equals(clericbrown) Then curr_step -= 1
        TextEvent.push("Your hair becomes slightly darker, shifting to a chestnut brown." & DDUtils.RNRN & "-6 LUST")

        Game.player1.addLust(-6)
    End Sub

    'Step 1
    Overrides Sub s1BodyChange(ByRef p As Player)
        If p.breastSize > 4 Then
            p.breastSize -= 1
        End If
        If p.className.Equals("Magical Girl") Then
            p.perks(perk.bimbotf) = 24
        End If
    End Sub
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = clericbrown
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub
    Public Overrides Sub s1TFText(ByRef p As Player)
        TextEvent.push("You pause to rub your temples, a massive headache comming down on you like a ton of bricks.  As you take a few minutes to recover, you notice that your center of balance is off.  You hypothisize that maybe that fae you ran into might be causing these effects." & DDUtils.RNRN & "Maybe you can just walk this off...")
    End Sub
    Overrides Sub step1()
        Dim p As Player = Game.player1

        s1HairChange(p)
        s1FaceChange(p)
        s1BodyChange(p)

        p.addLust(-10)

        s1TFText(p)
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        haircolor = "chestnut brown"
        If Not p.prt.sexBool And p.breastSize > 0 Then
            out += "Your clothing ripples, before shifting to an entirely different outfit altogether.  As you inspect the fabric, it slips under your radar that you no longer have breasts..."
        ElseIf p.prt.sexBool And p.breastSize > 1 Then
            out += "Your clothing ripples, before shifting to an entirely different outfit altogether.  As you inspect the fabric, it slips under your radar that your breasts have shrunken a bit..."
        Else
            out += "Your clothing ripples, before shifting to an entirely different outfit altogether..."
        End If
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = clericbrown
        p.prt.setIAInd(pInd.rearhair, 40, True, True)  'rearhair1
        p.prt.setIAInd(pInd.midhair, 46, True, True)  'rearhair2
        p.prt.setIAInd(pInd.fronthair, 44, True, True)  'front hair
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        p.prt.haircolor = clericbrown

        p.prt.setIAInd(pInd.eyebrows, 10, True, False) 'eyebrows
        If p.prt.sexBool Then
            p.prt.setIAInd(pInd.eyes, 61, True, True)  'eyes
        Else
            p.prt.setIAInd(pInd.eyes, 17, False, True)  'eyes
        End If
        p.prt.setIAInd(pInd.mouth, 0, True, False)  'mouth

        If p.inv.getCountAt("Circular_Glasses") < 1 Then p.inv.add("Circular_Glasses", 1)
        EquipmentDialogBackend.glassesChange(p, "Circular_Glasses")
    End Sub
    Overrides Sub s2ClothesChange(ByRef p As Player)
        If Not p.equippedArmor.getName.Equals("Naked") And Not p.className.Equals("Magical Girl") Then
            If p.inv.item(CommonClothesF.ITEM_NAME).count < 1 Then p.inv.add(CommonClothesF.ITEM_NAME, 1)
            EquipmentDialogBackend.armorChange(p, CommonClothesF.ITEM_NAME)
        End If
    End Sub
    Overrides Sub s2BodyChange(ByRef p As Player)
        If Not p.prt.sexBool And p.breastSize > 0 Then
            p.breastSize = Math.Max(p.breastSize - 3, 0)
        ElseIf p.prt.sexBool And p.breastSize > 1 Then
            p.breastSize = Math.Max(p.breastSize - 3, 1)
        End If

        s2ClothesChange(p)
    End Sub
    Overrides Sub s2WrapUp(ByRef p As Player, ByRef out As String)
        p.changeClass("Cleric")
        p.perks(perk.bimbotf) = -1

        TextEvent.push(out)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 10 + (Int(Rnd() * 5) + 1)
        turns_until_next_step += generatWILResistance()
    End Sub

    Public Overrides Function hasBimboHair(p As Player) As Boolean
        Return p.prt.haircolor.Equals(clericbrown)
    End Function
End Class
