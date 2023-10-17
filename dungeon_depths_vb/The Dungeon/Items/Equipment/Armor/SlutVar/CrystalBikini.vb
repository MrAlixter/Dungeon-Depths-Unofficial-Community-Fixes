Public Class CrystalBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Crystalline_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 357
        tier = Nothing

        '|Item Flags|
        usable = False
        anti_slut_ind = 144
        compress_breast = True
        show_underboob = True
        is_sexy = True

        '|Stats|
        m_boost = 15
        d_boost = 10
        s_boost = 10
        w_boost = 5
        count = 0
        value = 2777

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(101, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(466, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(467, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(468, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(469, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(97, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(450, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(451, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(452, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(453, True, True)

        '|Description|
        setDesc("A glittering swimsuit plated with teal jewels and enhanced by concentrated mana." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
