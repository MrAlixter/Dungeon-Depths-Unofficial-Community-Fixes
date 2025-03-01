Public Class CatburglarSuit
    Inherits Armor

    Public Const ITEM_NAME As String = "Burglar's_Bodystocking"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 457
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True
        force_under_acce = True
        anti_slut_ind = 443

        '|Stats|
        s_boost = 25
        count = 0
        value = 1250

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(125, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(545, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(546, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(547, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(548, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(549, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(118, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(532, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(533, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(534, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(535, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(536, True, True)

        '|Description|
        setDesc("A skintight suit for a sneaky gal." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
