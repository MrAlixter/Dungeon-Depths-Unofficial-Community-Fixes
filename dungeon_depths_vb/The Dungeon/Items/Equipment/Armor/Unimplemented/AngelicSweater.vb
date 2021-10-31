Public Class AngelicSweater
    Inherits Armor

    Sub New()
        '|ID Info|
        setName("Angelic_Sweater")
        id = 199
        tier = Nothing

        '|Item Flags|
        usable = false
        MyBase.droppable = False
        rando_inv_allowed = False
        MyBase.compress_breast = True
        MyBase.hide_dick = False

        '|Stats|
        h_boost = 10
        MyBase.d_boost = 5
        MyBase.m_boost = 20
        count = 0
        value = 7777

        '|Image Index|
        bsize1 = New Tuple(Of Integer, Boolean, Boolean)(280, True, True)
        bsize2 = New Tuple(Of Integer, Boolean, Boolean)(281, True, True)
        bsize3 = New Tuple(Of Integer, Boolean, Boolean)(282, True, True)
        bsize4 = New Tuple(Of Integer, Boolean, Boolean)(283, True, True)

        usize1 = New Tuple(Of Integer, Boolean, Boolean)(178, True, True)
        usize2 = New Tuple(Of Integer, Boolean, Boolean)(179, True, True)
        usize3 = New Tuple(Of Integer, Boolean, Boolean)(180, True, True)
        usize4 = New Tuple(Of Integer, Boolean, Boolean)(181, True, True)
        usize5 = New Tuple(Of Integer, Boolean, Boolean)(182, True, True)

        '|Description|
        setDesc("A glittering, heavenly soft sweater." & DDUtils.RNRN &
                                     getSizeInformation() & vbcrlf & getStatInformation())
    End Sub
End Class
