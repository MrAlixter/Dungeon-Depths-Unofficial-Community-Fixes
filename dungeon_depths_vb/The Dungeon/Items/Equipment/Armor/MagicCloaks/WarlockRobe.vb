Public Class WarlockRobe
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Warlock's_Robes")
        id = 115
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True

        '|Stats|
        h_boost = 5
        MyBase.d_boost = 20
        MyBase.m_boost = 15
        count = 0
        value = 1840

        '|Image Index|
        MyBase.bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(48, False, True)
        MyBase.bsize0 = New Tuple(Of Integer, Boolean, Boolean)(70, False, True)
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(167, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(168, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(169, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(170, True, True)

        MyBase.usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(61, False, True)
        MyBase.usize0 = New Tuple(Of Integer, Boolean, Boolean)(270, True, True)
        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(270, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(271, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(272, True, True)

        '|Description|
        setDesc("A snazzy robe that identifies its wearer as a high ranking follower of Uvona, Goddess of Fugue.  The goddess's power is woven into its very fabric, amplifying its wearer's own magic ability." & DDUtils.RNRN &
                              getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
