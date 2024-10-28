Public NotInheritable Class SuccubusAssassinTF
    Inherits PolymorphTF

    Private Const TF_IND As tfind = tfind.succubusasspolymorph
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

        '| -- Succubus transformation -- |
        neededMTF = False
        If Not p.prt.sexBool Then
            p.MtF()
            neededMTF = True
        End If
        If p.breastSize < 2 Then p.breastSize = 2

        EquipmentDialogBackend.clothingCurse(p, False)
        If p.equippedArmor.getAName.Equals(SkimpyClothes.ITEM_NAME) Then
            p.inv.add(SkimpyClothes.ITEM_NAME, -1)
            p.inv.add(SkimpyClothesD.ITEM_NAME, 1)

            EquipmentDialogBackend.equipArmor(p, SkimpyClothesD.ITEM_NAME)
        End If

        p.prt.haircolor = DemonTF.getDemonHairColor(p.prt.haircolor)
        p.prt.skincolor = Color.FromArgb(255, 255, 105, 180)
        p.changeForm("Succubus")
        p.changeClass("Assassin")

        p.prt.setIAInd(pInd.rearhair, 9, True, True)
        p.prt.setIAInd(pInd.midhair, 9, True, True)
        p.prt.setIAInd(pInd.fronthair, 13, True, True)
        p.prt.setIAInd(pInd.eyebrows, 0, True, False)

        p.prt.setIAInd(pInd.nose, 0, True, False)
        p.prt.setIAInd(pInd.eyes, 12, True, True)
        p.prt.setIAInd(pInd.cloak, 0, True, False)
        p.prt.setIAInd(pInd.hat, 0, True, False)

        p.prt.setIAInd(pInd.wings, 2, True, False)
        p.prt.setIAInd(pInd.horns, 3, True, False)

        '| -- Transformation Description -- |
        p.textColor = Color.HotPink
        Game.player1.perks(perk.canmeetcyn) = 1
    End Sub

    Public Overrides Function getTFText() As String
        Dim out = "Hellfire engulfs you, as you pirouette before your foe.  ""Are you ready..."" you ask with a toothy grin, ""...for some fun?"""

        If neededMTF Then out = "Your body becomes daintier, and you are soon fully female.  " & out

        Return out
    End Function
End Class
