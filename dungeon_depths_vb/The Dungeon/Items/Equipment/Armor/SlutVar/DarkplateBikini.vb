Public Class DarkplateBikini
    Inherits Armor

    Public Const ITEM_NAME As String = "Darkplate_Bikini"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 413
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False
        compress_breast = True
        show_underboob = True
        adjust_sleeve_layer = False

        '|Stats|
        d_boost = 11
        s_boost = 10
        count = 0
        value = 1540

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(112, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(113, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(503, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(504, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(505, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(105, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(106, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(488, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(489, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(490, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(491, True, True)

        '|Description|
        setDesc("A suprisingly lightweight set of armored plates that allows its user to move freely while also provideing protection.  Much of the armor seems to be missing, though, replaced by a crimson swimsuit." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
