Public NotInheritable Class TigressBarbarianTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.tigressbarbpolymorph
    Private neededMTF As Boolean = False

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

        'unequips
        p.changeForm("Tigress")
        p.changeClass("Barbarian")
        If p.inv.getCountAt(ChainBikini.ITEM_NAME) < 1 Then p.inv.add(ChainBikini.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, ChainBikini.ITEM_NAME)

        'goddess transformation
        neededMTF = False
        If p.sex = "Male" Then
            p.MtF()
            neededMTF = True
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

        p.breastSize = 1 + Int(Rnd() * 3)
        p.dickSize = -1
        p.buttSize = 1
        'transformation description push
        p.textColor = Color.Orange
    End Sub

    Public Overrides Function getTFText() As String
        Dim out = ""

        If neededMTF Then out += "Your body becomes daintier, and you are soon fully female."

        Return out & DDUtils.RNRN & "As a golden fur spreads over your arms and legs, your muscles surge with a new strength.  You grin, barring your new retractable claws and taking an aggressive stance."
    End Function
End Class
