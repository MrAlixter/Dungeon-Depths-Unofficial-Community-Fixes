Public NotInheritable Class AmaraphneAngelTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.amaraphneangel

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
        Dim out = ""

        'angel transformation
        p.changeHairColor(Color.FromArgb(255, 255, 89, 150))

        p.prt.setIAInd(pInd.eyes, 26, True, True)
        p.prt.setIAInd(pInd.eyebrows, 5, True, False)
        p.prt.setIAInd(pInd.mouth, 19, True, True)

        p.prt.setIAInd(pInd.rearhair, 8, True, False)
        p.prt.setIAInd(pInd.midhair, 10, True, False)

        p.prt.setIAInd(pInd.wings, 9, True, False)

        p.breastSize = 2
        p.buttSize = 1
        p.dickSize = -1

        If p.inv.getCountAt("Vestment_of_Amaraphne") < 1 Then p.inv.add("Vestment_of_Amaraphne", 1)
        EquipmentDialogBackend.armorChange(p, "Vestment_of_Amaraphne")

        If p.inv.getCountAt("Mark_of_Amaraphne") < 1 Then p.inv.add("Mark_of_Amaraphne", 1)
        EquipmentDialogBackend.accessoryChange(p, "Mark_of_Amaraphne")
        p.perks(perk.moamarphne) = 214

        p.changeForm("Angel")
        p.changeClass("Cleric")
    End Sub
End Class
