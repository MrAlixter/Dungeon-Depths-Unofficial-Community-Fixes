Public Class SevenBandedRing
    Inherits Accessory

    Sub New()
        '|ID Info|
        MyBase.setName("Seven_Banded_Ring")
        id = 223
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.isMonsterDrop = False
        MyBase.isRandoTFAcceptable = False

        '|Stats|
        MyBase.count = 0
        MyBase.value = 15000

        '|Image Index|
        MyBase.fInd = New Tuple(Of Integer, Boolean, Boolean)(0, True, False)
        MyBase.mInd = New Tuple(Of Integer, Boolean, Boolean)(0, False, False)

        '|Description|
        MyBase.setDesc("A ornate golden ring composed of seven interlocking bands." & DDUtils.RNRN & _
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
