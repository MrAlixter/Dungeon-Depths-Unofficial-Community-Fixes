Public Class PaladinBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Paladin's_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 404
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        show_underboob = True
        adjust_sleeve_layer = False
        anti_slut_ind = 301
        is_sexy = True

        '|Stats|
        m_boost = 10
        d_boost = 10
        w_boost = 10
        count = 0
        value = 1840

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(109, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(493, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(494, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(495, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(496, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(497, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(102, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(479, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(480, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(481, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(482, True, True)

        '|Description|
        setDesc("A thick set of plate armor that also bolsters its wearer's magical abilities.  Some pieces of armor have been strategically removed, though..." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
