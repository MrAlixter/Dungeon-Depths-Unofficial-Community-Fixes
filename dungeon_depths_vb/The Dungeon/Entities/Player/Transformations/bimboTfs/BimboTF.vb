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
        TextEvent.push("Your hair becomes slightly lighter, brightening to a light blonde.")
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
        TextEvent.push("You pause to rub your temples, a massive headache comming down on you like a ton of bricks.  As you take a few minutes to recover, you notice that your center of balance is off and more disturbingly, that you can't seem to focus enough to figure out why." & DDUtils.RNRN & "Maybe you can just walk this off...")
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
            out += "In your haze, you look down to see breasts blossoming from your chest. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. As your dainty hands move down your body, you discover that you no longer have a cock and balls, and insted have a tight moist cunt.  Your hair lengthens, becoming a " & haircolor & ", and your clothes change to match your new figure."
            p.MtF()
        ElseIf p.prt.sexBool And p.breastSize < 3 Then
            out += "In your haze, you look down at your tits. You, like, never noticed how round and big they had got. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a " & haircolor & ", and your clothes change to match your new figure."
        ElseIf p.prt.sexBool And p.breastSize >= 3 Then
            out += "In your haze, you look down to see your clothes have become tight and revealing. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a " & haircolor & ", and your clothes finish changing to match your new figure."
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
            Else
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
        p.setplayer_image()
        p.TextColor = Color.FromArgb(255, 255, 235, 240)
        p.perks(perk.bimbotf) = -1
        'p.drawPort()
        TextEvent.push(out)
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
            If p.equippedArmor.getSlutVarInd = -1 Then
                p.inv.add("Very_Skimpy_Clothes", 1)
                EquipmentDialogBackend.armorChange(p, "Very_Skimpy_Clothes")
            Else
                Equipment.clothingCurse1(p)
            End If
        End If
        'Hair Change
        p.prt.haircolor = Color.FromArgb(255, 250, 250, 205)
        p.prt.setIAInd(pInd.rearhair, 23, True, True)
        p.prt.setIAInd(pInd.midhair, 26, True, True)
        p.prt.setIAInd(pInd.fronthair, 24, True, True)



        p.lust += 50

        stopTF()
        s2WrapUp(p, out)
    End Sub
    Sub chickenTf()
        Dim p As Player = Game.player1
        Dim cRed = Color.FromArgb(255, 215, 0, 4)
        Dim out As String = "As you don the chicken suit you found, part of you half expects to turn into some sort of bird.  You chuckle to yourself at the idea, and this quickly devolves into a giggling fit.  Parting your short red bangs off to one side, you adjust your large breasts in the suit.  You note that despite covering most of your body, it doesn't even begin to provide enough support.  You strip some parts of the outfit away, shift other parts around, and soon you are left with a pair of wings and a set of straps that provide just about all the support you think you're going to get out of it.  Proud of your handiwork, you strut back out into the dungeon still giggling at the noshun...notshi...""idea"" that some silly chicken costume could change you in any way."

        p.setName(Polymorph.bimboizeName(p.getName))

        s2M2F(p, out, "bright red")
        s2BodyChange(p)

        'Face Change
        If p.prt.checkNDefFemInd(pInd.ears, 6) Then p.prt.setIAInd(pInd.ears, 0, True, True)
        p.prt.setIAInd(pInd.cloak, 0, True, False) 'glasses
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
        TextEvent.push("You immediatly feel funny, the increased magic in your system reacting swiftly with the gum.  In your haze, you look down to see your clothes have become tight and pink. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes finish changing to match your new figure.")
        p.lust += 10

        p.TextColor = Color.FromArgb(255, 255, 235, 240)

        stopTF()
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
