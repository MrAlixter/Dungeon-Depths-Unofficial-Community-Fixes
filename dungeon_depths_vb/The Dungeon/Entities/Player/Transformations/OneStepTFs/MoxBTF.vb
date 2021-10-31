Public NotInheritable Class MoxBTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.blueox

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

        If p.sex = "Male" Then
            p.MtF()
        End If

        'blue ox transformation
        p.changeHairColor(Color.FromArgb(255, 121, 160, 225))
        p.prt.setIAInd(pInd.horns, 11, True, False)
        p.prt.setIAInd(pInd.ears, 8, True, True)

        If p.breastSize > 0 Then p.be() : p.be() : p.be()
        If p.dickSize > 0 Then p.de() : p.de() : p.de()

        p.changeForm("Minotaur Cow (B)")

        'transformation description push
        out += """WHO DARES EAT MY CATTLE?!  AS PUNISHMENT, YOU SHALL REPLACE WHAT HAS BEEN STOLEN!"" a feminine voice thunders through the sky." & DDUtils.RNRN &
               "As cyan fur races up your legs, you shout back that you were sold an explicitly normal steak.  ""That bastard cook..."" the voice snarls after a brief pause, as your transformation stops." & DDUtils.RNRN &
               "You are now a Minotaur Cow (B)!"
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        TextEvent.push(out)
    End Sub
End Class
