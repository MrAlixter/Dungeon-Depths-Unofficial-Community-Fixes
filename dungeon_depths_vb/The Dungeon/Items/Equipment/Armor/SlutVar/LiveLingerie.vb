Public Class LiveLingerie
    Inherits Armor

    Public Const ITEM_NAME As String = "Living_Lingerie"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 56
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        cursed = True
        rando_inv_allowed = False
        anti_slut_ind = 55

        '|Stats|
        d_boost = 6
        count = 0
        value = 450

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(16, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(266, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(82, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(84, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(86, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(88, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(44, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(45, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(145, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(146, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(147, True, True)

        '|Description|
        setDesc("A suit of living lingerie embued with a the soul of a mimic." & DDUtils.RNRN & _
                                  getSizeInformation() & DDUtils.RNRN & getStatInformation() &
                           "The mimic's movment rapidly raises lust" & vbCrLf & _
                           "May not be easy to remove")
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If p.perks(perk.livelinge) < 0 Then p.perks(perk.livelinge) = 1
    End Sub
    Public Overrides Sub onUnequip(ByRef p As Player)
        MyBase.onUnequip(p)
        If p.perks(perk.livelinge) > -1 Then p.perks(perk.livelinge) = -1
    End Sub
End Class
