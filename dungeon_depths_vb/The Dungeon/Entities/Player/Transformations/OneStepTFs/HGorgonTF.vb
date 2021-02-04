Public NotInheritable Class HGorgonTF
    Inherits OneStepTF
    Sub New()
        MyBase.New()
        tfName = "HGorgonTF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "HGorgonTF"
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        'transformation
        If p.sex.Equals("Male") Then p.MtF()
        p.changeHairColor(Color.FromArgb(255, 92, 154, 1))
        p.prt.setIAInd(pInd.rearhair, 20, True, True)
        p.prt.setIAInd(pInd.midhair, 22, True, True)
        p.prt.setIAInd(pInd.fronthair, 21, True, True)
        p.prt.setIAInd(pInd.eyes, 30, True, True)
        p.prt.setIAInd(pInd.eyebrows, 5, True, False)

        p.changeForm("Half-Gorgon")

        If Not p.knownSpells.Contains("Petrify II") Then p.knownSpells.Add("Petrify II")
    End Sub
End Class
