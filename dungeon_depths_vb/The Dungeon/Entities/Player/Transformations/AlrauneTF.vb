Public NotInheritable Class AlrauneTF
    Inherits Transformation
    Dim hc As Color = Color.FromArgb(255, 255, 175, 200)
    Dim sc As Color = Color.FromArgb(255, 118, 228, 151)

    Private Const TF_IND As tfind = tfind.alraune

    Sub New()
        Me.New(4, 3, 2.0, True)
        tf_name = TF_IND
    End Sub
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        MyBase.update_during_combat = True
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.update_during_combat = True
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As Player = Game.player1

        p.prt.setIAInd(pInd.rearhair, 14, True, True)
        p.prt.setIAInd(pInd.midhair, 13, True, True)
        p.prt.setIAInd(pInd.fronthair, 22, True, True)

        If p.className.Equals("Mindless") Then
            p.pState.iArrInd(pInd.rearhair) = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)
            p.pState.iArrInd(pInd.midhair) = New Tuple(Of Integer, Boolean, Boolean)(13, True, True)
            p.pState.iArrInd(pInd.fronthair) = New Tuple(Of Integer, Boolean, Boolean)(22, True, True)
        End If

        TextEvent.push("Your hair flows down, and small petals begin forming in it.  You now have Alraune hair!")
    End Sub
    Sub step2()
        Dim p As Player = Game.player1

        p.prt.setIAInd(pInd.mouth, 6, True, True)
        p.prt.setIAInd(pInd.eyes, 35, True, True)

        If p.className.Equals("Mindless") Then
            p.pState.iArrInd(pInd.mouth) = New Tuple(Of Integer, Boolean, Boolean)(6, True, True)
            p.pState.iArrInd(pInd.eyes) = New Tuple(Of Integer, Boolean, Boolean)(35, True, True)
        End If

        TextEvent.push("You now have the facial features of an Alraune!")
    End Sub
    Sub step3()
        Dim p As Player = Game.player1

        p.changeHairColor(DDUtils.cShift(p.prt.haircolor, hc, 100))
        p.changeSkinColor(DDUtils.cShift(p.prt.skincolor, sc, 100))

        If p.className.Equals("Mindless") Then
            p.pState.saveHCSC(p.prt.haircolor, p.prt.skincolor)
        End If

        If p.breastSize = -1 Then p.breastSize = 0
        If p.breastSize > 4 Then p.be()
        If p.className.Equals("Mindless") Then
            p.pState.breastSize = p.breastSize
        End If
        If Not p.prt.haircolor.Equals(hc) Or Not p.prt.skincolor.Equals(sc) Then curr_step -= 1
    End Sub
    Sub step4()
        Dim p As Player = Game.player1

        If Game.combat_engaged Then Game.fromCombat()
        TextEvent.push("You are now an Alraune!")
        TextEvent.pushLog("You are now an Alraune!")
        p.changeForm("Alraune")
        p.learnSpell("Mesmeric Bloom")
    End Sub

    Sub fullTF()
        Dim p As Player = Game.player1

        p.changeForm("Alraune")

        If p.sex = "Male" Then
            p.prt.setIAInd(pInd.midhair, 6, False, True)
            p.prt.setIAInd(pInd.fronthair, 7, False, True)
            p.prt.setIAInd(pInd.eyes, 14, False, True)
        Else
            p.prt.setIAInd(pInd.midhair, 13, True, True)
            p.prt.setIAInd(pInd.fronthair, 22, True, True)
            p.prt.setIAInd(pInd.eyes, 52, True, True)
        End If


        p.changeHairColor(hc)
        p.changeSkinColor(sc)

        'transformation description push
        Dim out = "As you chew on a particularly leafy portion of the salad, you feel the familiar flow of transformative magic flow through your body..." & DDUtils.RNRN &
                  "Preparing for the worse, you are surprised to find that it seems to be charging your body with a more positive energy than you were maybe expecting.  It isn't until a leaf droops down from the top of your head that you realize something has indeed been changed." & DDUtils.RNRN &
                  "You are now a Alurane!"

        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)

        p.learnSpecial("Lurk")

        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        TextEvent.push(out)
    End Sub

    Sub fullRNDTF()
        Dim p As Player = Game.player1

        p.changeForm("Alraune")

        If p.sex = "Male" Then
            p.prt.setIAInd(pInd.midhair, 6, False, True)
            p.prt.setIAInd(pInd.fronthair, 7, False, True)
            p.prt.setIAInd(pInd.eyes, 14, False, True)
        Else
            p.prt.setIAInd(pInd.midhair, 13, True, True)
            p.prt.setIAInd(pInd.fronthair, 22, True, True)
            p.prt.setIAInd(pInd.eyes, 52, True, True)
        End If


        p.changeHairColor(hc)
        p.changeSkinColor(sc)

        'transformation description push
        Dim out = "A surge of transformative magic begins to flow through your body..." & DDUtils.RNRN &
                  "Preparing for the worse, you are surprised to find that it seems to be charging your body with a more positive energy than you were maybe expecting.  It isn't until a leaf droops down from the top of your head that you realize something has indeed been changed." & DDUtils.RNRN &
                  "You are now a Alurane!"

        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)

        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        TextEvent.push(out)
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        If Not Game.combat_engaged Then Return AddressOf stopTF
        Select Case stage
            Case 0
                Return AddressOf step1
            Case 1
                Return AddressOf step2
            Case 2
                Return AddressOf step3
            Case 3
                Return AddressOf step4
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = 3
        turns_until_next_step += generatWILResistance()
    End Sub
End Class
