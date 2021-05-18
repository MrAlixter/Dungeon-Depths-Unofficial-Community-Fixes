Public Class GothOutfit
    Inherits Armor

    Sub New()
        setName("TODO_Outfit")

        id = 181
        tier = Nothing

        usable = false
        MyBase.d_boost = 9
        MyBase.s_boost = 7
        count = 0
        value = 1450

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

        MyBase.compress_breast = False

        setDesc("Yeah, uhh... I didn't have time to finish the thing this was a part of, so..." & DDUtils.RNRN & _
                                   getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
