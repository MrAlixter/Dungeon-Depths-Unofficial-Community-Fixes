Public Class BronzeBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Bronze_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 85
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        show_underboob = True
        anti_slut_ind = 83

        '|Stats|
        d_boost = 3
        s_boost = 5
        count = 0
        value = 250

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(30, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(31, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(128, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(129, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(130, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(24, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(25, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(68, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(69, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(70, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(71, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(72, True, True)

        '|Description|
        setDesc("A bronze bikini covered in a fine mail of bronze rings.  While it won't stop very many hits, it is also lightweight enough to move around freely." & DDUtils.RNRN &
                                   getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
