Public NotInheritable Class MinotaurCowTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.femminopolymorph

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        next_step = getNextStep(cs)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        stopTF()
    End Sub

    Public Overrides Sub step1()
        Dim p As player = Game.player1
        Dim out = ""

        'unequips
        EquipmentDialogBackend.armorChange(p, "Cow_Print_Bra")

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
        TextEvent.push(out)
    End Sub
End Class
