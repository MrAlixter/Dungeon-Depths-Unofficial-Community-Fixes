Public Class PrincessGown
    Inherits Armor
    Sub New()
        setName("Regal_Gown")

        id = 75
        tier = Nothing
        usable = false
        MyBase.m_boost = 2
        count = 0
        value = 0
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(48, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(49, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(50, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(106, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(107, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(108, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(109, True, True)
        MyBase.compress_breast = True

        setDesc("The frilly ballgown of a bonafide princess." & DDUtils.RNRN & _
                                   getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
