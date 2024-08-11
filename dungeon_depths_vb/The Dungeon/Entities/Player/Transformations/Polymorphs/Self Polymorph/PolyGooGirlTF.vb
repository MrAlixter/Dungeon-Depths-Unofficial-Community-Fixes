Public NotInheritable Class PolyGooGirlTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.polygoogirl

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
        turns_until_next_step = Math.Max(5, (Int(Rnd() * 50) + Int(Rnd() * 50) + Int(Rnd() * p.getMaxMana) + Int(Rnd() * p.getWIL)) * 0.15)
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        'unequips
        p.changeForm("Goo Girl")
        EquipmentDialogBackend.armorChange(p, "Naked")

        'transformation
        p.breastSize = 4
        p.buttSize = 3

        p.prt.setIAInd(pInd.ears, 5, True, True)
        p.prt.setIAInd(pInd.mouth, 18, True, True)
        p.prt.setIAInd(pInd.eyes, 35, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.prt.setIAInd(pInd.rearhair, 27, True, True)
        p.prt.setIAInd(pInd.midhair, 30, True, True)
        p.prt.setIAInd(pInd.fronthair, 28, True, True)

        p.prt.haircolor = Color.FromArgb(180, 255, 120, 255)
        p.prt.skincolor = Color.FromArgb(200, 255, 102, 179)

        'transformation description push
        p.textColor = Color.HotPink
    End Sub

    Public Overrides Sub update()
        MyBase.update()

        Dim p = Game.player1
        If p.health < 0.75 Then
            p.health = Math.Min(1.0, p.health + 0.5)
        End If
    End Sub
End Class
