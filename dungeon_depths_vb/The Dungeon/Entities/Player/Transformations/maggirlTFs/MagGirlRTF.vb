Public NotInheritable Class MagGirlRTF
    Inherits MagGirlTF

    Private Const TF_IND As tfind = tfind.maggirlr

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Public Overrides Sub setSpells(ByRef p As Player)
        MyBase.setSpells(p)
        p.learnSpecial("Inferno Aura")
        p.learnSpecial("Megaton Punch")
    End Sub

    Overrides Sub tfBody(ByRef p As Player)
        p.breastSize = 1

        p.prt.haircolor = Color.FromArgb(255, 22, 21, 26)
        p.prt.setIAInd(pInd.rearhair, 34, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 40, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 7, True, True)
        p.prt.setIAInd(pInd.eyes, 20, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 38, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)

    End Sub

    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(210).count < 1 Then p.inv.add(210, 1)

        Equipment.accChange(p, "Nothing")
        EquipmentDialogBackend.armorChange(p, "Mag._Girl_Outfit_(R)")
    End Sub
End Class
