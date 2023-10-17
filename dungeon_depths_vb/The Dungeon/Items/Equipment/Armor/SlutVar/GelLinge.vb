Public Class GelLinge
    Inherits Armor

    Public Const ITEM_NAME As String = "Gelatinous_Negligee"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 138
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        adjust_sleeve_layer = False
        droppable = False
        rando_inv_allowed = False
        is_sexy = True

        '|Stats|
        h_boost = 30
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(51, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(191, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(192, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(193, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(194, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(195, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(196, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(197, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(198, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(58, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(281, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(282, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(283, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(284, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(285, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(286, True, True)

        '|Description|
        setDesc("An extra layer of pink goo that a slime can don for extra provocation." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.rnrn & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If p.inv.getCountAt(getName) < 1 Then p.inv.add(getName, 1)
    End Sub
End Class