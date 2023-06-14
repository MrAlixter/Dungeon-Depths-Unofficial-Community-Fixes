Public Class SkimpyTT
    Inherits Armor

    Public Const ITEM_NAME As String = "Skimpy_Tank_Top"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 147
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        rando_inv_allowed = False

        '|Stats|
        s_boost = 10
        count = 0
        value = 138

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(215, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(216, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(217, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(218, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(252, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(253, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(254, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(255, True, True)

        '|Description|
        setDesc("Barely there, this skimpy outfit boosts agility." & DDUtils.RNRN & _
                                    getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        p.perks(perk.bimbododge) = 2
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        p.perks(perk.bimbododge) = -1
    End Sub
End Class
