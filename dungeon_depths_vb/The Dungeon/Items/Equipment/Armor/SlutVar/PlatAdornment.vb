Public Class PlatAdornment
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Platinum_Adornment")
        id = 266
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.anti_slut_ind = 265

        '|Stats|
        MyBase.d_boost = 25
        count = 0
        value = 6400

        '|Image Index|
        bsize0 = New Tuple(Of Integer, Boolean, Boolean)(80, False, True)
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(356, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(357, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(358, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(359, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(77, False, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(340, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(341, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(342, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(343, True, True)

        '|Description|
        setDesc("A glistening outfit that leaves little to the imagination for those who want to be stupendously stunning." & DDUtils.RNRN & _
                        getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
