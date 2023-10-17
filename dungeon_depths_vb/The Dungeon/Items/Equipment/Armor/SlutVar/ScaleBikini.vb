Public Class ScaleBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Scale_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 177
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        anti_slut_ind = 176
        is_sexy = True

        '|Stats|
        d_boost = 9
        s_boost = 7
        count = 0
        value = 1450

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(241, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(242, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(243, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(244, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(245, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(246, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(51, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(186, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(187, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(188, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(189, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(190, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(191, True, True)

        '|Description|
        setDesc("This bikini consists of a set of plates that contour to its wearer's breasts.  While the scales making up this ""armor"" don't offer much in the way of protection, they also don't get in the way." & DDUtils.RNRN & _
                                     getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
