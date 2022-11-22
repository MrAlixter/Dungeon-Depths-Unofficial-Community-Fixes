Public Class BunnySuitS
    Inherits Armor

    Public Const ITEM_NAME As String = "Bunny_Suit_(Spidersilk)"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 363
        tier = Nothing

        '|Item Flags|
        usable = False
        rando_inv_allowed = False
        compress_breast = True

        '|Stats|
        d_boost = 1
        s_boost = 7
        count = 0
        value = 325

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(470, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(471, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(472, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(473, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(474, True, True)
        bsize5 = New Tuple(Of Integer, Boolean, Boolean)(475, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(454, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(455, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(456, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(457, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(458, True, True)

        hood = New Tuple(Of Integer, Boolean, Boolean)(8, True, False)

        '|Description|
        setDesc("A sultry outfit spun from spidersilk, styled for waitresses in an arachnid club. " & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN & getStatInformation())
    End Sub
End Class
