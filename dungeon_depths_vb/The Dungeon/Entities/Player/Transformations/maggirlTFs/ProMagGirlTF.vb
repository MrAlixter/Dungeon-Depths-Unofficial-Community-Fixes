Public NotInheritable Class ProMagGirlTF
    Inherits MagGirlTF

    Private Const TF_IND As tfind = tfind.promaggirl

    Sub New(n As Integer, tts As Integer, wi As Double, cbs As Boolean)
        MyBase.New(n, tts, wi, cbs)
        tf_name = TF_IND
        MG_IND = mgind.promagicalgirl
        next_step = AddressOf step1
    End Sub
    Sub New(cs As Integer, n As Integer, tts As Integer, wi As Double, cbs As Boolean, tfd As Boolean)
        MyBase.New(cs, n, tts, wi, cbs, tfd)
        tf_name = TF_IND
        MG_IND = mgind.promagicalgirl
        next_step = getNextStep(cs)
    End Sub

    Public Overloads Shared Function getTaughtSpells() As String()
        Return {"Heartblast Starcannon", "Shiny Sparking Missile"}
    End Function
    Public Overloads Shared Function getTaughtSpecials() As String()
        Return {"Mana Burst"}
    End Function
    Overrides Sub setSpells(ByRef p As Player)
        For Each s In getTaughtSpells()
            p.learnSpell(s)
        Next
        For Each s In getTaughtSpecials()
            p.learnSpecial(s)
        Next
    End Sub

    Overrides Sub tfClothes(ByRef p As Player)
        If p.inv.item(201).count < 1 Then p.inv.add(201, 1)

        p.prt.setIAInd(pInd.hairacc, 2, True, False)

        EquipmentDialogBackend.armorChange(p, "Pro_Mag._Girl_Outfit")

        p.name = "Blue"
        p.textColor = Color.CornflowerBlue
    End Sub
End Class
