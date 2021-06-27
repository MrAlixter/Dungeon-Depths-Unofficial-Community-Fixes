Public Class GothOutfit
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("TODO_Outfit")
        id = 181
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = False
        rando_inv_allowed = False

        '|Stats|
        count = 0
        value = 1450
        d_boost = 9
        s_boost = 7

        '|Image Index|
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(247, True, True)
        MyBase.bsize4 = New Tuple(Of Integer, Boolean, Boolean)(248, True, True)
        MyBase.bsize5 = New Tuple(Of Integer, Boolean, Boolean)(249, True, True)
        MyBase.bsize6 = New Tuple(Of Integer, Boolean, Boolean)(250, True, True)
        MyBase.bsize7 = New Tuple(Of Integer, Boolean, Boolean)(251, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(256, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(257, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(258, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(259, True, True)
        MyBase.usize5 = New Tuple(Of Integer, Boolean, Boolean)(260, True, True)

        '|Description|
        setDesc("Yeah, uhh... I didn't have time to finish the thing this was a part of, so..." & DDUtils.RNRN &
                getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
