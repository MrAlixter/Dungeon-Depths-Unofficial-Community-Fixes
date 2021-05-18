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
        MyBase.bsize1 = New Tuple(Of Integer, Boolean, Boolean)(48, True, True)
        MyBase.bsize2 = New Tuple(Of Integer, Boolean, Boolean)(49, True, True)
        MyBase.bsize3 = New Tuple(Of Integer, Boolean, Boolean)(50, True, True)

        MyBase.usize1 = New Tuple(Of Integer, Boolean, Boolean)(106, True, True)
        MyBase.usize2 = New Tuple(Of Integer, Boolean, Boolean)(107, True, True)
        MyBase.usize3 = New Tuple(Of Integer, Boolean, Boolean)(108, True, True)
        MyBase.usize4 = New Tuple(Of Integer, Boolean, Boolean)(109, True, True)
        MyBase.compress_breast = True

        setDesc("The frilly ballgown of a bonafide princess." & DDUtils.RNRN & _
                                   getSizeInformation() & vbCrLf & getStatInformation())
    End Sub
End Class
