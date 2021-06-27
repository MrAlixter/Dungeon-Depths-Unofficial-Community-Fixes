Public NotInheritable Class BUDollTFBeach
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.blowupdollbeach

    Sub New()
        MyBase.New()
        tf_name = TF_IND
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        next_step = getNextStep(cs)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = Int(Rnd() * 20) + 67
    End Sub

    Public Overrides Sub step1()
        Dim p As player = Game.player1
        Dim out = ""

        'equip clothes
        Equipment.clothesChange(p, "Naked")
        p.changeForm("Blowup Doll")

        'bu doll transformation
        p.breastSize = 3
        p.buttSize = 3
        p.dickSize = -1

        p.reverseAllRoute()

        p.prt.setIAInd(pInd.rearhair, 39, True, True)
        p.prt.setIAInd(pInd.midhair, 13, True, True)

        p.prt.setIAInd(pInd.face, 1, True, True)
        p.prt.setIAInd(pInd.shoulders, 9, True, False)
        p.prt.setIAInd(pInd.genitalia, 5, True, False)

        p.prt.setIAInd(pInd.nose, 1, True, True)
        p.prt.setIAInd(pInd.mouth, 12, True, True)
        p.prt.setIAInd(pInd.eyes, 17, True, True)
        p.prt.setIAInd(pInd.eyebrows, 2, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.prt.changeHairColor(DDUtils.cShift(p.prt.haircolor, Color.White, 50))
        p.prt.changeSkinColor(Color.FromArgb(255, 240, 184, 160))

        'transformation description push
        out += "As you near the end of the ice pop, you suddenly find yourself feeling... strange..." & DDUtils.RNRN &
               "Your head feels dizzy, and as you reach for your bag to see if you have anything that might help you find that you can no longer move your limbs.  Your body collapses in on itself, leaving you as nothing more than an immobile sheet of vinyl." & DDUtils.RNRN &
               "A rush of air from within inflates you into an exagerated female form.  Propping yourself up, you try to re-equip your gear only to find that you can barely hold a weapon, let alone wear armor.  A warning on the stick of the ice pop lists ""summer fun"" as a side effect, and it seems to have turned you into a sentient sex doll!"
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        Game.pushLblEvent(out)
    End Sub

    Public Overrides Sub stopTF()
        MyBase.stopTF()
    End Sub

    Public Overrides Function getNextStep(stage As Integer) As Action
        Dim p As player = Game.player1
        Select Case stage
            Case 0
                Return AddressOf step1
            Case Else
                Return AddressOf stopTF
        End Select
    End Function
End Class
