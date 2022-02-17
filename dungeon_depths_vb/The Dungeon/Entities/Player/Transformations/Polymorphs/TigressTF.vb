Public NotInheritable Class TigressTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.tigresspolymorph

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
        Dim p As player = Game.player1
        turns_until_next_step = Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getmaxMana) + Int(Rnd() * p.getWIL)
    End Sub

    Public Overrides Sub step1()
        Dim p As player = Game.player1
        Dim out = ""

        'unequips
        EquipmentDialogBackend.armorChange(p, "Naked")
         EquipmentDialogBackend.weaponChange(p, "Fists")

        'goddess transformation
        If p.sex = "Male" Then
            p.MtF()
            out += "Your body becomes daintier, and you are soon fully female.  "
        End If
        If p.prt.skincolor = Color.FromArgb(255, 255, 105, 180) Then p.prt.haircolor = Color.FromArgb(255, 155, 0, 0)
        If p.prt.skincolor = Color.FromArgb(200, 0, 255, 255) Then p.prt.haircolor = Color.FromArgb(180, 5, 245, 198)

        p.prt.setIAInd(pInd.tail, 4, True, False)
        p.prt.setIAInd(pInd.rearhair, 15, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 19, True, True)
        p.prt.setIAInd(pInd.ears, 7, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 11, True, True)
        p.prt.setIAInd(pInd.eyes, 18, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 15, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.breastSize = 2
        p.dickSize = -1
        p.buttSize = 1
        'transformation description push
        p.TextColor = Color.Orange
        out += "As a golden fur spreads over your arms and legs, your muscles surge with a new strength.  You grin, barring your newly retractable claws and taking an aggressive stance."

        TextEvent.push(out)
    End Sub
End Class
