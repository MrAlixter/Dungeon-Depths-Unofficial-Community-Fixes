Public NotInheritable Class ProMagGirlTF
    Inherits MagGirlTF

    Private Const TF_IND As tfind = tfind.promaggirl

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
        If Not p.knownSpecials.Contains("Mana Burst") Then p.knownSpecials.Add("Mana Burst")
        TextEvent.pushLog("'Mana Burst' special learned!")

        If Not p.knownSpells.Contains("Shiny Sparking Missile") Then p.knownSpells.Add("Shiny Sparking Missile")
        TextEvent.pushLog("'Shiny Sparking Missile' spell learned!")
    End Sub
    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(201).count < 1 Then p.inv.add(201, 1)

        p.prt.setIAInd(pInd.hairacc, 2, True, False)

        Equipment.accChange(p, "Nothing")
        EquipmentDialogBackend.armorChange(p, "Pro_Mag._Girl_Outfit")
    End Sub
End Class
