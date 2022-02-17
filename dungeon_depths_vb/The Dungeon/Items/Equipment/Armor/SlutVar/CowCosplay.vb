Public Class CowCosplay
    Inherits Armor

    Public Const ITEM_NAME As String = "Cow_Cosplay"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 196
        tier = Nothing

        '|Item Flags|
        usable = False
        anti_slut_ind = 31
        compress_breast = False
        hide_dick = False

        '|Stats|
        d_boost = 1
        count = 0
        value = 50

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(66, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(267, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(268, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(269, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(270, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(271, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(272, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(273, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(274, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(46, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(158, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(159, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(160, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(161, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(162, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(163, True, True)

        '|Description|
        setDesc("A cow print bra created to hold cow sized breasts." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
