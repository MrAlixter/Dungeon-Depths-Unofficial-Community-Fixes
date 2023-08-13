Public Class BimboArmor
    Inherits Armor

    Public Const ITEM_NAME As String = "Mistwarped_Armor"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 418
        tier = Nothing

        '|Item Flags|
        usable = False

        '|Stats|
        d_boost = 27
        s_boost = 10
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(114, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(506, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(507, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(508, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(509, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(510, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(107, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(492, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(493, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(494, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(495, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(496, True, True)

        '|Description|
        setDesc("A pastel pink set of armor that seems to provide" & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
