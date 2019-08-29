Public Class MBimboTF
    Inherits Transformation
    Public Shared bimboblue1 As Color = Color.FromArgb(255, 200, 255, 250)
    Public Shared bimboblue2 As Color = Color.FromArgb(255, 230, 255, 255)

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.updateDuringCombat = False
        tfName = "MBimbo"
        nextStep = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.updateDuringCombat = False
        tfName = "MBimbo"
        nextStep = getNextStep(cs)
    End Sub

    Sub hairColorShift()
        Game.player.prt.haircolor = Game.cShift(Game.player.prt.haircolor, bimboblue1, 25)
        If Not Game.player.getHairColor.Equals(bimboblue1) Then currStep -= 1
        Game.pushLblEvent("Your hair becomes slightly lighter, brightening to a cool, pale blue.")
    End Sub
    Sub step1()
        Dim p As player = game.player
        If p.name = "Targax" Then
            p.prt.haircolor = Color.FromArgb(255, 255, 0, 147)
            p.prt.setIAInd(1, 9, True, True)
            p.prt.setIAInd(5, 9, True, True)
            p.prt.setIAInd(15, 13, True, True)
        Else
            p.prt.haircolor = bimboblue1
            p.prt.setIAInd(1, 1, True, True)
            p.prt.setIAInd(5, 5, True, True)
            p.prt.setIAInd(15, 6, True, True)
        End If

        If p.prt.checkNDefFemInd(6, 6) Then p.prt.setIAInd(6, 0, True, True)
        Polymorph.giveRNDBimName(p)
        p.prt.setIAInd(8, 5, True, True)
        p.prt.setIAInd(9, 7, True, True)
        p.prt.setIAInd(13, 0, True, False)
        If Not p.pClass.name.Equals("Magic Girl") Then p.prt.setIAInd(16, 0, True, False)

        If p.breastSize = 1 Then
            p.prt.setIAInd(2, 6, True, True)
            p.breastSize = 2
            If p.equippedArmor.getName.ToString() = "Common_Clothes" Then
                p.prt.setIAInd(3, 5, True, True)
            End If
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
            p.reverseBSRoute()
        End If
        If p.pClass.name.Equals("Magic Girl") Then
            p.prt.setIAInd(16, Portrait.imgLib.atrs("Hat").getF.Count - 3, True, True)
            p.perks("bimbotf") = 24
        End If
        p.lust += 10
        p.createP()
        Game.pushLblEvent("You pause to rub your temples, a massive headache comming down on you like a ton of bricks.  As you take a few minutes to recover, you notice that your center of balance is off and more disturbingly, that you can't seem to focus enough to figure out why." & vbCrLf & vbCrLf & "Maybe you can just walk this off...")
    End Sub
    Sub step2()
        Dim p As player = game.player
        Dim out As String = ""
        If Not p.prt.sexBool Then
            out += "In your haze, you look down to see breasts blossoming from your chest. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. As your dainty hands move down your body, you discover that you no longer have a cock and balls, and insted have a tight moist cunt.  Your hair lengthens, becoming a minty cyan, and your clothes change to match your new figure."
            p.sex = "Female"
        ElseIf p.prt.sexBool And p.breastSize < 3 Then
            out += "In your haze, you look down at your tits. You, like, never noticed how round and big they had got. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a minty cyan, and your clothes change to match your new figure."
        ElseIf p.prt.sexBool And p.breastSize >= 3 Then
            out += "In your haze, you look down to see your clothes have become tight and revealing. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a minty cyan, and your clothes finish changing to match your new figure."
        End If
        Game.pushLblEvent(out)
        p.pClass = p.classes("Bimbo")
        p.lust += 10
        'final tf Stage
        If p.name.Equals("Targax") Then p.prt.haircolor = Color.FromArgb(255, 20, 20, 20) Else p.prt.haircolor = Color.FromArgb(255, 245, 231, 184)
        If p.breastSize < 3 And Not p.pClass.name.Equals("Magic Girl") Then
            p.prt.setIAInd(2, 7, True, True)
            p.breastSize = 3
        ElseIf p.breastSize < 7 Then
            p.breastSize += 1
            p.reverseBSRoute()
        End If

        If Not p.equippedArmor.getName.Equals("Naked") And Not p.pClass.name.Equals("Magic Girl") Then

            If p.equippedArmor.slutVarInd = -1 Then
                Equipment.clothesChange("Skimpy_Clothes")
            Else
                Equipment.clothingCurse1()
            End If
        End If
        If p.name <> "Targax" Then
            p.prt.haircolor = bimboblue2
            p.prt.setIAInd(1, 19, True, True)  'rearhair1
            p.prt.setIAInd(5, 23, True, True)  'rearhair2
            p.prt.setIAInd(9, 27, True, True)  'eyes
            p.prt.setIAInd(15, 20, True, True) 'fronthair
        Else
            p.prt.setIAInd(9, 16, True, True)
        End If
        p.prt.setIAInd(8, 13, True, True)  'mouth
        p.setPImage()
        p.TextColor = Color.HotPink
        p.perks("bimbotf") = -1
        p.createP()
        stopTF()
    End Sub
    Sub step2alt()
        Dim p As player = game.player
        p.prt.setIAInd(16, 0, True, True)
        p.prt.setIAInd(2, 7, True, True)
        p.prt.haircolor = bimboblue2
        p.prt.setIAInd(1, 10, True, True)
        p.prt.setIAInd(5, 10, True, True)
        p.prt.setIAInd(15, 7, True, True)
        p.prt.setIAInd(6, 0, True, True)
        p.prt.setIAInd(8, 6, True, True)
        p.prt.setIAInd(9, 26, True, True)
        p.prt.setIAInd(13, 0, True, True)
        Equipment.clothesChange("Magic_Girl_Outfit")
        p.breastSize = 3
        Game.pushLblEvent("You immediatly feel funny, the increased magic in your system reacting swiftly with the gum.  In your haze, you look down to see your clothes have become tight and pink. You giggle, all traces of intellect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a minty cyan, and your clothes finish changing to match your new figure.")
        p.lust += 10
        If game.mDun.numCurrFloor < 6 Then p.pImage = Game.picPlayerB.BackgroundImage Else p.pImage = Game.picBimbof.BackgroundImage
        p.perks("bimbotf") = -1
        stopTF()
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player.perks("bimbotf") = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Not Game.player.prt.haircolor.Equals(bimboblue1) And Not Game.player.prt.haircolor.Equals(bimboblue2) Then
            Return AddressOf hairColorShift
        End If
        If Game.player.pClass.name = "Magic Girl" Then
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
