Public Class MagGirlTF
    Inherits Transformation
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Magic Girl"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Magic Girl"
        nextStep = getNextStep(cs)
    End Sub

    Sub step1()
        Dim p As player = game.player
        p.pClass = p.classes("Magic Girl​")
        Dim out = "Swinging your wand, you are engulfed in a rain of stars. As the light around your body grows blinding and your clothes disolve into the aether, you become a buxom young woman wearing a skimpy uniform!"
        If p.sex = "Male" Then
            p.sex = "Female"
        End If
        p.prt.setIAInd(16, Portrait.imgLib.atrs("Hat").getF.Count - 3, True, False)
        Game.pushLblEvent(out, AddressOf step2)


        p.TextColor = Game.lblEvent.ForeColor
        p.specialRoute()
        p.magicRoute()
    End Sub
    Sub step2()
        Game.lblEvent.Text = ""
        Dim p As Player = Game.player
        If p.magGState.initFlag Then
            p.magGState.load(p)
        Else
            p.breastSize = 1
            p.prt.setIAInd(1, 7, True, True)
            p.prt.setIAInd(2, 10, True, True)
            p.prt.setIAInd(3, 12, True, True)
            p.prt.setIAInd(4, 0, True, False)
            p.prt.setIAInd(5, 7, True, True)
            p.prt.setIAInd(6, 6, True, True)
            p.prt.setIAInd(7, 0, True, False)
            p.prt.setIAInd(8, 7, True, True)
            p.prt.setIAInd(9, 9, True, True)
            p.prt.setIAInd(10, 0, True, False)
            p.prt.setIAInd(13, 0, True, False)
            p.prt.setIAInd(15, 8, True, True)
            p.prt.setIAInd(16, 0, True, False)
            p.magGState.save(p)
            p.magGState.initFlag = True
        End If
        p.knownSpells.Add("Heartblast Starcannon")
        p.inv.add(10, 1)
        Equipment.accChange("Nothing")
        p.pClass = p.classes("Magic Girl")
        Equipment.clothesChange("Magic_Girl_Outfit")
        p.equippedArmor = New MagGirlOutfit
        Game.pushLstLog("'Heartblast Starcannon' spell learned!")
        Game.lblEvent.Visible = False
        p.canMoveFlag = True
        p.createP()

        stopTF()
    End Sub


    Shared Sub halfRevert(ByRef p As Player)
        p.pClass = p.classes("Mage")

        p.breastSize = 2
        p.reverseBSRoute()

        Equipment.clothesChange("Naked")
        p.prt.setIAInd(1, 7, True, True)
        p.prt.setIAInd(6, 0, True, False)
        p.prt.setIAInd(5, 7, True, True)
        p.prt.setIAInd(15, 7, True, True)
    End Sub
    Shared Sub chkForMagGirlRevert(ByRef p As Player)
        If Not p.pClass.name.Equals("Magic Girl") Then Exit Sub
        pushLblEventWithoutLoss("Your form wavers, and while you can maintain it you are definitly tiring out.")
        MagGirlTF.halfRevert(p)
    End Sub


    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player
        If p.pClass.name.Equals("Magic Girl​") Then
            Return AddressOf step2
        ElseIf p.pClass.name.Equals("Magic Girl") Then
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
