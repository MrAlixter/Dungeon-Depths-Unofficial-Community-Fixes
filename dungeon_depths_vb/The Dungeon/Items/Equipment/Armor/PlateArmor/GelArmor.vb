Public Class GelArmor
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Gelatinous_Shell")
        id = 137
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = False
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        h_boost = 20
        d_boost = 15
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(52, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(199, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(200, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(201, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(202, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(203, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(204, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(205, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(206, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(36, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(113, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(114, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(115, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(116, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(117, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(118, True, True)

        '|Description|
        setDesc("An extra layer of a more durable goo that a slime can don for extra protection." & DDUtils.RNRN &
                getSizeInformation() & vbCrLf & getStatInformation())
    End Sub

    Public Overrides Sub onEquip(ByRef p As Player)
        MyBase.onEquip(p)
        If p.inv.getCountAt(getName) < 1 Then p.inv.add(getName, 1)
    End Sub
End Class