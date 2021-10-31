Public NotInheritable Class AngelTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.angel

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1
        Dim out = ""

        'angel transformation
        p.changeHairColor(Color.FromArgb(255, 245, 231, 184))
        p.prt.setIAInd(pInd.rearhair, 5, True, True)
        p.prt.setIAInd(pInd.midhair, 14, True, True)
        p.prt.setIAInd(pInd.fronthair, 11, True, True)
        p.prt.setIAInd(pInd.wings, 1, True, False)

        'transformation description push
        out += "As you bite into the cake, you are lost in its sweet flavor.  So lost, in fact, that you miss the large white wings growing on you back.  You are now an angel!"
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        TextEvent.push(out)
    End Sub
End Class
