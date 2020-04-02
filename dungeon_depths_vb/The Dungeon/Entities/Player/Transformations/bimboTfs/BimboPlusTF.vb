Public NotInheritable Class BimboPlusTF
    Inherits BimboTF

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

    'Step 1
    Public Overrides Sub s1BimboHairChange(ByRef p As Player)
        p.prt.haircolor = bimboyellow1
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 5, True, True)
        p.prt.setIAInd(pInd.fronthair, 6, True, True)
    End Sub
    Public Overrides Sub s1TFText(ByRef p As Player)
        Game.pushLblEvent("You pause to rub your temples, a massive headache comming down on you like a ton of bricks.  As you take a few minutes to recover, you notice that your center of balance is off.  You hypothisize that maybe that vial you drank might be causing these effects." & vbCrLf & vbCrLf & "Maybe you can just walk this off...")
    End Sub

    'Step 2
    Public Overrides Sub s2M2F(ByRef p As Player, ByRef out As String, ByRef haircolor As String)
        haircolor = "platinum blonde"
        If Not p.prt.sexBool Then
            out += "Mind clearer than ever, you look down to see breasts blossoming from your chest.  You smirk; while you look like a typical brainless bimbo, you're far more intellegent than you were before. As your dainty hands move down your body, you discover that you no longer have a cock and balls, and insted have a tight moist cunt.  Your hair lengthens, becoming a " & haircolor & ", and your clothes change to match your new figure.  While the effects on your body confirm your hypothesis that BIM_II is likely the chemical used in those sticks of gum the increased IQ hints that there may be another compound involved."
            p.sex = "Female"
        ElseIf p.prt.sexBool And p.breastSize < 3 Then
            out += "Mind clearer than ever, you look down at your tits. You notice that they seem to have swollen slightly.  You smirk; while you look like a typical brainless bimbo, you're far more intellegent than you were before.  Your hair lengthens, becoming a " & haircolor & ", and your clothes change to match your new figure.  While the effects on your body confirm your hypothesis that BIM_II is likely the chemical used in those sticks of gum the increased IQ hints that there may be another compound involved."
        ElseIf p.prt.sexBool And p.breastSize >= 3 Then
            out += "Mind clearer than ever, you look down to see your clothes have become tight and pink.  You smirk; while you look like a typical brainless bimbo, you're far more intellegent than you were before.  Your hair lengthens, becoming a " & haircolor & ", and your clothes finish changing to match your new figure.  While the effects on your body confirm your hypothesis that BIM_II is likely the chemical used in those sticks of gum the increased IQ hints that there may be another compound involved."
        End If
    End Sub
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimboyellow2
        p.prt.setIAInd(pInd.rearhair, 6, True, True)
        p.prt.setIAInd(pInd.midhair, 6, True, True)
        p.prt.setIAInd(pInd.fronthair, 7, True, True)
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        If p.name <> "Targax" Then
            p.prt.setIAInd(pInd.eyes, 34, True, True)
        Else
            p.prt.setIAInd(pInd.eyes, 16, True, True)
        End If

        p.prt.setIAInd(pInd.mouth, 6, True, True)
        p.prt.setIAInd(pInd.glasses, 2, True, False)
    End Sub

    'Alternate Step 2
    Overrides Sub step2alt()
        Dim p As Player = Game.player1
        p.prt.setIAInd(pInd.hat, 0, True, True)
        p.prt.setIAInd(pInd.body, 7, True, True)
        p.prt.haircolor = Color.FromArgb(255, 255, 250, 205)
        p.prt.setIAInd(pInd.rearhair, 10, True, True)
        p.prt.setIAInd(pInd.midhair, 10, True, True)
        p.prt.setIAInd(pInd.fronthair, 7, True, True)
        p.prt.setIAInd(pInd.ears, 0, True, True)
        p.prt.setIAInd(pInd.mouth, 6, True, True)
        p.prt.setIAInd(pInd.eyes, 34, True, True)
        p.prt.setIAInd(pInd.cloak, 0, True, True)
        p.prt.setIAInd(pInd.glasses, 2, True, False)
        Equipment.clothesChange("Magical_Slut_Outfit")
        p.breastSize = 3
        Game.pushLblEvent("You immediatly feel funny, the increased magic in your system reacting swiftly with the gum.  Mind clearer than ever, you look down to see your clothes have become tight and pink. You smirk; while you look like a typical brainless bimbo, you're far more intellegent than you were before. Your hair lengthens, becoming a platinum blonde, and your clothes finish changing to match your new figure.  While the effects on your body confirm your hypothesis that BIM_II is likely the chemical used in those sticks of gum the increased IQ hints that there may be another compound involved.")
        p.lust += 10
        If game.mDun.numCurrFloor < 6 Then p.pImage = Game.picPlayerB.BackgroundImage Else p.pImage = Game.picBimbof.BackgroundImage
        p.TextColor = Color.HotPink
        p.perks("bimbotf") = -1
        stopTF()
    End Sub
End Class
