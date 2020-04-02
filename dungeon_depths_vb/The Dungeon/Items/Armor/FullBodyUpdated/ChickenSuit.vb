Public Class ChickenSuit
    Inherits Armor
    Dim prevWingInd As Integer = 0
    Sub New()
        MyBase.setName("Chicken_Suit")
        MyBase.setDesc("This outfit, little more than some wings and straps, lightens its user though it doesn't actually provide any protection." & vbCrLf & _
                      "Fits all sizes" & vbCrLf & _
                      "+10 SPD")
        id = 8
        If DDDateTime.isAni Then tier = 2 Else tier = Nothing
        MyBase.setUsable(False)
        MyBase.sBoost = 10
        MyBase.count = 0
        MyBase.value = 300
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(21, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(22, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(111, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(112, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(113, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(114, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(114, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(115, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(116, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(28, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(29, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(90, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(91, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(92, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(93, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(94, True, True)
        MyBase.compressesBreasts = False

        MyBase.isRandoTFAcceptable = False
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        Dim bTF As BimboTF = New BimboTF(2, 0, 0.25, True)
        bTF.chickenTf()
        prevWingInd = CInt(p.prt.iArrInd(pInd.wings).Item1)
        p.prt.setIAInd(pInd.wings, 3, True, False)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.prt.setIAInd(pInd.wings, prevWingInd, True, True)
    End Sub
End Class
