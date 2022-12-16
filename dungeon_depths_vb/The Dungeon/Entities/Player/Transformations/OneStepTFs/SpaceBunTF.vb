Public NotInheritable Class SpaceBunTF
    Inherits OneStepTF

    Private Const TF_IND As tfind = tfind.spacebun

    Sub New()
        MyBase.New()
        tf_name = TF_IND
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        next_step = getNextStep(cs)
    End Sub

    Public Shared Sub tf(ByRef p As Player)
        'transformation
        p.MtF()

        '| -- Body TF -- |
        p.breastSize = 2
        p.buttSize = 3

        '| -- Hair TF -- |
        p.prt.haircolor = Color.HotPink
        p.prt.setIAInd(pInd.midhair, 49, True, True)
        p.prt.setIAInd(pInd.rearhair, 41, True, True)

        '| -- Face TF -- |
        p.prt.setIAInd(pInd.eyes, 64, True, True)

        '| -- Clothing TF -- |
        p.inv.add(NanosilkQipao.ITEM_NAME, 1)
        EquipmentDialogBackend.armorChange(p, NanosilkQipao.ITEM_NAME)
    End Sub
End Class
