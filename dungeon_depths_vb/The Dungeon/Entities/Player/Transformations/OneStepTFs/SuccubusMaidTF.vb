Public NotInheritable Class SuccubusMaidTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.maid

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
    End Sub

    Public Overrides Sub step1()
        Dim p As Player = Game.player1

        p.changeClass("Maid")
        p.changeForm("Half-Succubus")

        'change equipment
        If p.inv.item("Maid_Lingerie").count < 1 Then p.inv.add("Maid_Lingerie", 1)
        EquipmentDialogBackend.armorChange(p, "Maid_Lingerie")
        If p.inv.getCountAt("Small_Glasses") < 1 Then p.inv.add("Small_Glasses", 1)
        EquipmentDialogBackend.glassesChange(p, "Small_Glasses")

        p.breastSize = 2
        p.buttSize = 1
        p.dickSize = -1

        p.perks(perk.slutcurse) = 1

        p.prt.setIAInd(pInd.rearhair, 11, True, False)
        p.prt.setIAInd(pInd.midhair, 11, True, False)
        p.prt.setIAInd(pInd.fronthair, 3, True, False)

        p.prt.setIAInd(pInd.mouth, 22, True, False)

        p.prt.setIAInd(pInd.eyes, 12, True, True)
        p.prt.setIAInd(pInd.wings, 2, True, False)
        p.prt.setIAInd(pInd.horns, 3, True, False)

        p.changeHairColor(Color.White)
        p.changeSkinColor(Color.FromArgb(255, 255, 78, 78))
    End Sub
End Class
