Public NotInheritable Class BUDollTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "BUDollTF"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = Int(Rnd() * 25) + 5
    End Sub

    Public Overrides Sub step1()
        Dim p As player = game.player1
        Dim out = ""

        'equip clothes
        Equipment.clothesChange("Naked")
        p.pForm = p.forms("Blowup Doll")

        'bu doll transformation

        p.breastSize = 4

        p.prt.setIAInd(pInd.rearhair, 14, True, True)
        p.prt.setIAInd(pInd.face, 1, True, True)
        p.prt.setIAInd(pInd.midhair, 18, True, True)
        p.prt.setIAInd(pInd.nose, 1, True, True)
        p.prt.setIAInd(pInd.body, 9, True, True)
        p.prt.setIAInd(pInd.mouth, 12, True, True)
        p.prt.setIAInd(pInd.eyes, 17, True, True)
        p.prt.setIAInd(pInd.eyebrows, 2, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, True)
        p.prt.setIAInd(pInd.fronthair, 14, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.reverseBSroute()
        p.prt.setIAInd(pInd.shoulders, 9, True, False)
        p.prt.setIAInd(pInd.genitalia, 5, True, False)

        'transformation description push
        out += "Looking down, you see some sort of coupon laying on the ground.  Picking it up, you read " & vbCrLf &
                               """Need potent magic items with no questions asked?  Hit up The Brown Hat, coming to a dungeon near " &
                               "you soon!  See the back for a free sample." & vbCrLf &
                               "Flipping the scrap over, your fingers brush against a rune, activating it with the slightest touch." &
                               "  You suddenly find yourself feeling immobile, yet strangely light as your body collapses in on itself, leaving you an immobile sheet of vinyl." &
                               "  A rush of air from the rune returns you to an exagerated female form, though apart from having changed with the rest of your " &
                               "genitalia seems largly unchanged.  Propping yourself up, you try to re-equip your gear only to find that you can barely hold a weapon, let alone wear armor. This ""free sample"" seems to have turned you into a sentient sex doll." & DDUtils.RNRN & "Brown Hat, huh..."
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        Game.pushLblEvent(out)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = game.player1
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
