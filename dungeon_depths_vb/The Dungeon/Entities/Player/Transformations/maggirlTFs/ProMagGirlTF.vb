Public NotInheritable Class ProMagGirlTF
    Inherits MagGirlTF

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tfName = "Pro Magical Girl"
        nextStep = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tfName = "Pro Magical Girl"
        nextStep = getNextStep(cs)
    End Sub

    Public Overrides Sub setSpells(ByRef p As Player)
        MyBase.setSpells(p)
        If Not p.knownSpells.Contains("Mana Burst") Then p.knownSpells.Add("Mana Burst")
        Game.pushLstLog("'Mana Burst' special learned!")

        If Not p.knownSpells.Contains("Shiny Sparking Missile") Then p.knownSpells.Add("Shiny Sparking Missile")
        Game.pushLstLog("'Shiny Sparking Missile' spell learned!")
    End Sub
    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(201).count < 1 Then p.inv.add(201, 1)

        p.prt.setIAInd(pInd.hairacc, 2, True, False)

        Equipment.accChange("Nothing")
        Equipment.clothesChange("Pro_Mag._Girl_Outfit")
    End Sub
End Class
