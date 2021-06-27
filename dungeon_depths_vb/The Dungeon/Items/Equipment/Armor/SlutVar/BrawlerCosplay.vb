Public Class BrawlerCosplay
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Brawler_Cosplay")
        id = 20
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.anti_slut_ind = 19

        '|Stats|
        MyBase.d_boost = 6
        MyBase.a_boost = 5
        count = 0
        value = 1250

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(32, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(33, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(34, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(35, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(34, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(35, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(36, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(37, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(38, True, True)

        '|Description|
        setDesc("A glamourous garment made more for the highlighting one's body than for any practical function. " & DDUtils.RNRN &
                                      getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
