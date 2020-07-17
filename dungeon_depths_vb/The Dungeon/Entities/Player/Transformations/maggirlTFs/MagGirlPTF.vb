Public NotInheritable Class MagGirlPTF
    Inherits MagGirlTF

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Magical Girl (P)"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Magical Girl (P)"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setSpells(ByRef p As Player)
        MyBase.setSpells(p)
        If Not p.knownSpecials.Contains("Mana Burst") Then p.knownSpecials.Add("Mana Burst")
        Game.pushLstLog("'Mana Burst' special learned!")

        If Not p.knownSpells.Contains("Sweet Sunbeam") Then p.knownSpells.Add("Sweet Sunbeam")
        Game.pushLstLog("'Sweet Sunbeam' spell learned!")
    End Sub
    Overrides Sub tfBody(ByRef p As Player)
        p.breastSize = 3

        p.prt.haircolor = Color.FromArgb(255, 255, 200, 235)
        p.prt.setIAInd(pInd.rearhair, 33, True, True)
        p.prt.setIAInd(pInd.face, 0, True, False)
        p.prt.setIAInd(pInd.midhair, 39, True, True)
        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.mouth, 6, True, True)
        p.prt.setIAInd(pInd.eyes, 9, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.fronthair, 37, True, True)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.reverseAllRoute()

        If p.isUnwilling() Then p.pout()
    End Sub
    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(202).count < 1 Then p.inv.add(202, 1)

        p.prt.setIAInd(pInd.hairacc, 7, True, False)

        Equipment.accChange("Nothing")
        Equipment.clothesChange("Mag._Girl_Outfit_(P)")
    End Sub
End Class
