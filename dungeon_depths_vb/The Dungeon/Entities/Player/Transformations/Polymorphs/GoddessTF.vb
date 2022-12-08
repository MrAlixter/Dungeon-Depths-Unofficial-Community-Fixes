Public NotInheritable Class GoddessTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.goddess

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
        Dim p As Player = Game.player1
        turns_until_next_step = Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getMaxMana) + Int(Rnd() * p.getWIL)
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1
        Dim out = ""

        'unequips
        If Not p.inv.getCountAt(GoddessGown.ITEM_NAME) > 0 Then p.inv.add(GoddessGown.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, "Goddess_Gown")

        'goddess transformation
        If p.sex = "Male" Then
            p.MtF()
            out += "Your body becomes daintier, and you are soon fully female." & DDUtils.RNRN
        End If

        p.prt.haircolor = Color.FromArgb(255, 210, 180, 140)
        If p.prt.skincolor = Color.FromArgb(255, 255, 105, 180) Then p.prt.haircolor = Color.FromArgb(255, 155, 0, 0)
        If p.prt.skincolor = Color.FromArgb(200, 0, 255, 255) Then p.prt.haircolor = Color.FromArgb(180, 5, 245, 198)

        p.breastSize = 2

        'hair
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 8, True, True)

        'face
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.ears, 0, True, False)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 10, True, True)

        'clothes
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hairacc, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.formStates(stateInd.goddState).save(p)

        'transformation description push
        p.textColor = Color.LightGoldenrodYellow

        If Game.combat_engaged Then
            out += "Your eyes burn with an awesome fury as golden flames engulf you, while your opponent averts their gaze; blinded by your newfound aura of supremacy.  Dialing back the lightshow, you give them a serene grin." & DDUtils.RNRN &
                   "They may not know it, but this battle is already over."
        Else
            out += "Your eyes burn with an awesome fury as golden flames engulf you, as your newfound aura of supremacy casts a dazzling lightshow for all to see." & DDUtils.RNRN &
                   "Divinity suits you well..."
        End If

        TextEvent.push(out)
    End Sub
End Class
