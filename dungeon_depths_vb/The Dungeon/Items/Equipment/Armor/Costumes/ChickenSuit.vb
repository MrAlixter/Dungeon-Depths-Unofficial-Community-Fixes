Public Class ChickenSuit
    Inherits Armor

    Public Const ITEM_NAME As String = "Chicken_Suit"

    Dim prevWingInd As Tuple(Of Integer, Boolean, Boolean) = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 8
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = False
        show_underboob = True
        rando_inv_allowed = False
        is_sexy = True

        '|Stats|
        s_boost = 10
        count = 0
        value = 300

        '|Image Index|
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

        '|Description|
        setDesc("This outfit, little more than some wings and straps, lightens its user though it doesn't actually provide any protection." & DDUtils.RNRN &
                "Fits all sizes" & DDUtils.RNRN &
                getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)

        Dim btf As BimboTF = New BimboTF(2, 5, 0.25, True)
        btf.chickenTf(p)

        prevWingInd = p.prt.iArrInd(pInd.wings)
        p.prt.setIAInd(pInd.wings, 3, True, False)
    End Sub

    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)

        If p.prt.checkFemInd(pInd.wings, 3) Then p.prt.setIAInd(pInd.wings, prevWingInd)
    End Sub
End Class
