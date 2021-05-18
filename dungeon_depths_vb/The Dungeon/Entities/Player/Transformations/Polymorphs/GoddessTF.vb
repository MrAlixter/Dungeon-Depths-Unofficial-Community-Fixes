Public NotInheritable Class GoddessTF
    Inherits PolymorphTF
    Sub New()
        MyBase.New()
        tfName = "GoddessTF"
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        nextStep = getNextStep(cs)
        tfName = "GoddessTF"
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        Dim p As Player = Game.player1
        turnsTilNextStep = Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getMaxMana) + Int(Rnd() * p.getWIL)
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1
        Dim out = ""

        'unequips
        Equipment.clothesChange(p, "Goddess_Gown")
        Equipment.weaponChange(p, "Fists")

        'goddess transformation
        If p.sex = "Male" Then
            p.MtF()
            out += "Your body becomes daintier, and you are soon fully female.  "
        End If
        p.prt.haircolor = Color.FromArgb(255, 210, 180, 140)
        If p.prt.skincolor = Color.FromArgb(255, 255, 105, 180) Then p.prt.haircolor = Color.FromArgb(255, 155, 0, 0)
        If p.prt.skincolor = Color.FromArgb(200, 0, 255, 255) Then p.prt.haircolor = Color.FromArgb(180, 5, 245, 198)
        p.breastSize = 2
        p.prt.setIAInd(pInd.rearhair, 8, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 8, True, True)
        p.prt.setIAInd(pInd.ears, 0, True, False)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 8, True, True)
        p.prt.setIAInd(pInd.eyes, 10, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 9, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)
        p.goddState.save(p)

        'transformation description push
        p.TextColor = Color.LightGoldenrodYellow
        out += "Your eyes burn with an awesome fury as golden flames engulf you.  Your opponent squints and covers their eyes, blinded by your new found vibrance.  Dialing back your personal light show, you give them a cocky grin.  They may not know it, but this battle is already over."

        Game.pushLblEvent(out)
    End Sub
End Class
