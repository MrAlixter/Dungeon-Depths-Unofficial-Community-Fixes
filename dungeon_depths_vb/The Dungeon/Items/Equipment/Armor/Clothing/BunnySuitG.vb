Public Class BunnySuitG
    Inherits Armor
    Sub New()
        '|ID Info|
        setName("Bunny_Suit_(Gold)")
        id = 323
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True

        '|Stats|
        d_boost = 1
        s_boost = 7
        count = 0
        value = 325

        '|Image Index|
        bsizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(93, False, True)
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(413, True, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(414, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(415, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(416, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(417, True, True)

        usizeneg1 = New Tuple(Of Integer, Boolean, Boolean)(90, False, True)
        usize0 = New Tuple(Of Integer, Boolean, Boolean)(402, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(403, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(404, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(405, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(406, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(407, True, True)

        '|Description|
        setDesc("A sultry outfit worn by primo waitresses in a club. " & DDUtils.RNRN &
                getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
