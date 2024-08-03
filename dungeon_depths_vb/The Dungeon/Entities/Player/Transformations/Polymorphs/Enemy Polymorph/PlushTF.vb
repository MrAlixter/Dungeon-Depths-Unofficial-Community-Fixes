Public NotInheritable Class PlushTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.plush

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
        turns_until_next_step = 400
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        p.changeForm("Plush")

        'transformation
        p.prt.setIAInd(pInd.mouth, 24, True, True)
        p.prt.setIAInd(pInd.eyes, 46, True, True)
        p.prt.setIAInd(pInd.face, 10, True, True)
    End Sub
End Class
