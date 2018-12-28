Public Class BimboTF
    Inherits Transformation
    Public Shared bimboyellow As Color = Color.FromArgb(255, 255, 230, 160)
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Bimbo"
        nextStep = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Bimbo"
        nextStep = getNextStep(cs)
    End Sub

    Sub hairColorShift()
        Game.player.changeHairColor(Game.cShift(Game.player.haircolor, bimboyellow, 25))
        If Not Game.player.getHairColor.Equals(bimboyellow) Then currStep -= 1
        Game.pushLblEvent("Your hair becomes slightly lighter, trending toward a platinum blonde.")
    End Sub
    Sub step1()
        Dim p As player = game.player
        If p.name = "Targax" Then
            p.haircolor = Color.FromArgb(255, 255, 0, 147)
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(9, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(9, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(13, True)
        Else
            p.haircolor = bimboyellow
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(1, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(5, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(6, True)
        End If

        If p.iArrInd(6).Item1 = 6 And p.iArrInd(6).Item2 Then p.iArrInd(6) = New Tuple(Of Integer, Boolean)(0, True)
        Polymorph.giveRNDFFName(p)
        p.iArrInd(8) = New Tuple(Of Integer, Boolean)(5, True)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(7, True)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
        If Not p.pClass.name.Equals("Magic Girl") Then p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)

        If p.breastSize = 1 Then
            p.iArrInd(2) = New Tuple(Of Integer, Boolean)(6, True)
            If p.equippedArmor.getName.ToString() = "Common_Clothes" Then
                p.iArrInd(3) = New Tuple(Of Integer, Boolean)(5, True)
            End If
        Else
            p.be()
        End If
        If p.pClass.name.Equals("Magic Girl") Then
            p.iArrInd(16) = New Tuple(Of Integer, Boolean)(CharacterGenerator.fHat.Count - 3, True)
            p.perks("bimbotf") = 24
        End If
        p.lust += 10
        Game.pushLblEvent("You pause to rub your temples, a massive headache comming down on you like a ton of bricks.  As you take a few minutes to recover, you notice that your center of balance is off and more disturbingly, that you can't seem to focus enough to figure out why." & vbCrLf & vbCrLf & "Maybe you can just walk this off...")
    End Sub
    Sub step2()
        Dim p As player = game.player
        Dim out As String = ""
        If Not p.sexBool Then
            out += "In your haze, you look down to see breasts blossoming from your chest. You giggle, all traces of intelect vanishing as your body becomes more curvy and feminine. As your dainty hands move down your body, you discover that you no longer have a cock and balls, and insted have a tight moist cunt.  Your hair lengthens, becoming a platinum blonde, and your clothes change to match your new figure."
            p.sex = "Female"
            p.sexBool = True
        ElseIf p.sexBool And p.breastSize < 3 Then
            out += "In your haze, you look down at your tits. You, like, never noticed how round and big they had got. You giggle, all traces of intelect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes change to match your new figure."
        ElseIf p.sexBool And p.breastSize >= 3 Then
            out += "In your haze, you look down to see your clothes have become tight and pink. You giggle, all traces of intelect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes finish changing to match your new figure."
        End If
        Game.pushLblEvent(out)
        p.pClass = p.classes("Bimbo")
        p.lust += 10
        'final tf Stage
        If p.name.Equals("Targax") Then p.haircolor = Color.FromArgb(255, 20, 20, 20) Else p.haircolor = Color.FromArgb(255, 245, 231, 184)
        If p.breastSize < 3 And Not p.pClass.name.Equals("Magic Girl") Then
            p.iArrInd(2) = New Tuple(Of Integer, Boolean)(7, True)
        Else
            p.be()
        End If

        If Not p.equippedArmor.getName.Equals("Naked") And Not p.pClass.name.Equals("Magic Girl") Then
            Dim eAName As String = p.equippedArmor.getName.ToString
            Equipment.clothingCurse1()
            If eAName = p.equippedArmor.getName Then
                Equipment.clothesChange("Skimpy_Clothes")
            End If
        End If
        If p.name <> "Targax" Then
            p.haircolor = Color.FromArgb(255, 250, 250, 205)
            p.iArrInd(1) = New Tuple(Of Integer, Boolean)(6, True)
            p.iArrInd(5) = New Tuple(Of Integer, Boolean)(6, True)
            p.iArrInd(9) = New Tuple(Of Integer, Boolean)(8, True)
            p.iArrInd(15) = New Tuple(Of Integer, Boolean)(7, True)
        Else
            p.iArrInd(9) = New Tuple(Of Integer, Boolean)(16, True)
        End If
        p.iArrInd(8) = New Tuple(Of Integer, Boolean)(6, True)
        If Game.floor < 6 Then p.pImage = Game.picPlayerB.BackgroundImage Else p.pImage = Game.picBimbof.BackgroundImage
        p.TextColor = Color.HotPink
        p.perks("bimbotf") = -1
        stopTF()
    End Sub
    Sub step2alt()
        Dim p As player = game.player
        p.iArrInd(16) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(2) = New Tuple(Of Integer, Boolean)(7, True)
        p.haircolor = Color.FromArgb(255, 255, 250, 205)
        p.iArrInd(1) = New Tuple(Of Integer, Boolean)(10, True)
        p.iArrInd(5) = New Tuple(Of Integer, Boolean)(10, True)
        p.iArrInd(15) = New Tuple(Of Integer, Boolean)(7, True)
        p.iArrInd(6) = New Tuple(Of Integer, Boolean)(0, True)
        p.iArrInd(8) = New Tuple(Of Integer, Boolean)(6, True)
        p.iArrInd(9) = New Tuple(Of Integer, Boolean)(8, True)
        p.iArrInd(13) = New Tuple(Of Integer, Boolean)(0, True)
        Equipment.clothesChange("Magic_Girl_Outfit")
        p.breastSize = 3
        Game.pushLblEvent("You immediatly feel funny, the increased magic in your system reacting swiftly with the gum.  In your haze, you look down to see your clothes have become tight and pink. You giggle, all traces of intelect vanishing as your body becomes more curvy and feminine. Your hair lengthens, becoming a platinum blonde, and your clothes finish changing to match your new figure.")
        p.pClass = p.classes("Bimbo")
        p.lust += 10
        If Game.floor < 6 Then p.pImage = Game.picPlayerB.BackgroundImage Else p.pImage = Game.picBimbof.BackgroundImage
        p.TextColor = Color.HotPink
        p.perks("bimbotf") = -1
        stopTF()
    End Sub
    Public Overrides Sub stopTF()
        MyBase.stopTF()
        Game.player.perks("bimbotf") = -1
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Not Game.player.haircolor.Equals(bimboyellow) Then
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
