Public Class GShowgirlOutfit
    Inherits Armor

    Public Const ITEM_NAME As String = "Showgirl_Outfit_(G)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 364
        tier = Nothing

        '|Item Flags|
        usable = False
        anti_slut_ind = 16

        '|Stats|
        d_boost = 1
        count = 0
        value = 650

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(102, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(476, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(477, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(478, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(479, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(480, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(98, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(459, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(460, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(461, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(462, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(463, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(21, True, True)

        '|Description|
        setDesc("A flashy outfit made to be worn on the stage of a ritzy club." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
