Public NotInheritable Class MagGirlGTF
    Inherits MagGirlTF

    Private Const TF_IND As tfind = tfind.maggirlg

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
        If Not p.knownSpells.Contains("Death Cutter") Then p.knownSpells.Add("Death Cutter")
        TextEvent.pushLog("'Death Cutter' spell learned!")
    End Sub

    Overrides Sub tfBody(ByRef p As Player)
        p.breastSize = 0

        'p.prt.haircolor = Color.FromArgb(255, 0, 245, 40)
        p.prt.haircolor = Color.FromArgb(255, 0, 128, 40)
        p.prt.setIAInd(pInd.rearhair, 1, False, False)
        p.prt.setIAInd(pInd.midhair, 45, True, True)
        p.prt.setIAInd(pInd.fronthair, 43, True, True)

        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 22, True, True)
        p.prt.setIAInd(pInd.eyes, 59, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)
    End Sub

    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(304).count < 1 Then p.inv.add(304, 1)

        Equipment.accChange(p, "Nothing")
        EquipmentDialogBackend.armorChange(p, "Mag._Girl_Outfit_(G)")
    End Sub
End Class
