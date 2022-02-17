Public Class SVBunnySuit
    Inherits Armor

    Public Const ITEM_NAME As String = "Bunny_Suit​"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 129
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = False
        anti_slut_ind = 16

        '|Stats|
        d_boost = 1
        count = 0
        value = 650

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(50, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(183, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(184, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(185, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(186, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(187, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(188, True, True)
        bsize6 = New Tuple(Of Integer, Boolean, Boolean)(189, True, True)
        bsize7 = New Tuple(Of Integer, Boolean, Boolean)(190, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(27, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(79, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(80, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(81, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(82, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(83, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(84, True, True)

        '|Description|
        setDesc("An extremely sultry outfit worn by waitresses in a club. " & DDUtils.RNRN & _
                            getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
