Public Class PrincessGown
    Inherits Armor

    Public Const ITEM_NAME As String = "Regal_Gown"

    Sub New()
        '|ID Info|
        setName(ITEM_NAME)
        id = 75
        tier = Nothing

        '|Item Flags|
        usable = False
        compress_breast = True

        '|Stats|
        m_boost = 2
        count = 0
        value = 0

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(48, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(49, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(50, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(106, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(107, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(108, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(109, True, True)

        '|Description|
        setDesc("The frilly ballgown of a bonafide princess." & DDUtils.RNRN &
                getSizeInformation() & DDUtils.RNRN &
                getStatInformation())
    End Sub
End Class
