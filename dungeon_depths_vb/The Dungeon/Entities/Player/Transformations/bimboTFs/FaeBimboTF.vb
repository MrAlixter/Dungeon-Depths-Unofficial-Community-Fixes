Public NotInheritable Class FaeBimboTF
    Inherits BimboTF

    Private Const TF_IND As tfind = tfind.faebimbo

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = AddressOf hairColorShift
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        MyBase.update_during_combat = False
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    'Step 2
    Public Overrides Sub s2HairChange(ByRef p As Player)
        p.prt.haircolor = bimboyellow2
        p.prt.setIAInd(pInd.rearhair, 40, True, True)  'rearhair1
        p.prt.setIAInd(pInd.midhair, 46, True, True)  'rearhair2
        p.prt.setIAInd(pInd.fronthair, 44, True, True)  'front hair
    End Sub
    Public Overrides Sub s2FaceChange(ByRef p As Player)
        p.prt.haircolor = bimboyellow2
        p.prt.setIAInd(pInd.eyebrows, 9, True, False)  'eyebrows
        p.prt.setIAInd(pInd.eyes, 60, True, True)  'eyes
        p.prt.setIAInd(pInd.mouth, 30, True, True)  'mouth
    End Sub
    Overrides Sub s2ClothesChange(ByRef p As Player)
        If Not p.equippedArmor.getName.Equals("Naked") And Not p.className.Equals("Magical Girl") Then
            If p.inv.item(SkimpyClothesF.ITEM_NAME).count < 1 Then p.inv.add(SkimpyClothesF.ITEM_NAME, 1)
            EquipmentDialogBackend.armorChange(p, SkimpyClothesF.ITEM_NAME)
        End If
    End Sub

    Public Overrides Sub setWaitTime(stage As Integer)
        turns_until_next_step = (Int(Rnd() * 5) + 1)
        turns_until_next_step += generatWILResistance()
    End Sub
End Class
