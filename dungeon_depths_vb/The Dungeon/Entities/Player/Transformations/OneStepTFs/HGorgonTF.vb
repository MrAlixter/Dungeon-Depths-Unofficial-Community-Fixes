Public NotInheritable Class HGorgonTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.halfgorgon

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

        p.changeForm("Half-Gorgon")

        'transformation
        If p.sex.Equals("Male") Then p.MtF()
        p.changeHairColor(Color.FromArgb(255, 92, 154, 1))
        p.prt.setIAInd(pInd.rearhair, 20, True, True)
        p.prt.setIAInd(pInd.midhair, 22, True, True)
        p.prt.setIAInd(pInd.fronthair, 21, True, True)
        p.prt.setIAInd(pInd.eyes, 30, True, True)
        p.prt.setIAInd(pInd.eyebrows, 5, True, False)



        p.learnSpell("Petrify II")
    End Sub
End Class
