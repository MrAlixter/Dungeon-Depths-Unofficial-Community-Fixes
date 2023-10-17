Public Class SpiralBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Spiral_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 405
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        show_underboob = True
        rando_inv_allowed = False
        list_in_shop = False
        is_sexy = True

        '|Stats|
        m_boost = 18
        d_boost = 11
        w_boost = 16
        count = 0
        value = 3500

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(498, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(499, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(500, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(501, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(502, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(483, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(484, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(485, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(486, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(487, True, True)

        '|Description|
        setDesc("A swirly blue swimsuit with a pattern that goes around... and around... and around..." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
