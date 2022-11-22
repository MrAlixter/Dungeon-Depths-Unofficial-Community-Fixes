Public Class BunnySuitC
    Inherits Armor

    Public Const ITEM_NAME As String = "Bunny_Suit_(Classic)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 222
        tier = Nothing

        '|Item Flags|
        usable = false
        compress_breast = True
        droppable = False
        rando_inv_allowed = False

        '|Stats|
        h_boost = 100
        d_boost = 40
        count = 0
        value = 0

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(68, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(320, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(321, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(322, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(323, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(324, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(55, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(247, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(248, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(249, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(250, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(251, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(14, True, True)

        '|Description|
        setDesc("A sultry outfit worn by waitresses in a club.  This particular bunny suit is from the far off age of ""2017""." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
