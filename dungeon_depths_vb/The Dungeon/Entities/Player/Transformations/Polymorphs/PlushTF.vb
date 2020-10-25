Public NotInheritable Class PlushTF
    Inherits PolymorphTF

    Sub New()
        MyBase.New()
        tfName = "Plush"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turnsTilNextStep = 400
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        'transformation
        p.prt.setIAInd(pInd.mouth, 24, True, True)
        p.prt.setIAInd(pInd.eyes, 46, True, True)
        p.prt.setIAInd(pInd.face, 10, True, True)

        p.changeForm("Plush")
    End Sub
End Class
