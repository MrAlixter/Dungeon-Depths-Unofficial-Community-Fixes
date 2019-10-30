Public NotInheritable Class BimboTF
    Inherits Transformation
    Public Shared bimboyellow As Color = Color.FromArgb(255, 255, 230, 160)

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.updateDuringCombat = False
        tfName = "Bimbo"
        nextStep = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.updateDuringCombat = False
        tfName = "Bimbo"
        nextStep = getNextStep(cs)
    End Sub

    Sub hairColorShift()
        Game.player.prt.haircolor = Game.cShift(Game.player.prt.haircolor, bimboyellow, 25)
        If Not Game.player.getHairColor.Equals(bimboyellow) Then currStep -= 1
        Game.pushLblEvent("Your hair becomes slightly lighter, brightening to a light blonde.")
    End Sub
    Sub step1()
        Dim p As player = game.player
        If p.name = "Targax" Then
            p.prt.haircolor = Color.FromArgb(255, 255, 0, 147)
            p.prt.setIAInd(pInd.rearhair, 9, True, True)
            p.prt.setIAInd(pInd.midhair, 9, True, True)
            p.prt.setIAInd(pInd.fronthair, 13, True, True)
        Else
            p.prt.haircolor = bimboyellow
            p.prt.setIAInd(pInd.rearhair, 1, True, True)
            p.prt.setIAInd(pInd.midhair, 5, True, True)
            p.prt.setIAInd(pInd.fronthair, 6, True, True)
        End If

        If p.prt.checkNDefFemInd(6, 6) Then p.prt.setIAInd(pInd.ears, 0, True, True)
        Polymorph.giveRNDBimName(p)
        p.prt.setIAInd(pInd.mouth, 5, True, True)
        p.prt.setIAInd(pInd.eyes, 7, True, True)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        If Not p.pClass.name.Equals("Magical Girl") Then p.prt.setIAInd(pInd.hat, 0, True, False)

        If p.breastSize = 1 Then
            p.prt.setIAInd(pInd.body, 6, True, True)
            p.breastSize = 2
            If p.equippedArmor.getName.ToString() = "Common_Clothes" Then
                p.prt.setIAInd(pInd.clothes, 5, True, True)
            End If
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
            p.reverseBSRoute()
        End If
        If p.pClass.name.Equals("Magical Girl") Then
            p.prt.setIAInd(pInd.hat, Portrait.imgLib.atrs("Hat").getF.Count - 3, True, True)
            p.perks("bimbotf") = 24
        End If
        p.lust += 10
        p.drawPort()
        Game.pushLblEvent("You pause to rub your temples, a massive headache comming down on you like a ton of bricks.  As you take a few minutes to recover, you notice that your center of balance is off and more disturbingly, that you can't seem to focus enough to figure out why." & vbCrLf & vbCrLf & "Maybe you can just walk this off...")
    End Sub
    Sub step2()
        Dim p As player = game.player
        Dim out As String = ""
        If Not p.prt.sexBool Then
            out += "In your haze, you look down to see breasts blossoming from your chest. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. As your dainty hands move down your body, you discover that you no longer have a cock and balls, and insted have a tight moist cunt.  Your hair lengthens, becoming a platinum blonde, and your clothes change to match your new figure."
            p.sex = "Female"
        ElseIf p.prt.sexBool And p.breastSize < 3 Then
            out += "In your haze, you look down at your tits. You, like, never noticed how round and big they had got. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes change to match your new figure."
        ElseIf p.prt.sexBool And p.breastSize >= 3 Then
            out += "In your haze, you look down to see your clothes have become tight and revealing. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes finish changing to match your new figure."
        End If
        p.pClass = p.classes("Bimbo")
        p.lust += 10
        'final tf Stage
        If p.name.Equals("Targax") Then p.prt.haircolor = Color.FromArgb(255, 20, 20, 20) Else p.prt.haircolor = Color.FromArgb(255, 245, 231, 184)
        If p.breastSize < 3 And Not p.pClass.name.Equals("Magical Girl") Then
            p.prt.setIAInd(pInd.body, 7, True, True)
            p.breastSize = 3
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
            p.reverseBSRoute()
        End If

        If Not p.equippedArmor.getName.Equals("Naked") And Not p.pClass.name.Equals("Magical Girl") Then

            If p.equippedArmor.slutVarInd = -1 Then
                Equipment.clothesChange("Skimpy_Clothes")
            Else
                Equipment.clothingCurse1()
            End If
        End If
        If p.name <> "Targax" Then
            p.prt.haircolor = Color.FromArgb(255, 250, 250, 205)
            p.prt.setIAInd(pInd.rearhair, 6, True, True)
            p.prt.setIAInd(pInd.midhair, 6, True, True)
            p.prt.setIAInd(pInd.eyes, 8, True, True)
            p.prt.setIAInd(pInd.fronthair, 7, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 16, True, True)
        End If
        p.prt.setIAInd(pInd.mouth, 6, True, True)
        If game.mDun.numCurrFloor < 6 Then p.pImage = Game.picPlayerB.BackgroundImage Else p.pImage = Game.picBimbof.BackgroundImage
        p.TextColor = Color.HotPink
        p.perks("bimbotf") = -1
        p.drawPort()
        stopTF()
        Game.pushLblEvent(out)
    End Sub
    Sub doubleTf()
        Dim p As Player = Game.player
        Dim out As String = ""
        If Not p.prt.sexBool Then
            out += "In your haze, you look down to see breasts blossoming from your chest. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. As your dainty hands move down your body, you discover that you no longer have a cock and balls, and insted have a tight moist cunt.  Your hair lengthens, becoming a platinum blonde, and your clothes change to match your new figure."
            p.sex = "Female"
        ElseIf p.prt.sexBool And p.breastSize < 3 Then
            out += "In your haze, you look down at your tits. You, like, never noticed how round and big they had got. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes change to match your new figure."
        ElseIf p.prt.sexBool And p.breastSize >= 3 Then
            out += "In your haze, you look down to see your clothes have become tight and pink. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes finish changing to match your new figure."
        End If
        Game.pushLblEvent(out)
        p.pClass = p.classes("Bimbo")
        p.lust += 50
        'final tf Stage
        If p.prt.checkNDefFemInd(6, 6) Then p.prt.setIAInd(pInd.ears, 0, True, True)
        Polymorph.giveRNDBimName(p)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.prt.haircolor = Color.FromArgb(255, 245, 231, 184)
        If p.breastSize < 3 And Not p.pClass.name.Equals("Magical Girl") Then
            p.prt.setIAInd(pInd.body, 7, True, True)
            p.breastSize = 3
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
            p.reverseBSRoute()
        End If

        If Not p.equippedArmor.getName.Equals("Naked") And Not p.pClass.name.Equals("Magical Girl") Then
            If p.equippedArmor.slutVarInd = -1 Then
                Equipment.clothesChange("Very_Skimpy_Clothes")
            Else
                Equipment.clothingCurse1()
            End If
        End If

        p.prt.haircolor = Color.FromArgb(255, 250, 250, 205)
        p.prt.setIAInd(pInd.rearhair, 23, True, True)
        p.prt.setIAInd(pInd.midhair, 26, True, True)
        p.prt.setIAInd(pInd.eyes, 32, True, True)
        p.prt.setIAInd(pInd.fronthair, 24, True, True)
        p.prt.setIAInd(pInd.mouth, 17, True, True)

        p.setPImage()
        p.TextColor = Color.FromArgb(255, 255, 235, 240)
        p.perks("bimbotf") = -1
        p.drawPort()
        stopTF()
    End Sub

    Sub chickenTf()
        Dim p As Player = Game.player
        Dim cRed = Color.FromArgb(255, 215, 0, 4)
        Dim out As String = "As you don the chicken suit you found, part of you half expects to turn into some sort of bird.  You chuckle to yourself at the idea, and this quickly devolves into a giggling fit.  Parting your short red bangs off to one side, you adjust your large breasts in the suit.  You note that despite covering most of your body, it doesn't even begin to provide enough support.  You strip some parts of the outfit away, shift other parts around, and soon you are left with a pair of wings and a set of straps that provide just about all the support you think you're going to get out of it.  Proud of your handiwork, you strut back out into the dungeon still giggling at the noshun...notshi...""idea"" that some silly chicken costume could change you in any way."
        Game.pushLblEvent(out)
        p.pClass = p.classes("Bimbo")
        p.lust += 20

        'final tf Stage
        If p.prt.checkNDefFemInd(6, 6) Then p.prt.setIAInd(pInd.ears, 0, True, True)
        Polymorph.giveRNDBimName(p)
        p.prt.setIAInd(pInd.cloak, 0, True, False) 'glasses
        p.prt.setIAInd(pInd.hat, 0, True, False) 'hat

        p.prt.haircolor = cRed
        If p.breastSize < 3 And Not p.pClass.name.Equals("Magical Girl") Then
            p.prt.setIAInd(pInd.body, 7, True, True)
            p.breastSize = 3
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
            p.reverseBSRoute()
        End If

        p.prt.haircolor = cRed
        p.prt.setIAInd(pInd.rearhair, 11, True, True) 'rhair 2
        p.prt.setIAInd(pInd.midhair, 11, True, True) 'rhair 1
        p.prt.setIAInd(pInd.eyes, 8, True, True) 'eyes
        p.prt.setIAInd(pInd.fronthair, 17, True, True) 'fhair
        p.prt.setIAInd(pInd.mouth, 6, True, True) 'mouth

        p.setPImage()
        p.perks("bimbotf") = -1
        p.drawPort()
        stopTF()
    End Sub

    Sub step2alt()
        Dim p As player = game.player

        Dim mstf = New MagSlutTF(1, 0, 0, False)
        mstf.step2()
        Game.pushLblEvent("You immediatly feel funny, the increased magic in your system reacting swiftly with the gum.  In your haze, you look down to see your clothes have become tight and pink. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes finish changing to match your new figure.")
        p.lust += 10

        p.TextColor = Color.HotPink
        p.perks("bimbotf") = -1
        stopTF()
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player.perks("bimbotf") = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Not Game.player.prt.haircolor.Equals(bimboyellow) Then
            Return AddressOf hairColorShift
        End If
        If Game.player.pClass.name = "Magical Girl" Then
            Return AddressOf step2alt
        End If
        If Game.player.perks("bimbotf") = -1 Then
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
        turnsTilNextStep = 5 + (Int(Rnd() * 5) + 1)
        turnsTilNextStep += generatWILResistance()
    End Sub
End Class
