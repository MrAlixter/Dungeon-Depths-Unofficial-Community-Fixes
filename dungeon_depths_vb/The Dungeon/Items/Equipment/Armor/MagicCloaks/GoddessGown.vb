Public Class GoddessGown
    Inherits Armor
    Sub New()
        setName("Goddess_Gown")

        id = 73
        tier = Nothing
        usable = false
        MyBase.m_boost = 2
        count = 0
        value = 0
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(89, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(90, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(10, True, True)

        usize0 = New Tuple(Of Integer, Boolean, Boolean)(49, True, True)
        usize1 = New Tuple(Of Integer, Boolean, Boolean)(50, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(51, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(52, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(53, True, True)
        MyBase.compress_breast = True

        setDesc("A gown worn by a goddess." & DDUtils.RNRN &
                                      getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
