Public Class GoldAdornment
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Gold_Adornment")
        id = 39
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.compress_breast = True
        MyBase.anti_slut_ind = 38

        '|Stats|
        MyBase.d_boost = 10
        count = 0
        value = 4100

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(54, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(55, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(56, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(57, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(148, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(149, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(150, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(151, True, True)

        '|Description|
        setDesc("A shiny golden outfit that leaves little to the imagination.  This is a common choice for those who want to be admired." & DDUtils.RNRN & _
                        getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
