Public Class ScaleTalisman
    Inherits Accessory

    Public Const ITEM_NAME As String = "Red_Scale_Talisman"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 361
        tier = Nothing

        '|Item Flags|
        usable = False
        under_t_clothes = True

        '|Stats| 
        m_boost = 10
        w_boost = 15
        count = 0
        value = 1736

        '|Image Index|
        fInd = New Tuple(Of Integer, Boolean, Boolean)(50, True, True)
        mInd = New Tuple(Of Integer, Boolean, Boolean)(26, False, True)

        '|Description|
        setDesc("An archaic crimson scale that has been refashioned into the charm of an otherwise simple necklace.  Even now, it bristles with the fury of a long-dead dragon..." & DDUtils.RNRN &
                 getStatInformation())
    End Sub

    Overrides Sub onEquip(ByRef p As Player)
        p.ongoingTFs.add(New ScaleTalismanTF(9, 15, 2.0, True))
        If p.getMana > p.getMaxMana Then p.mana = p.getMaxMana
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        If p.getMana > p.getMaxMana Then p.mana = p.getMaxMana
    End Sub
End Class
