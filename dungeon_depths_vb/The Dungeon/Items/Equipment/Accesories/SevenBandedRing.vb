Public Class SevenBandedRing
    Inherits Accessory

    Public Const ITEM_NAME As String = "Seven_Banded_Ring"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 223
        tier = Nothing

        '|Item Flags|
        usable = false
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 15000

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        setDesc("A ornate golden ring composed of seven interlocking bands." & DDUtils.RNRN &
                "Grants the ""Lucky 7"" perk to its wearer.  This perk provides a saving roll if a spell would miss/backfire.")
    End Sub
    Public Overrides Sub onEquip(ByRef p As Player)
        p.perks(perk.lucky7) = 1
        If p.prt.iArrInd(pInd.tail).Item1 = 0 Then p.prt.setIAInd(pInd.tail, 3, True, False)
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        p.perks(perk.lucky7) = -1
        If p.prt.iArrInd(pInd.tail).Item1 = 3 Then p.prt.setIAInd(pInd.tail, 0, True, False)
    End Sub
End Class
