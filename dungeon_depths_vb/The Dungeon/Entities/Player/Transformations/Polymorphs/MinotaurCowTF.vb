Public NotInheritable Class MinotaurCowTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "MinotaurCowTF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Overrides Sub step1()
        Dim p As player = game.player1
        Dim out = ""

        'unequips
        Equipment.clothesChange(p, "Cow_Print_Bra")

        'minotaur cow tf transformation
        If p.sex = "Male" Then
            p.MtF()
            out += " Your body becomes daintier, and you are soon fully female."
        End If
        p.be()
        p.be()
        p.be()
        p.prt.setIAInd(pInd.rearhair, 16, True, True)
        p.prt.setIAInd(pInd.midhair, 20, True, True)
        p.prt.setIAInd(pInd.ears, 8, True, True)
        p.prt.setIAInd(pInd.fronthair, 16, True, True)
        p.prt.setIAInd(pInd.horns, 2, True, False)

        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        Game.pushLblEvent(out)
    End Sub
End Class
