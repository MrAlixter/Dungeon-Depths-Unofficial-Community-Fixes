Public NotInheritable Class MagGirlDTF
    Inherits MagGirlTF

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Magical Girl (D)"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Magical Girl (D)"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setSpells(ByRef p As Player)
        If Not p.knownSpecials.Contains("Inferno Aura") Then p.knownSpecials.Add("Inferno Aura")
        Game.pushLstLog("'Inferno Aura' special learned!")

        If Not p.knownSpells.Contains("Heartbreak Supernova") Then p.knownSpells.Add("Heartbreak Supernova")
        Game.pushLstLog("'Heartbreak Supernova' special learned!")
    End Sub

    Overrides Sub tfBody(ByRef p As Player)
        p.breastSize = 1

        p.prt.haircolor = Color.FromArgb(255, 206, 0, 204)
        p.prt.setIAInd(pInd.rearhair, 36, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 42, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 23, True, True)
        p.prt.setIAInd(pInd.eyes, 15, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 40, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)

    End Sub

    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(208).count < 1 Then p.inv.add(208, 1)

        p.prt.setIAInd(pInd.hairacc, 8, True, False)

        Equipment.accChange(p, "Nothing")
        Equipment.clothesChange(p, "Mag._Girl_Outfit_(D)")
    End Sub
End Class
