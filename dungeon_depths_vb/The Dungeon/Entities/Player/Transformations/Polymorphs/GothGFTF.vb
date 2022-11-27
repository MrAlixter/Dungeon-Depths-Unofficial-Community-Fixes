Public NotInheritable Class GothGFTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.goth

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
        p.inv.add("Goth_Outfit", 1)

        'succubus transformation
        If p.sex = "Male" Then
            p.MtF()
            out += "Your body becomes daintier, and you are soon fully female.  "
        End If

        p.changeForm("Goth")

        Dim c As Color
        Select Case (Int(Rnd() * 6))
            Case 0
                c = Color.Cyan
            Case 1
                c = Color.HotPink
            Case 2
                c = Color.LimeGreen
            Case 3
                c = Color.OrangeRed
            Case 4
                c = Color.Violet
            Case 5
                c = Color.GreenYellow
        End Select

        p.prt.haircolor = c
        p.prt.setIAInd(pInd.rearhair, 29, True, True)
        p.breastSize = 4
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 33, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 41, True, True)
        p.prt.setIAInd(pInd.mouth, 22, True, True)
        p.prt.setIAInd(pInd.ears, 12, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 32, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        EquipmentDialogBackend.armorChange(p, "Goth_Outfit")
        'transformation description push
        out += "GothGF TF"

        TextEvent.push(out)

    End Sub
End Class
