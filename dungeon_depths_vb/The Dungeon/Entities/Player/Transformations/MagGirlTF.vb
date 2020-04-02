Public NotInheritable Class MagGirlTF
    Inherits Transformation
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Magical Girl"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Magical Girl"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As player = game.player1
        p.pClass = p.classes("Magical Girl​")
        Dim out = "Swinging your wand, you are engulfed in a rain of stars. As the light around your body grows blinding and your clothes disolve into the aether, you become a buxom young woman wearing a skimpy uniform!"
        If p.sex = "Male" Then
            p.sex = "Female"
        End If
        p.prt.setIAInd(pInd.hat, Portrait.imgLib.atrs(pInd.hat).getF.Count - 3, True, False)
        Game.pushLblEvent(out, AddressOf step2)


        p.TextColor = Game.lblEvent.ForeColor
        p.specialRoute()
        p.magicRoute()
    End Sub
    Sub step2()
        Game.lblEvent.Text = ""
        Dim p As Player = Game.player1
        If p.magGState.initFlag Then
            p.magGState.load(p)
        Else
            p.breastSize = 2
            p.prt.setIAInd(pInd.rearhair, 7, True, True)
            p.prt.setIAInd(pInd.clothes, 12, True, True)
            p.prt.setIAInd(pInd.face, 0, True, False)
            p.prt.setIAInd(pInd.midhair, 7, True, True)
            p.prt.setIAInd(pInd.nose, 0, True, False)
            p.prt.setIAInd(pInd.mouth, 7, True, True)
            p.prt.setIAInd(pInd.eyes, 9, True, True)
            p.prt.setIAInd(pInd.eyebrows, 0, True, False)
            p.prt.setIAInd(pInd.cloak, 0, True, False)
            p.prt.setIAInd(pInd.fronthair, 8, True, True)
            p.prt.setIAInd(pInd.hat, 0, True, False)
            p.reverseallroute()
            p.magGState.save(p)
            p.magGState.initFlag = True
        End If
        If Not p.knownSpells.Contains("Heartblast Starcannon") Then p.knownSpells.Add("Heartblast Starcannon")
        If p.inv.item(10).count < 1 Then p.inv.add(10, 1)

        p.prt.setIAInd(pInd.hairacc, 2, True, True)

        Equipment.accChange("Nothing")
        p.pClass = p.classes("Magical Girl")
        Equipment.clothesChange("Magical_Girl_Outfit")
        p.equippedArmor = New MagGirlOutfit
        Game.pushLstLog("'Heartblast Starcannon' spell learned!")
        Game.lblEvent.Visible = False
        p.canMoveFlag = True
        p.drawPort()
        stopTF()
    End Sub


    Shared Sub halfRevert(ByRef p As Player)
        p.pClass = p.classes("Mage")

        p.breastSize = 2
        p.reverseallroute()

        Equipment.clothesChange("Naked")
        p.prt.setIAInd(pInd.rearhair, 7, True, True)
        p.prt.setIAInd(pInd.ears, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 7, True, True)
        p.prt.setIAInd(pInd.fronthair, 7, True, True)
    End Sub
    Shared Sub chkForMagGirlRevert(ByRef p As Player)
        If Not p.pClass.name.Equals("Magical Girl") Then Exit Sub
        pushLblEventWithoutLoss("Your form wavers, and while you can maintain it you are definitly tiring out.")
        MagGirlTF.halfRevert(p)
    End Sub


    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As Player = Game.player1
        If p.pClass.name.Equals("Magical Girl​") Then
            Return AddressOf step2
        ElseIf p.pClass.name.Equals("Magical Girl") Then
            Return AddressOf stopTF
        Else
            Return AddressOf step1
        End If
    End Function
    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 0
    End Sub

    Public Shared Sub pushLblEventWithoutLoss(ByRef out As String)
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & vbCrLf & vbCrLf & out
        Game.pushLblEvent(out)
    End Sub
End Class
