Public NotInheritable Class DarkPactTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.darkpact

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

        'succubus transformation
        If p.sex = "Male" Then
            p.MtF()
            out += "Your body becomes daintier, and you are soon fully female.  "
        End If


        If p.breastSize < 2 Then p.breastSize = 2
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 12, True, True)

        p.formStates(stateInd.succDisgState).initFlag = True
        p.formStates(stateInd.succDisgState).save(p)

        p.prt.setIAInd(pInd.eyebrows, 0, True, False)

        p.prt.setIAInd(pInd.hat, 0, True, False)
        p.prt.setIAInd(pInd.wings, 2, True, False)
        p.prt.setIAInd(pInd.horns, 3, True, False)
        p.prt.haircolor = Color.FromArgb(255, 155, 0, 0)
        p.prt.skincolor = Color.FromArgb(255, 255, 105, 180)
        p.changeForm("Succubus")
        p.drawPort()


        p.learnSpell("Cynn's Disguise")

        p.sState.save(p)
        p.pState.save(p)

        'transformation description push
        out += "As hellfire engulfs you, you meet Cynn's gaze.  You give her a sinister grin as wings, horns, and a tail sprout from your now crimson body.  Cynn grins right back before remarking ""Looking good, hot stuff.  I'll give you a bit to get used to being a demon, but don't forget that you owe me.  I'll be in touch!""" & DDUtils.RNRN &
               "Your base form is now that of a succubus!  Should you revert to your start state, this is what you will become."
        Dim revertText = Game.lblEvent.Text.Split(vbCrLf)(0)
        If Not revertText.Equals("") Then out = revertText & DDUtils.RNRN & out
        TextEvent.push(out)
    End Sub

    Public Shared Sub step1alt()
        Dim dptf As DarkPactTF = New DarkPactTF
        dptf.step1()
    End Sub
End Class
