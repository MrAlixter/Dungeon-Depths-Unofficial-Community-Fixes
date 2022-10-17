Public Class SkimpyClothesF
    Inherits Armor

    Public Const ITEM_NAME As String = "Fae_Wench's_Outfit"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 331
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        show_underboob = False
        adjust_sleeve_layer = False
        anti_slut_ind = 332

        '|Stats|
        m_boost = 15
        s_boost = 10
        count = 0
        value = 0

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(422, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(423, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(424, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(425, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(426, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(427, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(412, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(413, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(414, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(415, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(416, True, True)

        '|Description|
        setDesc("A breezy set of clothing given as a gift by the faefolk to those they'd like to see more of." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
