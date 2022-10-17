Public NotInheritable Class ProMagGirlRTF
    Inherits MagGirlTF

    Private Const TF_IND As tfind = tfind.promaggirlr
    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        MG_IND = mgind.proredmagicalgirl
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        MG_IND = mgind.proredmagicalgirl
        next_step = getNextStep(cs)
    End Sub

    Overrides Sub tfBody(ByRef p As Player)
        p.breastSize = 1

        p.prt.haircolor = Color.FromArgb(255, 249, 52, 141)
        p.prt.setIAInd(pInd.rearhair, 35, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 41, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 7, True, True)
        p.prt.setIAInd(pInd.eyes, 20, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 39, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)
    End Sub

    Public Overrides Sub setSpells(ByRef p As Player)
        MyBase.setSpells(p)
        p.learnSpecial("Inferno Aura")
        p.learnSpecial("Megaton Punch")
        p.learnSpecial("Gigaton Punch")
    End Sub
    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(211).count < 1 Then p.inv.add(211, 1)

        Equipment.accChange(p, "Nothing")
        EquipmentDialogBackend.armorChange(p, "Pro_Mag._G._Outfit_(R)")

        p.textColor = Color.IndianRed
    End Sub
End Class
