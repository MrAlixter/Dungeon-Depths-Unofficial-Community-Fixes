Public Class WarlockRobe
    Inherits Armor

    Sub New()
        '|ID Info|
        MyBase.setName("Warlock's_Robes")
        id = 115
        tier = Nothing

        '|Item Flags|
        MyBase.setUsable(False)
        MyBase.compressesBreasts = True

        '|Stats|
        MyBase.hBoost = 5
        MyBase.dBoost = 20
        MyBase.mBoost = 15
        MyBase.count = 0
        MyBase.value = 1840

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
        MyBase.setDesc("A snazzy robe that identifies its wearer as a high ranking follower of Uvona, Goddess of Fugue.  The goddess's power is woven into its very fabric, amplifying its wearer's own magic ability." & DDUtils.RNRN &
                              getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
